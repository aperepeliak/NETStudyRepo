using MG.MainMenu.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MG.ConsoleTestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var model = new RecentRecipesModel();

            foreach (var item in model.RecentRecipes)
            {
                Console.WriteLine(item);
            }

            // model.SaveDataToXml(new string[] { "desert" });
        }
    }
}
