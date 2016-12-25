using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace _002_CustomSerialization
{
    [Serializable]
    class MoreData
    {
        private string dataItemOne = "First data block";
        private string dataItemTwo = "More data";

        [OnSerializing]
        private void OnSerializing(StreamingContext context)
        {
            dataItemOne = dataItemOne.ToUpper();
            dataItemTwo = dataItemTwo.ToUpper();
        }

        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
            dataItemOne = dataItemOne.ToLower();
            dataItemTwo = dataItemTwo.ToLower();
        }
    }
}
