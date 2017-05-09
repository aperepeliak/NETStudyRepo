using _004_Interfaces.Activities;
using System;
using System.Collections;
using System.Collections.Generic;

namespace _004_Interfaces
{
    public class Workflow : IWorkflow
    {
        private readonly IList<IActivity> _activities;

        public Workflow()
        {
            _activities = new List<IActivity>();
        }

        public IWorkflow AddActivity(IActivity activity)
        {
            if (activity == null)
                throw new ArgumentNullException("activity");

            _activities.Add(activity);
            return this;
        }

        public IEnumerator<IActivity> GetEnumerator() => _activities.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
