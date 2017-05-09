using System;

namespace _003_Polymorphism
{
    public class SqlConnection : CustomDbConnection
    {
        public SqlConnection(string connectionString) :
            base(connectionString)
        { }
        
        public override void Close() => Console.WriteLine("Close SQL Server connection");
        public override void Open() => Console.WriteLine("Open SQL Server connection");
    }
}
