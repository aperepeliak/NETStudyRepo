using System;

namespace _003_Polymorphism
{
    public class OracleConnection : CustomDbConnection
    {
        public OracleConnection(string connectionString)
            : base(connectionString)
        { }

        public override void Close() => Console.WriteLine("Close Oracle connection");
        public override void Open() => Console.WriteLine("Open Oracle connection");
    }
}
