using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MG.MainMenu
{
    class Settings
    {
        const string SETTINGS_XML_SOURCE = "Settings.xml";

        XDocument document;

        public bool IsLoaded { get; }

        public string OptionOne { get; set; } = string.Empty;
        public string OptionTwo { get; set; } = string.Empty;
        public string OptionThree { get; set; } = string.Empty;
        public string OptionFour { get; set; } = string.Empty;

        public int OptionOneCount { get; set; } = 0;
        public int OptionTwoCount { get; set; } = 0;
        public int OptionThreeCount { get; set; } = 0;
        public int OptionFourCount { get; set; } = 0;

        public int RecipesHistoryCount { get; set; } = 2;

        public bool IsSeasonalityChecked { get; set; }

        public Settings()
        {
            if (File.Exists(SETTINGS_XML_SOURCE))
            {
                LoadSettings();
                IsLoaded = true;
            }
        }

        private void LoadSettings()
        {
            document = XDocument.Load(SETTINGS_XML_SOURCE);

            var settings = document.Element("Settings");

            OptionOne = settings.Element("OptionOne").Attribute("Name").Value;
            OptionOneCount = int.Parse(settings.Element("OptionOne").Attribute("Count").Value);

            OptionTwo = settings.Element("OptionTwo").Attribute("Name").Value;
            OptionTwoCount = int.Parse(settings.Element("OptionTwo").Attribute("Count").Value);

            OptionThree = settings.Element("OptionThree").Attribute("Name").Value;
            OptionThreeCount = int.Parse(settings.Element("OptionThree").Attribute("Count").Value);

            OptionFour = settings.Element("OptionFour").Attribute("Name").Value;
            OptionFourCount = int.Parse(settings.Element("OptionFour").Attribute("Count").Value);

            RecipesHistoryCount = int.Parse(settings.Element("RecipesHistoryCount").Value);

            IsSeasonalityChecked = bool.Parse(settings.Element("IsSeasonalityChecked").Value);
        }

        public void SaveSettings()
        {
            var settings = new XElement("Settings",
                
                new XElement("OptionOne", new XAttribute("Name", OptionOne), new XAttribute("Count", OptionOneCount)),
                new XElement("OptionTwo", new XAttribute("Name", OptionTwo), new XAttribute("Count", OptionTwoCount)),
                new XElement("OptionThree", new XAttribute("Name", OptionThree), new XAttribute("Count", OptionThreeCount)),
                new XElement("OptionFour", new XAttribute("Name", OptionFour), new XAttribute("Count", OptionFourCount)),

                new XElement("IsSeasonalityChecked", IsSeasonalityChecked),
                new XElement("RecipesHistoryCount", RecipesHistoryCount)
                );

            document = new XDocument();
            document.Add(settings);
            document.Save(SETTINGS_XML_SOURCE);
        }
    }
}
