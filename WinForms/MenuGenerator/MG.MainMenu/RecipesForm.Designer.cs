namespace MG.MainMenu
{
    partial class RecipesForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtRecipeName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.cnmSeason = new System.Windows.Forms.ComboBox();
            this.dgvIngredients = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.btnAddRecipe = new System.Windows.Forms.Button();
            this.btnChangeRecipe = new System.Windows.Forms.Button();
            this.btnDeleteRecipe = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.dgvRecipes = new System.Windows.Forms.DataGridView();
            this.btnAddCategory = new System.Windows.Forms.Button();
            this.btnAddSeasonality = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIngredients)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecipes)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnAddSeasonality);
            this.groupBox1.Controls.Add(this.btnAddCategory);
            this.groupBox1.Controls.Add(this.btnChangeRecipe);
            this.groupBox1.Controls.Add(this.btnAddRecipe);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.dgvIngredients);
            this.groupBox1.Controls.Add(this.cnmSeason);
            this.groupBox1.Controls.Add(this.cmbCategory);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtRecipeName);
            this.groupBox1.Location = new System.Drawing.Point(373, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(314, 371);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Добавить/Изменить рецепт";
            // 
            // txtRecipeName
            // 
            this.txtRecipeName.Location = new System.Drawing.Point(127, 36);
            this.txtRecipeName.Name = "txtRecipeName";
            this.txtRecipeName.Size = new System.Drawing.Size(181, 20);
            this.txtRecipeName.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Название";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(47, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Категория";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(47, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Сезонность";
            // 
            // cmbCategory
            // 
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Location = new System.Drawing.Point(127, 62);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(156, 21);
            this.cmbCategory.TabIndex = 1;
            // 
            // cnmSeason
            // 
            this.cnmSeason.FormattingEnabled = true;
            this.cnmSeason.Location = new System.Drawing.Point(127, 89);
            this.cnmSeason.Name = "cnmSeason";
            this.cnmSeason.Size = new System.Drawing.Size(156, 21);
            this.cnmSeason.TabIndex = 6;
            // 
            // dgvIngredients
            // 
            this.dgvIngredients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIngredients.Location = new System.Drawing.Point(7, 139);
            this.dgvIngredients.Name = "dgvIngredients";
            this.dgvIngredients.Size = new System.Drawing.Size(301, 197);
            this.dgvIngredients.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 123);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Ингредиенты";
            // 
            // btnAddRecipe
            // 
            this.btnAddRecipe.Location = new System.Drawing.Point(233, 342);
            this.btnAddRecipe.Name = "btnAddRecipe";
            this.btnAddRecipe.Size = new System.Drawing.Size(75, 23);
            this.btnAddRecipe.TabIndex = 9;
            this.btnAddRecipe.Text = "Добавить";
            this.btnAddRecipe.UseVisualStyleBackColor = true;
            // 
            // btnChangeRecipe
            // 
            this.btnChangeRecipe.Enabled = false;
            this.btnChangeRecipe.Location = new System.Drawing.Point(152, 342);
            this.btnChangeRecipe.Name = "btnChangeRecipe";
            this.btnChangeRecipe.Size = new System.Drawing.Size(75, 23);
            this.btnChangeRecipe.TabIndex = 10;
            this.btnChangeRecipe.Text = "Изменить";
            this.btnChangeRecipe.UseVisualStyleBackColor = true;
            // 
            // btnDeleteRecipe
            // 
            this.btnDeleteRecipe.Enabled = false;
            this.btnDeleteRecipe.Location = new System.Drawing.Point(292, 354);
            this.btnDeleteRecipe.Name = "btnDeleteRecipe";
            this.btnDeleteRecipe.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteRecipe.TabIndex = 11;
            this.btnDeleteRecipe.Text = "Удалить";
            this.btnDeleteRecipe.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Рецепты";
            // 
            // dgvRecipes
            // 
            this.dgvRecipes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRecipes.Location = new System.Drawing.Point(13, 29);
            this.dgvRecipes.Name = "dgvRecipes";
            this.dgvRecipes.Size = new System.Drawing.Size(354, 319);
            this.dgvRecipes.TabIndex = 13;
            // 
            // btnAddCategory
            // 
            this.btnAddCategory.Location = new System.Drawing.Point(288, 62);
            this.btnAddCategory.Name = "btnAddCategory";
            this.btnAddCategory.Size = new System.Drawing.Size(19, 21);
            this.btnAddCategory.TabIndex = 14;
            this.btnAddCategory.Text = "+";
            this.btnAddCategory.UseVisualStyleBackColor = true;
            // 
            // btnAddSeasonality
            // 
            this.btnAddSeasonality.Location = new System.Drawing.Point(288, 89);
            this.btnAddSeasonality.Name = "btnAddSeasonality";
            this.btnAddSeasonality.Size = new System.Drawing.Size(19, 21);
            this.btnAddSeasonality.TabIndex = 15;
            this.btnAddSeasonality.Text = "+";
            this.btnAddSeasonality.UseVisualStyleBackColor = true;
            // 
            // RecipesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(699, 395);
            this.Controls.Add(this.btnDeleteRecipe);
            this.Controls.Add(this.dgvRecipes);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBox1);
            this.Name = "RecipesForm";
            this.Text = "Управление рецептами";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIngredients)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecipes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cnmSeason;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtRecipeName;
        private System.Windows.Forms.Button btnAddRecipe;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgvIngredients;
        private System.Windows.Forms.Button btnDeleteRecipe;
        private System.Windows.Forms.Button btnChangeRecipe;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgvRecipes;
        private System.Windows.Forms.Button btnAddSeasonality;
        private System.Windows.Forms.Button btnAddCategory;
    }
}