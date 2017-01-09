using MG.MainMenu.BusinessLayer;
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
    public partial class RecipesForm : Form
    {
        RecipesModel model;
        BindingList<IngredientView> ingredientsSet;
        BindingList<RecipeView> recipesSet;

        public RecipesForm(RecipesModel model)
        {
            InitializeComponent();
            this.model = model;

            ingredientsSet = new BindingList<IngredientView>();
            recipesSet = new BindingList<RecipeView>(RecipeView.GetRecipesView(model));

            dgvRecipes.DataSource = recipesSet;
            dgvIngredients.DataSource = ingredientsSet;

            cmbCategory.DataSource = model.GetCategories();
            cmbSeason.DataSource = model.GetSeasons();
            cmbUnit.DataSource = model.GetUnits();
        }

        private void dgvRecipes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            MessageBox.Show("Test");
        }

        private void btnAddIngredient_Click(object sender, EventArgs e)
        {
            if (txtIngredientName.Text == string.Empty)
            {
                MessageBox.Show("Не задано название ингредиента.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (ingredientsSet.Any(i => i.Name == txtIngredientName.Text))
            {
                MessageBox.Show("Ингредиент с таким названием уже добавлен.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if ((double)numAmount.Value == 0)
            {
                MessageBox.Show("Не задано количество.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (cmbUnit.Text == string.Empty)
            {
                MessageBox.Show("Не задана единица измерения.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                var ingredient = new IngredientView()
                {
                    Name = txtIngredientName.Text.ToLower(),
                    Amount = (double)numAmount.Value,
                    Unit = cmbUnit.Text.ToLower()
                };

                ingredientsSet.Add(ingredient);
            }
        }

        private void btnAddRecipe_Click(object sender, EventArgs e)
        {
            if (txtRecipeName.Text == string.Empty)
            {
                MessageBox.Show("Не задано название блюда.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (model.isRecipeAlreadyExist(txtRecipeName.Text))
            {
                MessageBox.Show("Блюдо с таким названием уже существует.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (cmbCategory.Text == string.Empty)
            {
                MessageBox.Show("Не задана категория блюда.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (cmbSeason.Text == string.Empty)
            {
                MessageBox.Show("Не задана сезонность блюда.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (ingredientsSet.Count < 1)
            {
                MessageBox.Show("Блюдо должно содержать хотя бы один ингредиент.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                model.AddRecipe(txtRecipeName.Text,
                    cmbCategory.Text,
                    cmbSeason.Text,
                    ingredientsSet
                    );

                recipesSet = new BindingList<RecipeView>(RecipeView.GetRecipesView(model));
                dgvRecipes.DataSource = recipesSet;

                txtRecipeName.Text = string.Empty;
                txtIngredientName.Text = string.Empty;

                ingredientsSet = new BindingList<IngredientView>();
                dgvIngredients.DataSource = ingredientsSet;
            }
        }

        private void btnDeleteRecipe_Click(object sender, EventArgs e)
        {
            model.DeleteRecipe(dgvRecipes.CurrentRow);

            recipesSet = new BindingList<RecipeView>(RecipeView.GetRecipesView(model));
            dgvRecipes.DataSource = recipesSet;
        }
    }
}
