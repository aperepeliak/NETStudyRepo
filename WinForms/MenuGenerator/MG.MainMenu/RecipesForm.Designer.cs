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
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnAddIngredient = new System.Windows.Forms.Button();
            this.cmbUnit = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.numAmount = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.txtIngredientName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnChangeRecipe = new System.Windows.Forms.Button();
            this.btnAddRecipe = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.dgvIngredients = new System.Windows.Forms.DataGridView();
            this.cmbSeason = new System.Windows.Forms.ComboBox();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtRecipeName = new System.Windows.Forms.TextBox();
            this.btnDeleteRecipe = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.dgvRecipes = new System.Windows.Forms.DataGridView();
            this.contextMenuIngredients = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.EditMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIngredients)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecipes)).BeginInit();
            this.contextMenuIngredients.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnAddIngredient);
            this.groupBox1.Controls.Add(this.cmbUnit);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.numAmount);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtIngredientName);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.btnChangeRecipe);
            this.groupBox1.Controls.Add(this.btnAddRecipe);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.dgvIngredients);
            this.groupBox1.Controls.Add(this.cmbSeason);
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
            // btnAddIngredient
            // 
            this.btnAddIngredient.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnAddIngredient.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnAddIngredient.Location = new System.Drawing.Point(265, 134);
            this.btnAddIngredient.Name = "btnAddIngredient";
            this.btnAddIngredient.Size = new System.Drawing.Size(43, 49);
            this.btnAddIngredient.TabIndex = 23;
            this.btnAddIngredient.Text = "+";
            this.btnAddIngredient.UseVisualStyleBackColor = true;
            this.btnAddIngredient.Click += new System.EventHandler(this.btnAddIngredient_Click);
            // 
            // cmbUnit
            // 
            this.cmbUnit.FormattingEnabled = true;
            this.cmbUnit.Location = new System.Drawing.Point(206, 162);
            this.cmbUnit.Name = "cmbUnit";
            this.cmbUnit.Size = new System.Drawing.Size(53, 21);
            this.cmbUnit.TabIndex = 21;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(155, 166);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "Ед. изм.";
            // 
            // numAmount
            // 
            this.numAmount.DecimalPlaces = 2;
            this.numAmount.Increment = new decimal(new int[] {
            25,
            0,
            0,
            131072});
            this.numAmount.Location = new System.Drawing.Point(95, 162);
            this.numAmount.Name = "numAmount";
            this.numAmount.Size = new System.Drawing.Size(50, 20);
            this.numAmount.TabIndex = 19;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(23, 167);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "Количество";
            // 
            // txtIngredientName
            // 
            this.txtIngredientName.Location = new System.Drawing.Point(95, 136);
            this.txtIngredientName.Name = "txtIngredientName";
            this.txtIngredientName.Size = new System.Drawing.Size(164, 20);
            this.txtIngredientName.TabIndex = 17;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(23, 139);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Название";
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
            this.btnChangeRecipe.Click += new System.EventHandler(this.btnChangeRecipe_Click);
            // 
            // btnAddRecipe
            // 
            this.btnAddRecipe.Location = new System.Drawing.Point(233, 342);
            this.btnAddRecipe.Name = "btnAddRecipe";
            this.btnAddRecipe.Size = new System.Drawing.Size(75, 23);
            this.btnAddRecipe.TabIndex = 9;
            this.btnAddRecipe.Text = "Добавить";
            this.btnAddRecipe.UseVisualStyleBackColor = true;
            this.btnAddRecipe.Click += new System.EventHandler(this.btnAddRecipe_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 115);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Ингредиенты";
            // 
            // dgvIngredients
            // 
            this.dgvIngredients.AllowUserToAddRows = false;
            this.dgvIngredients.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvIngredients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIngredients.ContextMenuStrip = this.contextMenuIngredients;
            this.dgvIngredients.Location = new System.Drawing.Point(7, 190);
            this.dgvIngredients.Name = "dgvIngredients";
            this.dgvIngredients.ReadOnly = true;
            this.dgvIngredients.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvIngredients.Size = new System.Drawing.Size(301, 146);
            this.dgvIngredients.TabIndex = 7;
            // 
            // cmbSeason
            // 
            this.cmbSeason.FormattingEnabled = true;
            this.cmbSeason.Location = new System.Drawing.Point(95, 76);
            this.cmbSeason.Name = "cmbSeason";
            this.cmbSeason.Size = new System.Drawing.Size(180, 21);
            this.cmbSeason.TabIndex = 6;
            // 
            // cmbCategory
            // 
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Location = new System.Drawing.Point(95, 49);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(180, 21);
            this.cmbCategory.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Сезонность";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Категория";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Название";
            // 
            // txtRecipeName
            // 
            this.txtRecipeName.Location = new System.Drawing.Point(95, 23);
            this.txtRecipeName.Name = "txtRecipeName";
            this.txtRecipeName.Size = new System.Drawing.Size(180, 20);
            this.txtRecipeName.TabIndex = 0;
            // 
            // btnDeleteRecipe
            // 
            this.btnDeleteRecipe.Location = new System.Drawing.Point(292, 354);
            this.btnDeleteRecipe.Name = "btnDeleteRecipe";
            this.btnDeleteRecipe.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteRecipe.TabIndex = 11;
            this.btnDeleteRecipe.Text = "Удалить";
            this.btnDeleteRecipe.UseVisualStyleBackColor = true;
            this.btnDeleteRecipe.Click += new System.EventHandler(this.btnDeleteRecipe_Click);
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
            this.dgvRecipes.AllowUserToAddRows = false;
            this.dgvRecipes.AllowUserToDeleteRows = false;
            this.dgvRecipes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRecipes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRecipes.Location = new System.Drawing.Point(13, 29);
            this.dgvRecipes.Name = "dgvRecipes";
            this.dgvRecipes.ReadOnly = true;
            this.dgvRecipes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRecipes.Size = new System.Drawing.Size(354, 319);
            this.dgvRecipes.TabIndex = 13;
            this.dgvRecipes.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRecipes_CellDoubleClick);
            // 
            // contextMenuIngredients
            // 
            this.contextMenuIngredients.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.EditMenuItem,
            this.DeleteMenuItem});
            this.contextMenuIngredients.Name = "contextMenuIngredients";
            this.contextMenuIngredients.Size = new System.Drawing.Size(129, 48);
            // 
            // EditMenuItem
            // 
            this.EditMenuItem.Name = "EditMenuItem";
            this.EditMenuItem.Size = new System.Drawing.Size(152, 22);
            this.EditMenuItem.Text = "Изменить";
            this.EditMenuItem.Click += new System.EventHandler(this.EditMenuItem_Click);
            // 
            // DeleteMenuItem
            // 
            this.DeleteMenuItem.Name = "DeleteMenuItem";
            this.DeleteMenuItem.Size = new System.Drawing.Size(152, 22);
            this.DeleteMenuItem.Text = "Удалить";
            this.DeleteMenuItem.Click += new System.EventHandler(this.DeleteMenuItem_Click);
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
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RecipesForm";
            this.Text = "Управление рецептами";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIngredients)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecipes)).EndInit();
            this.contextMenuIngredients.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbSeason;
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
        private System.Windows.Forms.NumericUpDown numAmount;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtIngredientName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnAddIngredient;
        private System.Windows.Forms.ComboBox cmbUnit;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ContextMenuStrip contextMenuIngredients;
        private System.Windows.Forms.ToolStripMenuItem EditMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DeleteMenuItem;
    }
}