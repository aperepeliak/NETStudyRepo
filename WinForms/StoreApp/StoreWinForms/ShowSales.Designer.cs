namespace StoreWinForms
{
    partial class ShowSales
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dgvSales = new System.Windows.Forms.DataGridView();
            this.dgvSalesPos = new System.Windows.Forms.DataGridView();
            this.lblSale = new System.Windows.Forms.Label();
            this.lblSalePos = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSales)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalesPos)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 64F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 36F));
            this.tableLayoutPanel1.Controls.Add(this.dgvSales, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dgvSalesPos, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnClose, 1, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 29);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 91.53005F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.469945F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(700, 349);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // dgvSales
            // 
            this.dgvSales.AllowUserToAddRows = false;
            this.dgvSales.AllowUserToDeleteRows = false;
            this.dgvSales.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSales.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSales.Location = new System.Drawing.Point(3, 3);
            this.dgvSales.Name = "dgvSales";
            this.dgvSales.ReadOnly = true;
            this.tableLayoutPanel1.SetRowSpan(this.dgvSales, 2);
            this.dgvSales.Size = new System.Drawing.Size(442, 343);
            this.dgvSales.TabIndex = 0;
            // 
            // dgvSalesPos
            // 
            this.dgvSalesPos.AllowUserToAddRows = false;
            this.dgvSalesPos.AllowUserToDeleteRows = false;
            this.dgvSalesPos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSalesPos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSalesPos.Location = new System.Drawing.Point(451, 3);
            this.dgvSalesPos.Name = "dgvSalesPos";
            this.dgvSalesPos.ReadOnly = true;
            this.dgvSalesPos.Size = new System.Drawing.Size(246, 313);
            this.dgvSalesPos.TabIndex = 1;
            // 
            // lblSale
            // 
            this.lblSale.AutoSize = true;
            this.lblSale.Location = new System.Drawing.Point(15, 10);
            this.lblSale.Name = "lblSale";
            this.lblSale.Size = new System.Drawing.Size(33, 13);
            this.lblSale.TabIndex = 1;
            this.lblSale.Text = "Sales";
            // 
            // lblSalePos
            // 
            this.lblSalePos.AutoSize = true;
            this.lblSalePos.Location = new System.Drawing.Point(463, 9);
            this.lblSalePos.Name = "lblSalePos";
            this.lblSalePos.Size = new System.Drawing.Size(73, 13);
            this.lblSalePos.TabIndex = 2;
            this.lblSalePos.Text = "Sale Positions";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(622, 322);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // ShowSales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 390);
            this.Controls.Add(this.lblSalePos);
            this.Controls.Add(this.lblSale);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ShowSales";
            this.Text = "ShowSales";
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSales)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSalesPos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView dgvSales;
        private System.Windows.Forms.DataGridView dgvSalesPos;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblSale;
        private System.Windows.Forms.Label lblSalePos;
    }
}