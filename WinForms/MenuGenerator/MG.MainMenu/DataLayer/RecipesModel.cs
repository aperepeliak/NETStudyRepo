using MG.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using MG.MainMenu.BusinessLayer;
using System.ComponentModel;
using System.Windows.Forms;

namespace MG.MainMenu
{
    public class RecipesModel
    {
        private const string XMLSource = "Recipes.xml";

        XDocument document;
        public List<Recipe> Recipes { get; }

        public RecipesModel()
        {
            if (!File.Exists(XMLSource))
            {
                Recipes = SeedData();
            }
            else
            {
                document = XDocument.Load(XMLSource);
                Recipes = GetDataFromXml();
            }
        }

        public List<string> GetCategories()
        {
            return Recipes
                .Select(r => r.Category)
                .Distinct()
                .ToList();
        }

        public List<string> GetSeasons()
        {
            return Recipes
               .Select(r => r.Seasonality)
               .Distinct()
               .ToList();
        }
        public List<string> GetUnits()
        {
            return Recipes
                .SelectMany(r => r.Ingredients, (r, ii) => ii.Ingredient.Units)
                .Distinct()
                .ToList();
        }

        public List<string> GetAllRecipesOfSeasonAndCategory(string category, string[] seasons)
        {
            if (seasons.Length == 0)
            {
                return Recipes.Where(r => r.Category == category)
                .Select(r => r.Name)
                .ToList();
            }
            return Recipes.Where(r => seasons.Contains(r.Seasonality) && r.Category == category)
                .Select(r => r.Name)
                .ToList();
        }

        public List<string> GetRequiredIndredients(List<string> chosenRecipesList)
        {
            var requiredIngrdedients = Recipes
                 .Where(r => chosenRecipesList.Contains(r.Name))
                 .SelectMany(r => r.Ingredients)
                 .ToList();

            var groupedIngredients = requiredIngrdedients
                .GroupBy(ii => ii.Ingredient)
                .Select(g =>
                {
                    return new IngredientInfo
                    {
                        Ingredient = new Ingredient { Name = g.Key.Name, Units = g.Key.Units },
                        Amount = g.Sum(a => a.Amount)
                    };
                });

            var result = new List<string>();

            foreach (var i in groupedIngredients)
            {
                result.Add($"{i.Ingredient.Name} {(i.Ingredient.Name.Length < 4 ? "\t\t\t" : "\t\t")} : {i.Amount} {i.Ingredient.Units}");
            }

            return result;
        }

        internal string[] GetAvailableIngredients()
        {
            return Recipes
                .SelectMany(r => r.Ingredients, (r, ii) => ii.Ingredient.Name)
                .Distinct()
                .ToArray();
        }

        internal bool isRecipeAlreadyExist(string text) => Recipes.Any(r => r.Name.ToLower() == text.ToLower());

        public void SaveDataToXml()
        {
            var rcps = new XElement("Recipes");
            var elements =
                from r in Recipes
                select new XElement("Recipe",
                    new XAttribute("Name", r.Name),
                    new XAttribute("Category", r.Category),
                    new XAttribute("Seasonality", r.Seasonality),

                    new XElement("Ingredients",
                        from i in r.Ingredients
                        select new XElement
                            ("IngredientInfo",
                                new XElement
                                    ("Ingredient",
                                new XAttribute("Name", i.Ingredient.Name),
                                new XAttribute("Units", i.Ingredient.Units)
                                    ),
                        new XElement("Amount", i.Amount)
                            )
                        )
                    );

            rcps.Add(elements);

            document = new XDocument();
            document.Add(rcps);
            document.Save(XMLSource);
        }

        internal BindingList<IngredientView> GetRecipeIngredients(string recipeName)
        {
            var query = Recipes
                .Where(r => r.Name == recipeName)
                .FirstOrDefault()
                .Ingredients
                .Select(ii => new IngredientView
                {
                    Name = ii.Ingredient.Name,
                    Unit = ii.Ingredient.Units,
                    Amount = ii.Amount
                })
                .ToList();

            return new BindingList<IngredientView>(query);
        }

        public List<Recipe> GetDataFromXml()
        {
            var query =
                        from recipe in document.Element("Recipes").Elements("Recipe")
                        select new Recipe
                        {
                            Name = recipe.Attribute("Name").Value,
                            Seasonality = recipe.Attribute("Seasonality").Value,
                            Category = recipe.Attribute("Category").Value,
                            Ingredients =
                                (from ingrInfo in recipe.Element("Ingredients").Elements("IngredientInfo")
                                 select new IngredientInfo()
                                 {
                                     Ingredient = new Ingredient()
                                     {
                                         Name = ingrInfo.Element("Ingredient").Attribute("Name").Value,
                                         Units = ingrInfo.Element("Ingredient").Attribute("Units").Value
                                     },
                                     Amount = double.Parse(ingrInfo.Element("Amount").Value, CultureInfo.InvariantCulture)
                                 }).ToList()
                        };

            return query.ToList();
        }

        internal void AddRecipe(string name, string category, string season,
            BindingList<IngredientView> ingredientsSet)
        {
            Recipes.Add(new Recipe
            {
                Name = name,
                Category = category,
                Seasonality = season,
                Ingredients = ingredientsSet.Select(i => new IngredientInfo
                {
                    Ingredient = new Ingredient
                    {
                        Name = i.Name,
                        Units = i.Unit
                    },
                    Amount = i.Amount
                }).ToList()
            });
        }

        internal void DeleteRecipe(DataGridViewRow currentRow)
        {
            var name = currentRow.Cells["Name"].Value.ToString();
            var category = currentRow.Cells["Category"].Value.ToString();
            var season = currentRow.Cells["Seasonality"].Value.ToString();

            var recipeToDelete = Recipes
                .Where(r => r.Name == name && r.Category == category && r.Seasonality == season)
                .FirstOrDefault();

            Recipes.Remove(recipeToDelete);
        }

        internal void ChangeRecipe(DataGridViewRow currentRow, string name,
            string category, string season, BindingList<IngredientView> ingredientsSet)
        {
            var recipeName = currentRow.Cells["Name"].Value.ToString();
            var recipeChanged = new Recipe
            {
                Name = name,
                Category = category,
                Seasonality = season,
                Ingredients = ingredientsSet.Select(i => new IngredientInfo
                {
                    Ingredient = new Ingredient
                    {
                        Name = i.Name,
                        Units = i.Unit
                    },
                    Amount = i.Amount
                }).ToList()
            };

            var index = Recipes.FindIndex(r => r.Name == recipeName);
            Recipes[index] = recipeChanged;
        }

        private List<Recipe> SeedData()
        {
            var recipes = new List<Recipe>()
            {
                new Recipe()
                {
                    Category = "Вторые блюда", Seasonality = "все",
                    Name = "толченка",
                    Ingredients = new List<IngredientInfo>()
                    {
                        new IngredientInfo()
                        {
                            Ingredient = new Ingredient() {Name = "картофель", Units = "кг" },
                            Amount = 1.5
                        }
                    }
                },
                new Recipe()
                {
                    Category = "Первые блюда", Seasonality = "все",
                    Name = "уха",
                    Ingredients = new List<IngredientInfo>()
                    {
                        new IngredientInfo()
                        {
                            Ingredient = new Ingredient() {Name = "картофель", Units = "кг" },
                            Amount = 0.2
                        },
                        new IngredientInfo()
                        {
                            Ingredient = new Ingredient() {Name = "рыба", Units = "кг" },
                            Amount = 0.9
                        },
                        new IngredientInfo()
                        {
                            Ingredient = new Ingredient() {Name = "рис", Units = "кг" },
                            Amount = 0.1
                        }
                    }
                }
            };

            return recipes;
        }
    }
}
