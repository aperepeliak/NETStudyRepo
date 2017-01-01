namespace MG.MainMenu
{
    partial class MainMenu
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
            this.btnGenerate = new System.Windows.Forms.Button();
            this.chkSeason = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.numSecondDishes = new System.Windows.Forms.NumericUpDown();
            this.numFirstDishes = new System.Windows.Forms.NumericUpDown();
            this.txtResult = new System.Windows.Forms.RichTextBox();
            this.btnAccept = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtIngrdients = new System.Windows.Forms.RichTextBox();
            this.btnManageRecipes = new System.Windows.Forms.Button();
            this.btnManageIngrds = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSecondDishes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFirstDishes)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnGenerate);
            this.groupBox1.Controls.Add(this.chkSeason);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnAccept);
            this.groupBox1.Controls.Add(this.numSecondDishes);
            this.groupBox1.Controls.Add(this.numFirstDishes);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(258, 178);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Параметры генератора";
            // 
            // btnGenerate
            // 
            this.btnGenerate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGenerate.Location = new System.Drawing.Point(142, 149);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(110, 23);
            this.btnGenerate.TabIndex = 5;
            this.btnGenerate.Text = "Сгенерировать";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // chkSeason
            // 
            this.chkSeason.AutoSize = true;
            this.chkSeason.Location = new System.Drawing.Point(7, 112);
            this.chkSeason.Name = "chkSeason";
            this.chkSeason.Size = new System.Drawing.Size(143, 17);
            this.chkSeason.TabIndex = 4;
            this.chkSeason.Text = "Учитывать сезонность";
            this.chkSeason.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(73, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "вторых блюд";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(73, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "первых блюд";
            // 
            // numSecondDishes
            // 
            this.numSecondDishes.Location = new System.Drawing.Point(6, 67);
            this.numSecondDishes.Name = "numSecondDishes";
            this.numSecondDishes.Size = new System.Drawing.Size(61, 20);
            this.numSecondDishes.TabIndex = 1;
            this.numSecondDishes.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // numFirstDishes
            // 
            this.numFirstDishes.Location = new System.Drawing.Point(6, 41);
            this.numFirstDishes.Name = "numFirstDishes";
            this.numFirstDishes.Size = new System.Drawing.Size(61, 20);
            this.numFirstDishes.TabIndex = 0;
            this.numFirstDishes.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // txtResult
            // 
            this.txtResult.Location = new System.Drawing.Point(12, 218);
            this.txtResult.Name = "txtResult";
            this.txtResult.Size = new System.Drawing.Size(258, 195);
            this.txtResult.TabIndex = 1;
            this.txtResult.Text = "";
            // 
            // btnAccept
            // 
            this.btnAccept.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAccept.Enabled = false;
            this.btnAccept.Location = new System.Drawing.Point(7, 149);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(96, 23);
            this.btnAccept.TabIndex = 2;
            this.btnAccept.Text = "Принимается";
            this.btnAccept.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 197);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Результат:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(279, 197);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(150, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Необходимые ингридиенты:";
            // 
            // txtIngrdients
            // 
            this.txtIngrdients.Location = new System.Drawing.Point(276, 218);
            this.txtIngrdients.Name = "txtIngrdients";
            this.txtIngrdients.Size = new System.Drawing.Size(258, 195);
            this.txtIngrdients.TabIndex = 6;
            this.txtIngrdients.Text = "";
            // 
            // btnManageRecipes
            // 
            this.btnManageRecipes.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnManageRecipes.Location = new System.Drawing.Point(345, 23);
            this.btnManageRecipes.Name = "btnManageRecipes";
            this.btnManageRecipes.Size = new System.Drawing.Size(190, 60);
            this.btnManageRecipes.TabIndex = 7;
            this.btnManageRecipes.Text = "Управление рецептами";
            this.btnManageRecipes.UseVisualStyleBackColor = true;
            // 
            // btnManageIngrds
            // 
            this.btnManageIngrds.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnManageIngrds.Location = new System.Drawing.Point(345, 89);
            this.btnManageIngrds.Name = "btnManageIngrds";
            this.btnManageIngrds.Size = new System.Drawing.Size(190, 60);
            this.btnManageIngrds.TabIndex = 8;
            this.btnManageIngrds.Text = "Управление ингридиентами";
            this.btnManageIngrds.UseVisualStyleBackColor = true;
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(547, 427);
            this.Controls.Add(this.btnManageIngrds);
            this.Controls.Add(this.btnManageRecipes);
            this.Controls.Add(this.txtIngrdients);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "MainMenu";
            this.Text = "Добро пожаловать в МенюГенератор";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSecondDishes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numFirstDishes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkSeason;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numSecondDishes;
        private System.Windows.Forms.NumericUpDown numFirstDishes;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.RichTextBox txtResult;
        private System.Windows.Forms.Button btnAccept;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox txtIngrdients;
        private System.Windows.Forms.Button btnManageRecipes;
        private System.Windows.Forms.Button btnManageIngrds;
    }
}

