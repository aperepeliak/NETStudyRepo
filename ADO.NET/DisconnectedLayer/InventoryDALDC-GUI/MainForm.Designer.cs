namespace InventoryDALDC_GUI
{
    partial class MainForm
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
            this.lblInv = new System.Windows.Forms.Label();
            this.invGrid = new System.Windows.Forms.DataGridView();
            this.btnUpdateInv = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.invGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // lblInv
            // 
            this.lblInv.AutoSize = true;
            this.lblInv.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInv.Location = new System.Drawing.Point(13, 13);
            this.lblInv.Name = "lblInv";
            this.lblInv.Size = new System.Drawing.Size(94, 22);
            this.lblInv.TabIndex = 0;
            this.lblInv.Text = "Inventory";
            // 
            // invGrid
            // 
            this.invGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.invGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.invGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.invGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.invGrid.Location = new System.Drawing.Point(13, 38);
            this.invGrid.Name = "invGrid";
            this.invGrid.Size = new System.Drawing.Size(677, 251);
            this.invGrid.TabIndex = 1;
            // 
            // btnUpdateInv
            // 
            this.btnUpdateInv.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpdateInv.Location = new System.Drawing.Point(615, 9);
            this.btnUpdateInv.Name = "btnUpdateInv";
            this.btnUpdateInv.Size = new System.Drawing.Size(75, 23);
            this.btnUpdateInv.TabIndex = 2;
            this.btnUpdateInv.Text = "Update";
            this.btnUpdateInv.UseVisualStyleBackColor = true;
            this.btnUpdateInv.Click += new System.EventHandler(this.btnUpdateInv_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(702, 329);
            this.Controls.Add(this.btnUpdateInv);
            this.Controls.Add(this.invGrid);
            this.Controls.Add(this.lblInv);
            this.Name = "MainForm";
            this.Text = "GUI to Inventory";
            ((System.ComponentModel.ISupportInitialize)(this.invGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblInv;
        private System.Windows.Forms.DataGridView invGrid;
        private System.Windows.Forms.Button btnUpdateInv;
    }
}

