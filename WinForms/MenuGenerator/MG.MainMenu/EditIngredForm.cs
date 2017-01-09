using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MG.MainMenu
{
    public partial class EditIngredForm : Form
    {
        RecipesModel model;

        public EditIngredForm(RecipesModel model, string name, double amount, string unit)
        {
            InitializeComponent();

            this.model = model;

            txtIngredientName.Text = name;
            numAmount.Value = (decimal)amount;
            cmbUnit.Text = unit;

            cmbUnit.DataSource = model.GetUnits();

            AutoCompleteStringCollection availableIngredients = new AutoCompleteStringCollection();
            availableIngredients.AddRange(model.GetAvailableIngredients());
            txtIngredientName.AutoCompleteCustomSource = availableIngredients;
            txtIngredientName.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtIngredientName.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }
    }
}
