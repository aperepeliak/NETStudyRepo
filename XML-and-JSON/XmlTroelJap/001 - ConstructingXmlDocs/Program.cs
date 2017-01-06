using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml.Linq;

namespace _001___ConstructingXmlDocs
{
    class Program
    {
        static void Main(string[] args)
        {
            // CreateFullXDocument();
            ParseAndLoadXml();
        }

        static void ParseAndLoadXml()
        {
            string myElement =
                @"<Car ID = '3'>
                    <Color>Yellow</Color>
                    <Make>ZAZ</Make>
                    </Car>";

            XElement newEl = XElement.Parse(myElement);
            Console.WriteLine(newEl);
            Console.WriteLine();

            XDocument myDoc = XDocument.Load("SimpleInv.xml");
            Console.WriteLine(myDoc);
        }

        static void CreateFullXDocument()
        {
            var inventoryDoc =
                new XDocument(
                    new XDeclaration("1.0", "utf-8", "yes"),
                    new XComment("Current inventory of cars"),
                    new XProcessingInstruction("xml-stylesheet", "href='MyStyles.css' title='Compact' type='text/css'"),
                    new XElement("Inventory",
                        new XElement("Car", new XAttribute("ID", "1"),
                            new XElement("Color", "Green"),
                            new XElement("Make", "Saab"),
                            new XElement("PetName", "Jo")
                            ),
                        new XElement("Car", new XAttribute("ID", "2"),
                            new XElement("Color", "Pink"),
                            new XElement("Make", "Fiat"),
                            new XElement("PetName", "Lu")
                            )
                        )
                    );

            inventoryDoc.Save("SimpleInv.xml");
        }
    }
}
