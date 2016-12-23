using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace _001_SimpleSerialize
{
    class Program
    {
        static void Main(string[] args)
        {
            JamesBondCar jbc = new JamesBondCar();
            jbc.canFly = true;
            jbc.canSubmerge = false;
            jbc.theRadio.stationPresets = new double[] { 100.5, 101.2, 106.4 };
            jbc.theRadio.hasTweeters = true;

            // SaveAsBinaryFormat(jbc, "CarData.dat");
            // LoadFromBinaryFile("CarData.dat");

            // SaveAsSoapFormat(jbc, "CarDataSOAP.soap");

            SaveAsXmlFormat(jbc, "CarDataXML");

            Console.ReadKey();
        }

        private static void SaveAsXmlFormat(object objGraph, string fileName)
        {
            XmlSerializer xmlFormat = new XmlSerializer(objGraph.GetType());

            using (Stream fStream = new FileStream(fileName,
                FileMode.Create, FileAccess.Write, FileShare.None))
            {
                xmlFormat.Serialize(fStream, objGraph);
            }
            Console.WriteLine(" => Saved car in XML format!");
        }

        private static void SaveAsSoapFormat(object objGraph, string fileName)
        {
            SoapFormatter soapFormat = new SoapFormatter();

            using (Stream fStream = new FileStream(fileName,
                FileMode.Create, FileAccess.Write, FileShare.None))
            {
                soapFormat.Serialize(fStream, objGraph);
            }
            Console.WriteLine(" => Saved car in SOAP format!");
        }

        private static void LoadFromBinaryFile(string fileName)
        {
            BinaryFormatter binFormat = new BinaryFormatter();

            using (Stream fStream = File.OpenRead(fileName))
            {
                JamesBondCar carFromDisk =
                    (JamesBondCar)binFormat.Deserialize(fStream);
                Console.WriteLine($"Can this car fly? : {carFromDisk.canFly}\n\n");
                Console.WriteLine("Saved radio presets : ");
                foreach (var p in carFromDisk.theRadio.stationPresets)
                {
                    Console.WriteLine($"Preset: {p}");
                }
            }
        }

        private static void SaveAsBinaryFormat(object objGraph, string fileName)
        {
            BinaryFormatter binFormat = new BinaryFormatter();

            using (Stream fStream = new FileStream(fileName,
                FileMode.Create, FileAccess.Write, FileShare.None))
            {
                binFormat.Serialize(fStream, objGraph);
            }

            Console.WriteLine(" => Saved car in binary format!");
        }
    }
}
