namespace SemaphoreMVC
{
    partial class MainView
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
            this.btnCreateThread = new System.Windows.Forms.Button();
            this.numThreads = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.lbxCreated = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lbxWaiting = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lbxWorking = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numThreads)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCreateThread
            // 
            this.btnCreateThread.Location = new System.Drawing.Point(304, 113);
            this.btnCreateThread.Name = "btnCreateThread";
            this.btnCreateThread.Size = new System.Drawing.Size(119, 23);
            this.btnCreateThread.TabIndex = 18;
            this.btnCreateThread.Text = "Создать поток";
            this.btnCreateThread.UseVisualStyleBackColor = true;
            this.btnCreateThread.Click += new System.EventHandler(this.btnCreateThread_Click);
            // 
            // numThreads
            // 
            this.numThreads.Location = new System.Drawing.Point(15, 113);
            this.numThreads.Name = "numThreads";
            this.numThreads.Size = new System.Drawing.Size(105, 20);
            this.numThreads.TabIndex = 17;
            this.numThreads.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numThreads.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(158, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Количество мест в семафоре";
            // 
            // lbxCreated
            // 
            this.lbxCreated.FormattingEnabled = true;
            this.lbxCreated.Location = new System.Drawing.Point(304, 25);
            this.lbxCreated.Name = "lbxCreated";
            this.lbxCreated.Size = new System.Drawing.Size(120, 56);
            this.lbxCreated.TabIndex = 15;
            this.lbxCreated.DoubleClick += new System.EventHandler(this.lbxCreated_DoubleClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(302, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Созданные потоки";
            // 
            // lbxWaiting
            // 
            this.lbxWaiting.FormattingEnabled = true;
            this.lbxWaiting.Location = new System.Drawing.Point(163, 25);
            this.lbxWaiting.Name = "lbxWaiting";
            this.lbxWaiting.Size = new System.Drawing.Size(120, 56);
            this.lbxWaiting.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(160, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Ожидающие потоки";
            // 
            // lbxWorking
            // 
            this.lbxWorking.FormattingEnabled = true;
            this.lbxWorking.Location = new System.Drawing.Point(15, 25);
            this.lbxWorking.Name = "lbxWorking";
            this.lbxWorking.Size = new System.Drawing.Size(120, 56);
            this.lbxWorking.TabIndex = 11;
            this.lbxWorking.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lbxWorking_MouseDoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Работающие потоки";
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(445, 150);
            this.Controls.Add(this.btnCreateThread);
            this.Controls.Add(this.numThreads);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lbxCreated);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbxWaiting);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbxWorking);
            this.Controls.Add(this.label1);
            this.Name = "MainView";
            this.Text = "Semaphore";
            this.Load += new System.EventHandler(this.MainView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numThreads)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnCreateThread;
        private System.Windows.Forms.NumericUpDown numThreads;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListBox lbxCreated;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox lbxWaiting;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lbxWorking;
        private System.Windows.Forms.Label label1;
    }
}

