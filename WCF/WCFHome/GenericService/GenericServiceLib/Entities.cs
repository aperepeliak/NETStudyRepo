using GenericServiceLib.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GenericServiceLib
{
    public class Entities
    {
        private const string XML_MANUFS = "Manufacturers.xml";
        private const string XML_CATEGORIES = "Categories.xml";

        public List<Manufacturer> Manufacturers { get; protected set; }
        public List<Category> Categories { get; protected set; }

        public Entities()
        {
            if (File.Exists(XML_MANUFS)) GetManufacturersFromXml();
            else Manufacturers = new List<Manufacturer>();

            if (File.Exists(XML_CATEGORIES)) GetCategoriesFromXml();
            else Categories = new List<Category>();
        }

        private void GetCategoriesFromXml()
        {
            var document = XDocument.Load(XML_CATEGORIES);

            var query = from c in document.Element("Categories").Elements("Category")
                        select new Category
                        {
                            Id = int.Parse(c.Attribute("Id").Value),
                            Name = c.Attribute("Name").Value
                        };

            Categories = query.ToList();
        }

        private void GetManufacturersFromXml()
        {
            var document = XDocument.Load(XML_MANUFS);

            var query = from m in document.Element("Manufacturers").Elements("Manufacturer")
                        select new Manufacturer
                        {
                            Id = int.Parse(m.Attribute("Id").Value),
                            Name = m.Attribute("Name").Value
                        };

            Manufacturers = query.ToList();
        }

        public void SaveEntitiesToXml()
        {
            var document = new XDocument();
            var manufacturers = new XElement("Manufacturers");
            var categories = new XElement("Categories");

            var elements = from m in Manufacturers
                           select new XElement("Manufacturer",
                                new XAttribute("Id", m.Id),
                                new XAttribute("Name", m.Name)
                           );
            manufacturers.Add(elements);
            document.Add(manufacturers);
            document.Save(XML_MANUFS);

            elements = from c in Categories
                       select new XElement("Category",
                            new XAttribute("Id", c.Id),
                            new XAttribute("Name", c.Name)
                       );
            categories.Add(elements);
            document.Add(categories);
            document.Save(XML_CATEGORIES);
        }
    }
}
