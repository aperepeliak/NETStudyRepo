using System;

namespace _003_Polymorphism
{
    public abstract class CustomDbConnection
    {
        public string ConnectionString { get; set; }
        public TimeSpan Timeout { get; set; }

        public CustomDbConnection(string connectionString)
        {
            ConnectionString = connectionString ??
                throw new InvalidOperationException("The passed connString was null");
        }

        public abstract void Open();
        public abstract void Close();
    }
}
