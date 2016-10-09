namespace Shop.WinForm
{
    partial class FormManipData
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
            this.lblGoodName = new System.Windows.Forms.Label();
            this.txtGoodName = new System.Windows.Forms.TextBox();
            this.lblManuf = new System.Windows.Forms.Label();
            this.cmbManuf = new System.Windows.Forms.ComboBox();
            this.cmbCat = new System.Windows.Forms.ComboBox();
            this.lblCat = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.lblCount = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.txtCount = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblGoodName
            // 
            this.lblGoodName.AutoSize = true;
            this.lblGoodName.Location = new System.Drawing.Point(13, 13);
            this.lblGoodName.Name = "lblGoodName";
            this.lblGoodName.Size = new System.Drawing.Size(64, 13);
            this.lblGoodName.TabIndex = 0;
            this.lblGoodName.Text = "Good Name";
            // 
            // txtGoodName
            // 
            this.txtGoodName.Location = new System.Drawing.Point(12, 29);
            this.txtGoodName.Name = "txtGoodName";
            this.txtGoodName.Size = new System.Drawing.Size(322, 20);
            this.txtGoodName.TabIndex = 1;
            // 
            // lblManuf
            // 
            this.lblManuf.AutoSize = true;
            this.lblManuf.Location = new System.Drawing.Point(16, 71);
            this.lblManuf.Name = "lblManuf";
            this.lblManuf.Size = new System.Drawing.Size(70, 13);
            this.lblManuf.TabIndex = 2;
            this.lblManuf.Text = "Manufacturer";
            // 
            // cmbManuf
            // 
            this.cmbManuf.FormattingEnabled = true;
            this.cmbManuf.Location = new System.Drawing.Point(12, 88);
            this.cmbManuf.Name = "cmbManuf";
            this.cmbManuf.Size = new System.Drawing.Size(173, 21);
            this.cmbManuf.TabIndex = 3;
            // 
            // cmbCat
            // 
            this.cmbCat.FormattingEnabled = true;
            this.cmbCat.Location = new System.Drawing.Point(12, 146);
            this.cmbCat.Name = "cmbCat";
            this.cmbCat.Size = new System.Drawing.Size(173, 21);
            this.cmbCat.TabIndex = 5;
            // 
            // lblCat
            // 
            this.lblCat.AutoSize = true;
            this.lblCat.Location = new System.Drawing.Point(16, 129);
            this.lblCat.Name = "lblCat";
            this.lblCat.Size = new System.Drawing.Size(49, 13);
            this.lblCat.TabIndex = 4;
            this.lblCat.Text = "Category";
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new System.Drawing.Point(16, 193);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(31, 13);
            this.lblPrice.TabIndex = 6;
            this.lblPrice.Text = "Price";
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.Location = new System.Drawing.Point(126, 193);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(46, 13);
            this.lblCount.TabIndex = 7;
            this.lblCount.Text = "Quantity";
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(12, 209);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(100, 20);
            this.txtPrice.TabIndex = 8;
            // 
            // txtCount
            // 
            this.txtCount.Location = new System.Drawing.Point(118, 209);
            this.txtCount.Name = "txtCount";
            this.txtCount.Size = new System.Drawing.Size(100, 20);
            this.txtCount.TabIndex = 9;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(13, 276);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(143, 276);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // FormManipData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(346, 311);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtCount);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.cmbCat);
            this.Controls.Add(this.lblCat);
            this.Controls.Add(this.cmbManuf);
            this.Controls.Add(this.lblManuf);
            this.Controls.Add(this.txtGoodName);
            this.Controls.Add(this.lblGoodName);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormManipData";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Data Manipulation";
            this.Load += new System.EventHandler(this.FormManipData_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblGoodName;
        private System.Windows.Forms.TextBox txtGoodName;
        private System.Windows.Forms.Label lblManuf;
        private System.Windows.Forms.ComboBox cmbManuf;
        private System.Windows.Forms.ComboBox cmbCat;
        private System.Windows.Forms.Label lblCat;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.TextBox txtCount;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}