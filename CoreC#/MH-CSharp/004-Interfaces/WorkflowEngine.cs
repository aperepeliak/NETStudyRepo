using System.Threading;

namespace _004_Interfaces
{
    public class WorkflowEngine
    {
        private readonly Workflow _workflow;
        public WorkflowEngine(Workflow workflow)
        {
            _workflow = workflow;
        }

        public void Run()
        {
            foreach (var activity in _workflow)
            {
                activity.Execute();
                Thread.Sleep(1000);
            }
        }
    }
}
