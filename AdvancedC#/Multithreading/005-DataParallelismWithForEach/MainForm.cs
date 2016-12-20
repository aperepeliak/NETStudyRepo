using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _005_DataParallelismWithForEach
{
    public partial class MainForm : Form
    {

        private CancellationTokenSource cancelToken = new CancellationTokenSource();

        public MainForm()
        {
            InitializeComponent();
        }

        private void btnProcessImages_Click(object sender, EventArgs e)
        {
            Task.Factory.StartNew(() =>
            {
                ProcessFiles();
            });
        }

        private void ProcessFiles()
        {
            // Using ParallelOptions instance to store the CancellationToken
            var parOpts = new ParallelOptions();
            parOpts.CancellationToken = cancelToken.Token;
            parOpts.MaxDegreeOfParallelism = System.Environment.ProcessorCount;

            // Load up all *.jpg files, and make a new folder for the  modified data
            string[] files = Directory.GetFiles(
                @"D:\Study\NETStudyRepo\files\troelsenJapikse\Chapter_19\TestPictures",
                "*.jpg", SearchOption.AllDirectories);

            string newDir = @"D:\ModifiedPictures";
            Directory.CreateDirectory(newDir);
            try
            {
                Parallel.ForEach(files, currFile =>
                {
                    string filename = Path.GetFileName(currFile);
                    using (var bitmap = new Bitmap(currFile))
                    {
                        bitmap.RotateFlip(RotateFlipType.Rotate180FlipNone);
                        bitmap.Save(Path.Combine(newDir, filename));

                        this.Invoke((Action)delegate
                        {
                            this.Text =
                            string.Format($"Processing {filename} on thread {Thread.CurrentThread.ManagedThreadId}");
                        });
                    }
                });
                this.Invoke((Action)delegate
                {
                    this.Text = "Done!";
                });
            }
            catch (OperationCanceledException ex)
            {
                this.Invoke((Action)delegate
                {
                    this.Text = ex.Message;
                });
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            cancelToken.Cancel();
        }
    }
}
