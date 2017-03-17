using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace PerfSerf.Counters
{
    public class PerfCouterWrapper
    {
        public PerfCouterWrapper(string name, string category, 
                                 string counter, string instance = "")
        {
            _counter = new PerformanceCounter(category, counter, 
                                              instance, readOnly: true);
            Name = name;
        }

        public string Name { get; set; }
        public float Value => _counter.NextValue();

        PerformanceCounter _counter;
    }
}