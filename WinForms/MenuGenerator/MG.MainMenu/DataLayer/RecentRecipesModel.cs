using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MG.MainMenu.DataLayer
{
    
    public class RecentRecipesModel
    {
        XDocument document;
        public List<string> RecentRecipes { get; }

        public RecentRecipesModel()
        {
            if (File.Exists("Recipes.xml"))
            {
                document = XDocument.Load("RecentRecipes.xml");
                RecentRecipes = GetDataFromXml();
            } else
            {
                RecentRecipes = new List<string>();
            }
        }

        private List<string> GetDataFromXml()
        {
            var query =
                document.Element("RecentRecipes").Elements("Iteration")
                .Select(i => i.)
                
        }
    }
}
