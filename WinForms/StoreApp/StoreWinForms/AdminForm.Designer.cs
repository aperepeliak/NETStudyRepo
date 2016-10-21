namespace StoreWinForms
{
    partial class AdminForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.goodsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manufacturersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.categoriesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dgvGoods = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.flwPhoto = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAddPhoto = new System.Windows.Forms.Button();
            this.btnRemovePhoto = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGoods)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.goodsToolStripMenuItem,
            this.manufacturersToolStripMenuItem,
            this.categoriesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(884, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // goodsToolStripMenuItem
            // 
            this.goodsToolStripMenuItem.Name = "goodsToolStripMenuItem";
            this.goodsToolStripMenuItem.Size = new System.Drawing.Size(53, 20);
            this.goodsToolStripMenuItem.Text = "Goods";
            this.goodsToolStripMenuItem.Click += new System.EventHandler(this.goodsToolStripMenuItem_Click);
            // 
            // manufacturersToolStripMenuItem
            // 
            this.manufacturersToolStripMenuItem.Name = "manufacturersToolStripMenuItem";
            this.manufacturersToolStripMenuItem.Size = new System.Drawing.Size(96, 20);
            this.manufacturersToolStripMenuItem.Text = "Manufacturers";
            this.manufacturersToolStripMenuItem.Click += new System.EventHandler(this.manufacturersToolStripMenuItem_Click);
            // 
            // categoriesToolStripMenuItem
            // 
            this.categoriesToolStripMenuItem.Name = "categoriesToolStripMenuItem";
            this.categoriesToolStripMenuItem.Size = new System.Drawing.Size(75, 20);
            this.categoriesToolStripMenuItem.Text = "Categories";
            this.categoriesToolStripMenuItem.Click += new System.EventHandler(this.categoriesToolStripMenuItem_Click);
            // 
            // dgvGoods
            // 
            this.dgvGoods.AllowUserToAddRows = false;
            this.dgvGoods.AllowUserToDeleteRows = false;
            this.dgvGoods.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvGoods.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGoods.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvGoods.GridColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dgvGoods.Location = new System.Drawing.Point(13, 28);
            this.dgvGoods.Name = "dgvGoods";
            this.dgvGoods.ReadOnly = true;
            this.dgvGoods.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGoods.Size = new System.Drawing.Size(653, 278);
            this.dgvGoods.TabIndex = 1;
            this.dgvGoods.SelectionChanged += new System.EventHandler(this.dgvGoods_SelectionChanged);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem,
            this.editToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(108, 70);
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.addToolStripMenuItem.Text = "Add";
            this.addToolStripMenuItem.Click += new System.EventHandler(this.addToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // flwPhoto
            // 
            this.flwPhoto.AutoScroll = true;
            this.flwPhoto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flwPhoto.Location = new System.Drawing.Point(672, 57);
            this.flwPhoto.Name = "flwPhoto";
            this.flwPhoto.Size = new System.Drawing.Size(200, 200);
            this.flwPhoto.TabIndex = 2;
            // 
            // btnAddPhoto
            // 
            this.btnAddPhoto.Location = new System.Drawing.Point(686, 28);
            this.btnAddPhoto.Name = "btnAddPhoto";
            this.btnAddPhoto.Size = new System.Drawing.Size(92, 23);
            this.btnAddPhoto.TabIndex = 3;
            this.btnAddPhoto.Text = "Add Photo";
            this.btnAddPhoto.UseVisualStyleBackColor = true;
            this.btnAddPhoto.Click += new System.EventHandler(this.btnAddPhoto_Click);
            // 
            // btnRemovePhoto
            // 
            this.btnRemovePhoto.Location = new System.Drawing.Point(784, 27);
            this.btnRemovePhoto.Name = "btnRemovePhoto";
            this.btnRemovePhoto.Size = new System.Drawing.Size(88, 23);
            this.btnRemovePhoto.TabIndex = 4;
            this.btnRemovePhoto.Text = "Remove Photo";
            this.btnRemovePhoto.UseVisualStyleBackColor = true;
            this.btnRemovePhoto.Click += new System.EventHandler(this.btnRemovePhoto_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(797, 281);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 5;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 316);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnRemovePhoto);
            this.Controls.Add(this.btnAddPhoto);
            this.Controls.Add(this.flwPhoto);
            this.Controls.Add(this.dgvGoods);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "AdminForm";
            this.Text = "AdminForm";
            this.Load += new System.EventHandler(this.AdminForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGoods)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem goodsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manufacturersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem categoriesToolStripMenuItem;
        private System.Windows.Forms.DataGridView dgvGoods;
        private System.Windows.Forms.FlowLayoutPanel flwPhoto;
        private System.Windows.Forms.Button btnAddPhoto;
        private System.Windows.Forms.Button btnRemovePhoto;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
    }
}