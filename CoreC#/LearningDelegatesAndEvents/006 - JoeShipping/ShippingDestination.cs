using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _006___JoeShipping
{

    public delegate void ShippingFeesDelegate(decimal price, ref decimal fee);

    abstract class ShippingDestination
    {
        public bool isHighRisk { get; set; }
        public decimal FeeRate { get; }

        public ShippingDestination(decimal rate, bool risk = false)
        {
            FeeRate = rate;
            isHighRisk = risk;
        }

        public virtual void calcFees(decimal price, ref decimal fee)
        {
            fee = price * FeeRate;

            if (isHighRisk)
            {
                fee += 25.0m;
            }
        }

        public static ShippingDestination getDestinationInfo(string dest)
        {
            if (dest == "zone1")
                return new Zone1();

            if (dest == "zone2")
                return new Zone2();

            if (dest == "zone3")
                return new Zone3();

            if (dest == "zone4")
                return new Zone4();

            return null;
        }
    }

    class Zone1 : ShippingDestination
    {
        public Zone1() : base(0.25m) { }
    }

    class Zone2 : ShippingDestination
    {
        public Zone2() : base(0.12m, true) { }
    }

    class Zone3 : ShippingDestination
    {
        public Zone3() : base(0.08m) { }
    }

    class Zone4 : ShippingDestination
    {
        public Zone4() : base(0.04m, true) { }
    }
}
