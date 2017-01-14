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
using MG.MainMenu.Generator;

using MoreLinq;
using MG.MainMenu.DataLayer;

namespace MG.MainMenu
{
    public partial class MainMenu : Form
    {
        RecipesModel model;
        RecentRecipesModel recentRecipesModel;
        RecipesForm recipesForm;
        List<string> chosenRecipes;

        public MainMenu()
        {
            InitializeComponent();
            model = new RecipesModel();
            recentRecipesModel = new RecentRecipesModel();

            cmbOptionOne.DataSource = model.GetCategories();

            var listForCombo = new List<string> { "[пусто]" };
            listForCombo.AddRange(model.GetCategories());

            cmbOptionTwo.DataSource = listForCombo;
            cmbOptionThree.DataSource = new List<string>(listForCombo);
            cmbOptionFour.DataSource = new List<string>(listForCombo);
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            txtResult.Text = string.Empty;
            txtIngrdients.Text = string.Empty;

            var formData = new[]
            {
                new { key = cmbOptionOne.Text, value = (int)numOptionOne.Value },
                new { key = cmbOptionTwo.Text, value = (int)numOptionTwo.Value },
                new { key = cmbOptionThree.Text, value = (int)numOptionThree.Value },
                new { key = cmbOptionFour.Text, value = (int)numOptionFour.Value }
            }.ToList();

            formData.RemoveAll(i => i.key == "[пусто]");
            var filteredData = formData.DistinctBy(i => i.key);

            var categoryQuantity = new Dictionary<string, int>();

            foreach (var item in filteredData)
            {
                categoryQuantity.Add(item.key, item.value);
            }

            string[] seasons = lbxSeason.SelectedItems.Cast<string>().ToArray();

            var genParams = new GeneratorParams()
            {
                CategoryQuantity = categoryQuantity,
                Seasons = seasons
            };

            List<string> requiredIngredients;

            try
            {
                GeneratorEngine.GetMenu(model, recentRecipesModel, genParams,
                out chosenRecipes, out requiredIngredients);

                int i = 1;
                foreach (var recipe in chosenRecipes)
                {
                    txtResult.Text += $"{i++}.  {recipe}\n";
                }

                int k = 1;
                foreach (var ingr in requiredIngredients)
                {
                    txtIngrdients.Text += $"{k++}.  {ingr}\n";
                }

                btnAccept.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void MainMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            model.SaveDataToXml();
        }

        private void btnManageRecipes_Click(object sender, EventArgs e)
        {
            recipesForm = new RecipesForm(model);
            recipesForm.ShowDialog();

            // Update main menu data
            cmbOptionOne.DataSource = model.GetCategories();
            var listForCombo = new List<string> { "[пусто]" };
            listForCombo.AddRange(model.GetCategories());
            cmbOptionTwo.DataSource = listForCombo;
            cmbOptionThree.DataSource = listForCombo;
            cmbOptionFour.DataSource = listForCombo;

            if (chkSeason.CheckState == CheckState.Checked)
            {
                lbxSeason.DataSource = null;
                lbxSeason.DataSource = model.GetSeasons();
            }
        }

        private void chkSeason_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSeason.CheckState == CheckState.Checked)
            {
                lbxSeason.Enabled = true;
                lbxSeason.DataSource = model.GetSeasons();
            }
            else
            {
                lbxSeason.Enabled = true;
                lbxSeason.DataSource = null;
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            recentRecipesModel.ClearHistory();
            recentRecipesModel = new RecentRecipesModel();
            MessageBox.Show("История очищена.");
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            recentRecipesModel.SaveDataToXml(chosenRecipes, (int)numRecipesHistoryCount.Value);
            recentRecipesModel = new RecentRecipesModel();
            btnAccept.Enabled = false;
        }
    }
}
