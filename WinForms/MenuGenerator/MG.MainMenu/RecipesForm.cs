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

            AutoCompleteStringCollection availableIngredients = new AutoCompleteStringCollection();
            availableIngredients.AddRange(model.GetAvailableIngredients());
            txtIngredientName.AutoCompleteCustomSource = availableIngredients;
            txtIngredientName.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtIngredientName.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

        private void dgvRecipes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnChangeRecipe.Enabled = true;

            txtRecipeName.Text = dgvRecipes.CurrentRow.Cells["Name"].Value.ToString();
            cmbCategory.Text = dgvRecipes.CurrentRow.Cells["Category"].Value.ToString();
            cmbSeason.Text = dgvRecipes.CurrentRow.Cells["Seasonality"].Value.ToString();

            ingredientsSet = model.GetRecipeIngredients(txtRecipeName.Text);
            dgvIngredients.DataSource = ingredientsSet;
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

                AutoCompleteStringCollection availableIngredients = new AutoCompleteStringCollection();
                availableIngredients.AddRange(model.GetAvailableIngredients());
                txtIngredientName.AutoCompleteCustomSource = availableIngredients;
                txtIngredientName.AutoCompleteMode = AutoCompleteMode.Suggest;
                txtIngredientName.AutoCompleteSource = AutoCompleteSource.CustomSource;
            }
        }

        private void btnDeleteRecipe_Click(object sender, EventArgs e)
        {
            model.DeleteRecipe(dgvRecipes.CurrentRow);

            recipesSet = new BindingList<RecipeView>(RecipeView.GetRecipesView(model));
            dgvRecipes.DataSource = recipesSet;

            ClearForm();
        }

        private void EditMenuItem_Click(object sender, EventArgs e)
        {
            var editForm = new EditIngredForm(model,
                dgvIngredients.CurrentRow.Cells[0].Value.ToString(),
                (double)dgvIngredients.CurrentRow.Cells[1].Value,
                dgvIngredients.CurrentRow.Cells[2].Value.ToString());

            if (editForm.ShowDialog() == DialogResult.OK)
            {
                var index = dgvIngredients.CurrentRow.Index;
                if (editForm.txtIngredientName.Text == string.Empty)
                {
                    MessageBox.Show("Не задано название ингредиента.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (editForm.txtIngredientName.Text != ingredientsSet[index].Name)
                {
                    if (ingredientsSet.Any(i => i.Name == editForm.txtIngredientName.Text))
                    {
                        MessageBox.Show("Ингредиент с таким названием уже добавлен.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (editForm.numAmount.Value == 0)
                {
                    MessageBox.Show("Не задано количество.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (editForm.cmbUnit.Text == string.Empty)
                {
                    MessageBox.Show("Не задана единица измерения.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    ingredientsSet[index].Name = editForm.txtIngredientName.Text;
                    ingredientsSet[index].Amount = (double)editForm.numAmount.Value;
                    ingredientsSet[index].Unit = editForm.cmbUnit.Text;
                }
            }
        }

        private void DeleteMenuItem_Click(object sender, EventArgs e)
        {
            ingredientsSet.RemoveAt(dgvIngredients.CurrentRow.Index);
        }

        private void btnChangeRecipe_Click(object sender, EventArgs e)
        {
            if (txtRecipeName.Text == string.Empty)
            {
                MessageBox.Show("Не задано название блюда.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                model.ChangeRecipe(dgvRecipes.CurrentRow, txtRecipeName.Text,
                    cmbCategory.Text, cmbSeason.Text, ingredientsSet);

                recipesSet = new BindingList<RecipeView>(RecipeView.GetRecipesView(model));
                dgvRecipes.DataSource = recipesSet;

                ClearForm();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void ClearForm()
        {
            txtRecipeName.Text = string.Empty;
            txtIngredientName.Text = string.Empty;
            ingredientsSet = new BindingList<IngredientView>();
            dgvIngredients.DataSource = ingredientsSet;

            btnChangeRecipe.Enabled = false;
        }
    }
}
