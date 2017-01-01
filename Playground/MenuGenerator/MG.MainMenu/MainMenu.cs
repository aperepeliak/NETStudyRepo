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
                using (Stream fStream = new FileStream("Recipes.xml",
                 FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    XmlSerializer xmlFormat = new XmlSerializer(typeof(List<Recipe>));
                    xmlFormat.Serialize(fStream, recipes);
                }
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
                    Ingridients = new List<IngridientInfo>()
                    {
                        new IngridientInfo()
                        {
                            Id = 1,
                            Ingridient = new Ingridient() {Id = 1, Name = "Картофель", UnitMeasure = kilos },
                            Amount = 1.5
                        }
                    }
                },
                new Recipe()
                {
                    Id = 2, DishCategory = firstDishes, Seasonality = allSeason,
                    Name = "Уха",
                    Ingridients = new List<IngridientInfo>()
                    {
                        new IngridientInfo()
                        {
                            Id = 1,
                            Ingridient = new Ingridient() {Id = 1, Name = "Картофель", UnitMeasure = kilos },
                            Amount = 0.2
                        },
                        new IngridientInfo()
                        {
                            Id = 2,
                            Ingridient = new Ingridient() {Id = 2, Name = "Рыба", UnitMeasure = kilos },
                            Amount = 0.9
                        },
                        new IngridientInfo()
                        {
                            Id = 3,
                            Ingridient = new Ingridient() {Id = 3, Name = "Рис", UnitMeasure = kilos },
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
        }
    }
}
