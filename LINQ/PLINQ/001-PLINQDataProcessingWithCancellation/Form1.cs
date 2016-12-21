using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _001_PLINQDataProcessingWithCancellation
{
    public partial class Form1 : Form
    {

        CancellationTokenSource cancelToken = new CancellationTokenSource();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            Task.Factory.StartNew(() =>
            {
                ProcessIntData();
            });
        }

        private void ProcessIntData()
        {
            int[] source = Enumerable.Range(1, 1000000).ToArray();

            try
            {
                var modThreeIsZero = source
                .AsParallel()
                .WithCancellation(cancelToken.Token)
                .Where(i => i % 3 == 0)
                .OrderByDescending(i => i)
                .ToArray();

                MessageBox.Show(string.Format($"Found {modThreeIsZero.Count()} numbers that match query."));
            }
            catch (OperationCanceledException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            cancelToken.Cancel();
        }
    }
}
