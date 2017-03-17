using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PerfSerf.Counters
{
    public class PerfCounterService
    {
        public PerfCounterService()
        {
            _counters = new List<PerfCouterWrapper>
            {
                new PerfCouterWrapper(
                    "Processor", "Processor", "% Processor Time", "_Total"),
                new PerfCouterWrapper(
                    "Paging", "Memory", "Pages/sec"),
                new PerfCouterWrapper(
                    "Disk", "PhysicalDisk", "% Disk Time", "_Total")
            };
        }

        public dynamic GetResults()
        {
            return _counters.Select(c => new { name = c.Name, value = c.Value });
        }

        List<PerfCouterWrapper> _counters;
    }
}