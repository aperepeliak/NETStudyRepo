using _004_Interfaces.Activities;

namespace _004_Interfaces
{

    class Program
    {
        static void Main(string[] args)
        {
            var workflow = new Workflow();

            workflow.AddActivity(new UploadVideo())
                    .AddActivity(new EncodeVideo())
                    .AddActivity(new SendNotification())
                    .AddActivity(new ChangeStatus());

            var engine = new WorkflowEngine(workflow);

            engine.Run();
        }
    }
}
