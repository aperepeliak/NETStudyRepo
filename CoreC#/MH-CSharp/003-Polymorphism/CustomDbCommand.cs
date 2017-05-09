using System;

namespace _003_Polymorphism
{
    public class CustomDbCommand
    {
        private readonly CustomDbConnection _conn;
        private readonly string _instruction;

        public CustomDbCommand(CustomDbConnection conn, string instruction)
        {

            if(string.IsNullOrWhiteSpace(instruction))
                throw new InvalidOperationException("Instruction string is null.");

            _conn = conn ?? throw new InvalidOperationException("DbConnection is null.");
            _instruction = instruction;
        }

        public void Execute()
        {
            _conn.Open();
            Console.WriteLine($"Running instruction: {_instruction}");
            _conn.Close();
        }
    }
}
