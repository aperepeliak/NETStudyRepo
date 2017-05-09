using _004_Interfaces.Activities;
using System.Collections.Generic;

namespace _004_Interfaces
{
    public interface IWorkflow : IEnumerable<IActivity>
    {
        IWorkflow AddActivity(IActivity activity);
    }
}
