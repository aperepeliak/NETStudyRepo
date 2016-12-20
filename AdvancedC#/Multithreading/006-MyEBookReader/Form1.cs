using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _006_MyEBookReader
{
    public partial class Form1 : Form
    {

        string theEBook;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            WebClient wc = new WebClient();
            wc.DownloadStringCompleted += (s, eArgs) =>
            {
                theEBook = eArgs.Result;
                txtBook.Text = theEBook;
            };

            wc.DownloadStringAsync(new Uri("http://www.gutenberg.org/files/98/98-0.txt"));
        }

        private void btnGetStats_Click(object sender, EventArgs e)
        {
            // Get the words from e-book
            string[] words = theEBook.Split(new char[]
            {
                ' ', '\u000A', ',', '.', ';', ':', '-', '?', '/'
            },
            StringSplitOptions.RemoveEmptyEntries);

            // Find ten most common words
            string[] tenMostCommon = null;

            // Get the longest word
            string longestWord = string.Empty;

            Parallel.Invoke(
                () =>
                {
                    tenMostCommon = FindTenMostCommon(words);
                },
                () =>
                {
                    longestWord = FindLongestWord(words);
                }
                );

            StringBuilder bookStats = new StringBuilder("Ten most common words are: \n");
            foreach (var word in tenMostCommon)
            {
                bookStats.AppendLine(word);
            }

            bookStats.AppendFormat($"Longest word is: {longestWord}");
            bookStats.AppendLine();
            MessageBox.Show(bookStats.ToString(), "Book Info");
        }

        private string FindLongestWord(string[] words)
        {
            return words
                .OrderByDescending(w => w.Length)
                .FirstOrDefault();
        }

        private string[] FindTenMostCommon(string[] words)
        {
            var query = words
                .Where(w => w.Length > 6)
                .GroupBy(w => w)
                .OrderByDescending(g => g.Count())
                .Select(g => g.Key);

            string[] commonWords = query.Take(10).ToArray();
            return commonWords;
        }
    }
}
