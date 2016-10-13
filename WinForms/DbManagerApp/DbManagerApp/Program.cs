using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DbManagerApp
{
    class Program
    {
        static void Main(string[] args)
        {
            

            Application.Run(new MainForm("..\\..\\dbCore.db"));
        }
    }
}
