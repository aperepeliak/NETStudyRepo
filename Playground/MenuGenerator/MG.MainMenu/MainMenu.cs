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
                            from i in r.Ingridients
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
            var fallWinter = new Season() { Id = 1, Name = "FallWinter" };
            var springSummer = new Season() { Id = 2, Name = "SpringSummer" };
            var allSeason = new Season() { Id = 3, Name = "AllSeason" };

            var firstDishes = new Category() { Id = 1, Name = "FirstDishes" };
            var secondDishes = new Category() { Id = 2, Name = "SecondDishes" };

            var kilos = new Unit() { Id = 1, Name = "кг" };
            var litres = new Unit() { Id = 2, Name = "л" };

            recipes = new List<Recipe>()
            {
                new Recipe()
                {
                    Id = 1, DishCategory = secondDishes, Seasonality = allSeason,
                    Name = "Mashed potato",
                    Ingridients = new List<IngredientInfo>()
                    {
                        new IngredientInfo()
                        {
                            Id = 1,
                            Ingredient = new Ingredient() {Id = 1, Name = "Картофель", Units = kilos },
                            Amount = 1.5
                        }
                    }
                },
                new Recipe()
                {
                    Id = 2, DishCategory = firstDishes, Seasonality = allSeason,
                    Name = "Уха",
                    Ingridients = new List<IngredientInfo>()
                    {
                        new IngredientInfo()
                        {
                            Id = 1,
                            Ingredient = new Ingredient() {Id = 1, Name = "Картофель", Units = kilos },
                            Amount = 0.2
                        },
                        new IngredientInfo()
                        {
                            Id = 2,
                            Ingredient = new Ingredient() {Id = 2, Name = "Рыба", Units = kilos },
                            Amount = 0.9
                        },
                        new IngredientInfo()
                        {
                            Id = 3,
                            Ingredient = new Ingredient() {Id = 3, Name = "Рис", Units = kilos },
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
                    MessageBox.Show("Loaded");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
        }
    }
}
