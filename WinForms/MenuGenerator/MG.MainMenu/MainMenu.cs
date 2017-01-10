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
            cmbOptionThree.DataSource = new List<string>(listForCombo);
            cmbOptionFour.DataSource = new List<string>(listForCombo);
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
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

            string season = lbxSeason.SelectedItem.ToString();       

            var genParams = new GeneratorParams()
            {
                CategoryQuantity = categoryQuantity,
                Season = season
            };

            string[] result = GeneratorEngine.GetMenu(model, genParams);
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
    }
}
