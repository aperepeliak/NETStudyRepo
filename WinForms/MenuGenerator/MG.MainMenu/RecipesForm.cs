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
        private RecipesModel model;

        public RecipesForm(RecipesModel model)
        {
            InitializeComponent();
            this.model = model;

            dgvRecipes.DataSource = RecipesInfo.GetRecipesInfo(model);
        }
    }
}
