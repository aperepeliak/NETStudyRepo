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
        RecipesForm recipesForm;

        public MainMenu()
        {
            InitializeComponent();
            model = new RecipesModel();

            cmbOptionOne.DataSource = model.GetCategories();
            

            var listForCombo = new List<string> { "[пусто]" };
            listForCombo.AddRange(model.GetCategories());

            cmbOptionTwo.DataSource = listForCombo;
            cmbOptionThree.DataSource = listForCombo;
            cmbOptionFour.DataSource = listForCombo;


        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            MessageBox.Show(model.Recipes[0].Name);
        }

        private void MainMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            model.SaveDataToXml();
        }

        private void btnManageRecipes_Click(object sender, EventArgs e)
        {
            recipesForm = new RecipesForm(model);
            recipesForm.ShowDialog();
        }

        private void chkSeason_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSeason.CheckState == CheckState.Checked)
            {
                lbxSeason.Enabled = true;
                lbxSeason.DataSource = model.GetSeasons();
            } else
            {
                lbxSeason.Enabled = true;
                lbxSeason.DataSource = null;
            }
        }
    }
}
