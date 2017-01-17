namespace ProductsServiceHost
{
    partial class Server
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
            this.btnSwitcher = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.rbPerSession = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbPerCall = new System.Windows.Forms.RadioButton();
            this.rbSingle = new System.Windows.Forms.RadioButton();
            this.lblStatus = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSwitcher
            // 
            this.btnSwitcher.Location = new System.Drawing.Point(13, 122);
            this.btnSwitcher.Name = "btnSwitcher";
            this.btnSwitcher.Size = new System.Drawing.Size(113, 38);
            this.btnSwitcher.TabIndex = 0;
            this.btnSwitcher.Text = "Start";
            this.btnSwitcher.UseVisualStyleBackColor = true;
            this.btnSwitcher.Click += new System.EventHandler(this.btnSwitcher_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(51, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(208, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Products Service Host";
            // 
            // rbPerSession
            // 
            this.rbPerSession.AutoSize = true;
            this.rbPerSession.Checked = true;
            this.rbPerSession.Location = new System.Drawing.Point(6, 35);
            this.rbPerSession.Name = "rbPerSession";
            this.rbPerSession.Size = new System.Drawing.Size(81, 17);
            this.rbPerSession.TabIndex = 2;
            this.rbPerSession.TabStop = true;
            this.rbPerSession.Text = "Per Session";
            this.rbPerSession.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbSingle);
            this.groupBox1.Controls.Add(this.rbPerCall);
            this.groupBox1.Controls.Add(this.rbPerSession);
            this.groupBox1.Location = new System.Drawing.Point(13, 42);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(301, 74);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Instance Context Mode Options";
            // 
            // rbPerCall
            // 
            this.rbPerCall.AutoSize = true;
            this.rbPerCall.Location = new System.Drawing.Point(126, 35);
            this.rbPerCall.Name = "rbPerCall";
            this.rbPerCall.Size = new System.Drawing.Size(61, 17);
            this.rbPerCall.TabIndex = 3;
            this.rbPerCall.Text = "Per Call";
            this.rbPerCall.UseVisualStyleBackColor = true;
            // 
            // rbSingle
            // 
            this.rbSingle.AutoSize = true;
            this.rbSingle.Location = new System.Drawing.Point(241, 35);
            this.rbSingle.Name = "rbSingle";
            this.rbSingle.Size = new System.Drawing.Size(54, 17);
            this.rbSingle.TabIndex = 4;
            this.rbSingle.Text = "Single";
            this.rbSingle.UseVisualStyleBackColor = true;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("MS Reference Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblStatus.ForeColor = System.Drawing.Color.Red;
            this.lblStatus.Location = new System.Drawing.Point(162, 129);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(124, 26);
            this.lblStatus.TabIndex = 4;
            this.lblStatus.Text = "Stopped..";
            // 
            // Server
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(326, 173);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSwitcher);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Server";
            this.Text = "ServiceHost";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSwitcher;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rbPerSession;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbSingle;
        private System.Windows.Forms.RadioButton rbPerCall;
        private System.Windows.Forms.Label lblStatus;
    }
}

