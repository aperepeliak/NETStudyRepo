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
using System.Globalization;

namespace MG.MainMenu
{
    public partial class MainMenu : Form
    {
        RecipesModel model;

        public MainMenu()
        {
            InitializeComponent();
            model = new RecipesModel();
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
                    recipes = model.GetDataFromXml();
                    MessageBox.Show(recipes[1].Name);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка");
            }
        }

        private void MainMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            model.SaveDataToXml();
        }
    }
}
