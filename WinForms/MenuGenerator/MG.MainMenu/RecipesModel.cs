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
        XDocument document;
        public List<Recipe> Recipes { get; }

        public RecipesModel()
        {
            if (!File.Exists("Recipes.xml"))
            {
                Recipes = SeedData();
            }
            else
            {
                document = XDocument.Load("Recipes.xml");
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

        internal bool isRecipeAlreadyExist(string text) => Recipes.Any(r => r.Name == text);

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
            document.Save("Recipes.xml");
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

        private List<Recipe> SeedData()
        {
            var recipes = new List<Recipe>()
            {
                new Recipe()
                {
                    Category = "Вторые блюда", Seasonality = "Всесезонность",
                    Name = "Толченка",
                    Ingredients = new List<IngredientInfo>()
                    {
                        new IngredientInfo()
                        {
                            Ingredient = new Ingredient() {Name = "Картофель", Units = "кг" },
                            Amount = 1.5
                        }
                    }
                },
                new Recipe()
                {
                    Category = "Первые блюда", Seasonality = "Всесезонность",
                    Name = "Уха",
                    Ingredients = new List<IngredientInfo>()
                    {
                        new IngredientInfo()
                        {
                            Ingredient = new Ingredient() {Name = "Картофель", Units = "кг" },
                            Amount = 0.2
                        },
                        new IngredientInfo()
                        {
                            Ingredient = new Ingredient() {Name = "Рыба", Units = "кг" },
                            Amount = 0.9
                        },
                        new IngredientInfo()
                        {
                            Ingredient = new Ingredient() {Name = "Рис", Units = "кг" },
                            Amount = 0.1
                        }
                    }
                }
            };

            return recipes;
        }
    }
}
