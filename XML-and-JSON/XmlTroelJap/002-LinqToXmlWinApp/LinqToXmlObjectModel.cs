using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace _002_LinqToXmlWinApp
{
    public class LinqToXmlObjectModel
    {
        public static XDocument GetXmlInventory()
        {
            try
            {
                var inventoryDoc = XDocument.Load("Inventory.xml");
                return inventoryDoc;
            }
            catch (System.IO.FileNotFoundException ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
                return null;
            }
        }

        public static void InsertNewElement(string make, string color, string petName)
        {
            var inventoryDoc = XDocument.Load("Inventory.xml");
            var r = new Random();

            var newEl = new XElement("Car", new XAttribute("ID", r.Next(50000)),
                new XElement("Color", color),
                new XElement("Make", make),
                new XElement("PetName", petName));

            inventoryDoc.Descendants("Inventory").First().Add(newEl);
            inventoryDoc.Save("Inventory.xml");
        }

        public static void LookUpColorsForMake(string make)
        {
            var inventoryDoc = XDocument.Load("Inventory.xml");

            var query =
                inventoryDoc.Descendants("Car")
                .Where(c => (string)c.Element("Make") == make)
                .Select(c => c.Element("Color").Value);

            var data = string.Empty;

            foreach (var item in query.Distinct())
            {
                data += $"- {item}\n";
            }

            System.Windows.Forms.MessageBox.Show(data, $"{make} colors:");
        }
    }
}
