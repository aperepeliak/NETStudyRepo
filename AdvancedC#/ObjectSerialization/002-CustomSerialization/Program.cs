using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Soap;
using System.Text;
using System.Threading.Tasks;

namespace _002_CustomSerialization
{
    class Program
    {
        static void Main(string[] args)
        {
            // UsingISerializable();
            UsingAttrbs();
        }

        private static void UsingAttrbs()
        {
            MoreData myData = new MoreData();

            SoapFormatter soapFormat = new SoapFormatter();
            using (Stream fStream = new FileStream("MyData2.soap",
                FileMode.Create, FileAccess.Write, FileShare.None))
            {
                soapFormat.Serialize(fStream, myData);
            }
        }

        private static void UsingISerializable()
        {
            StringData myData = new StringData();

            SoapFormatter soapFormat = new SoapFormatter();
            using (Stream fStream = new FileStream("MyData.soap",
                FileMode.Create, FileAccess.Write, FileShare.None))
            {
                soapFormat.Serialize(fStream, myData);
            }
        }
    }
}
