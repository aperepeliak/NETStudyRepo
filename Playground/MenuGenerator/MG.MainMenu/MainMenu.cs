using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MG.Entities;
using System.Xml.Linq;
using System.IO;
using System.Xml.Serialization;

namespace MG.MainMenu
{
    public partial class MainMenu : Form
    {
        List<Recipe> recipes = null;

        public MainMenu()
        {
            InitializeComponent();


            if (!File.Exists("Recipes.xml"))
            {
                recipes = SeedData();
                var document = new XDocument();

                var rcps = new XElement("Recipes");

                var elements =
                    from r in recipes
                    select new XElement("Recipe",
                        new XAttribute("Name", r.Name),
                        new XAttribute("Category", r.DishCategory.Name),
                        new XAttribute("Seasonality", r.Seasonality.Name),

                        new XElement("Ingredients",
                            from i in r.Ingredients
                            select new XElement
                                ("IngredientInfo",
                                    new XElement
                                        ("Ingredient",
                                    new XAttribute("Name", i.Ingredient.Name),
                                    new XAttribute("Units", i.Ingredient.Units.Name)
                                        ),
                            new XElement("Amount", i.Amount)
                                )
                            )   
                        );

                rcps.Add(elements);
                document.Add(rcps);
                document.Save("Recipes.xml");
            }
        }

        private List<Recipe> SeedData()
        {
            var fallWinter = new Season() { Name = "FallWinter" };
            var springSummer = new Season() { Name = "SpringSummer" };
            var allSeason = new Season() { Name = "AllSeason" };

            var firstDishes = new Category() { Name = "FirstDishes" };
            var secondDishes = new Category() {Name = "SecondDishes" };

            var kilos = new Unit() { Name = "кг" };
            var litres = new Unit() { Name = "л" };

            recipes = new List<Recipe>()
            {
                new Recipe()
                {
                    DishCategory = secondDishes, Seasonality = allSeason,
                    Name = "Mashed potato",
                    Ingredients = new List<IngredientInfo>()
                    {
                        new IngredientInfo()
                        {
                            Ingredient = new Ingredient() {Name = "Картофель", Units = kilos },
                            Amount = 1.5
                        }
                    }
                },
                new Recipe()
                {
                    DishCategory = firstDishes, Seasonality = allSeason,
                    Name = "Уха",
                    Ingredients = new List<IngredientInfo>()
                    {
                        new IngredientInfo()
                        {
                            Ingredient = new Ingredient() {Name = "Картофель", Units = kilos },
                            Amount = 0.2
                        },
                        new IngredientInfo()
                        {
                            Ingredient = new Ingredient() {Name = "Рыба", Units = kilos },
                            Amount = 0.9
                        },
                        new IngredientInfo()
                        {
                            Ingredient = new Ingredient() {Name = "Рис", Units = kilos },
                            Amount = 0.1
                        }
                    }
                }
            };


            return recipes;
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            try
            {
                var document = XDocument.Load("Recipes.xml");
                if (document.Root == null)
                    throw new Exception("У вас пока не добавлено ни одного рецепта!");
                else
                {
                    var query =
                        from recipe in document.Element("Recipes").Elements("Recipe")
                        select new Recipe
                        {
                            Name = recipe.Name.ToString(),
                            Seasonality = new Season() { Name = recipe.Attribute("Seasonality").Value },
                             DishCategory = new Category() { Name = recipe.Attribute("DishCategory").Value }
                        };

                     recipes = query.ToList();

                }
                    
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
        }
    }
}
