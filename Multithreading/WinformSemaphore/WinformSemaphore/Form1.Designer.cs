namespace WinformSemaphore
{
    partial class Form1
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
            this.label1 = new System.Windows.Forms.Label();
            this.lbxWorking = new System.Windows.Forms.ListBox();
            this.lbxWaiting = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lbxCreated = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.numThreads = new System.Windows.Forms.NumericUpDown();
            this.btnCreateThread = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numThreads)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Работающие потоки";
            // 
            // lbxWorking
            // 
            this.lbxWorking.FormattingEnabled = true;
            this.lbxWorking.Location = new System.Drawing.Point(12, 29);
            this.lbxWorking.Name = "lbxWorking";
            this.lbxWorking.Size = new System.Drawing.Size(120, 56);
            this.lbxWorking.TabIndex = 1;
            this.lbxWorking.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lbxWorking_MouseDoubleClick);
            // 
            // lbxWaiting
            // 
            this.lbxWaiting.FormattingEnabled = true;
            this.lbxWaiting.Location = new System.Drawing.Point(159, 29);
            this.lbxWaiting.Name = "lbxWaiting";
            this.lbxWaiting.Size = new System.Drawing.Size(120, 56);
            this.lbxWaiting.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(160, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Ожидающие потоки";
            // 
            // lbxCreated
            // 
            this.lbxCreated.FormattingEnabled = true;
            this.lbxCreated.Location = new System.Drawing.Point(309, 29);
            this.lbxCreated.Name = "lbxCreated";
            this.lbxCreated.Size = new System.Drawing.Size(120, 56);
            this.lbxCreated.TabIndex = 5;
            this.lbxCreated.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lbxCreated_MouseDoubleClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(310, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Созданные потоки";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(158, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Количество мест в семафоре";
            // 
            // numThreads
            // 
            this.numThreads.Location = new System.Drawing.Point(12, 128);
            this.numThreads.Name = "numThreads";
            this.numThreads.Size = new System.Drawing.Size(155, 20);
            this.numThreads.TabIndex = 7;
            this.numThreads.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numThreads.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // btnCreateThread
            // 
            this.btnCreateThread.Location = new System.Drawing.Point(309, 124);
            this.btnCreateThread.Name = "btnCreateThread";
            this.btnCreateThread.Size = new System.Drawing.Size(119, 23);
            this.btnCreateThread.TabIndex = 8;
            this.btnCreateThread.Text = "Создать поток";
            this.btnCreateThread.UseVisualStyleBackColor = true;
            this.btnCreateThread.Click += new System.EventHandler(this.btnCreateThread_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(454, 182);
            this.Controls.Add(this.btnCreateThread);
            this.Controls.Add(this.numThreads);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lbxCreated);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbxWaiting);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbxWorking);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Semaphore";
            ((System.ComponentModel.ISupportInitialize)(this.numThreads)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lbxWorking;
        private System.Windows.Forms.ListBox lbxWaiting;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lbxCreated;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numThreads;
        private System.Windows.Forms.Button btnCreateThread;
    }
}

