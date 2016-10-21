namespace StoreWinForms
{
    partial class CashierForm
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
            this.dgvGoods = new System.Windows.Forms.DataGridView();
            this.dgvCart = new System.Windows.Forms.DataGridView();
            this.lblGoods = new System.Windows.Forms.Label();
            this.lblCart = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnComplete = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnShowSales = new System.Windows.Forms.Button();
            this.lblTip = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGoods)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCart)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvGoods
            // 
            this.dgvGoods.AllowUserToAddRows = false;
            this.dgvGoods.AllowUserToDeleteRows = false;
            this.dgvGoods.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGoods.Location = new System.Drawing.Point(13, 35);
            this.dgvGoods.Name = "dgvGoods";
            this.dgvGoods.ReadOnly = true;
            this.dgvGoods.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGoods.Size = new System.Drawing.Size(499, 308);
            this.dgvGoods.TabIndex = 0;
            this.dgvGoods.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvGoods_CellMouseDoubleClick);
            // 
            // dgvCart
            // 
            this.dgvCart.AllowUserToAddRows = false;
            this.dgvCart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCart.Location = new System.Drawing.Point(519, 35);
            this.dgvCart.Name = "dgvCart";
            this.dgvCart.ReadOnly = true;
            this.dgvCart.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCart.Size = new System.Drawing.Size(453, 308);
            this.dgvCart.TabIndex = 1;
            // 
            // lblGoods
            // 
            this.lblGoods.AutoSize = true;
            this.lblGoods.Location = new System.Drawing.Point(13, 13);
            this.lblGoods.Name = "lblGoods";
            this.lblGoods.Size = new System.Drawing.Size(84, 13);
            this.lblGoods.TabIndex = 2;
            this.lblGoods.Text = "Goods Available";
            // 
            // lblCart
            // 
            this.lblCart.AutoSize = true;
            this.lblCart.Location = new System.Drawing.Point(516, 13);
            this.lblCart.Name = "lblCart";
            this.lblCart.Size = new System.Drawing.Size(63, 13);
            this.lblCart.TabIndex = 3;
            this.lblCart.Text = "Current Cart";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(549, 349);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(100, 23);
            this.btnClear.TabIndex = 5;
            this.btnClear.Text = "Clear Cart";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnComplete
            // 
            this.btnComplete.Location = new System.Drawing.Point(655, 349);
            this.btnComplete.Name = "btnComplete";
            this.btnComplete.Size = new System.Drawing.Size(100, 23);
            this.btnComplete.TabIndex = 6;
            this.btnComplete.Text = "Complete Sale";
            this.btnComplete.UseVisualStyleBackColor = true;
            this.btnComplete.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(897, 349);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 7;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnShowSales
            // 
            this.btnShowSales.Location = new System.Drawing.Point(412, 349);
            this.btnShowSales.Name = "btnShowSales";
            this.btnShowSales.Size = new System.Drawing.Size(100, 23);
            this.btnShowSales.TabIndex = 8;
            this.btnShowSales.Text = "Show all Sales";
            this.btnShowSales.UseVisualStyleBackColor = true;
            this.btnShowSales.Click += new System.EventHandler(this.btnShowSales_Click);
            // 
            // lblTip
            // 
            this.lblTip.AutoSize = true;
            this.lblTip.Location = new System.Drawing.Point(13, 353);
            this.lblTip.Name = "lblTip";
            this.lblTip.Size = new System.Drawing.Size(296, 13);
            this.lblTip.TabIndex = 9;
            this.lblTip.Text = "Tip: Doubleclick the product you would like to add to the Cart";
            // 
            // CashierForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 383);
            this.Controls.Add(this.lblTip);
            this.Controls.Add(this.btnShowSales);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnComplete);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.lblCart);
            this.Controls.Add(this.lblGoods);
            this.Controls.Add(this.dgvCart);
            this.Controls.Add(this.dgvGoods);
            this.Name = "CashierForm";
            this.Text = "CashierForm";
            this.Load += new System.EventHandler(this.CashierForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGoods)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvGoods;
        private System.Windows.Forms.DataGridView dgvCart;
        private System.Windows.Forms.Label lblGoods;
        private System.Windows.Forms.Label lblCart;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnComplete;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnShowSales;
        private System.Windows.Forms.Label lblTip;
    }
}