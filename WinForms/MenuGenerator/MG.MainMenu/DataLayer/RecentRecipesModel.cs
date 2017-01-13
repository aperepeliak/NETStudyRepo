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
        private const string XMLSource = "RecentRecipes.xml";
        XDocument document;
        public List<string> RecentRecipes { get; }

        public RecentRecipesModel()
        {
            if (File.Exists(XMLSource))
            {
                document = XDocument.Load(XMLSource);
                RecentRecipes = GetDataFromXml();
            }
            else
            {
                RecentRecipes = new List<string>();
            }
        }

        private List<string> GetDataFromXml()
        {
            return
                document.Element("RecentRecipes").Elements("Iteration")
                .SelectMany(i => i.Elements("Recipe").Select(r => r.Attribute("Name").Value))
                .ToList();
        }

        public void SaveDataToXml(List<string> chosenRecipes)
        {
            if (document != null)
            {
                var newIteration = new XElement("Iteration",
                        from r in chosenRecipes
                        select new XElement("Recipe", new XAttribute("Name", r))
                    );
                document.Root.AddFirst(newIteration);

                if (document.Root.Elements("Iteration").Count() == 6)
                {
                    document.Root.Elements("Iteration").Last().Remove();
                }

                document.Save(XMLSource);
            }
            else
            {
                document = new XDocument();

                var recentRecipes = new XElement("RecentRecipes");

                var newIteration = new XElement("Iteration",
                        from r in chosenRecipes
                        select new XElement("Recipe", new XAttribute("Name", r))
                    );
                recentRecipes.Add(newIteration);

                document.Add(recentRecipes);
                document.Save(XMLSource);
            }
        }
    }
}
