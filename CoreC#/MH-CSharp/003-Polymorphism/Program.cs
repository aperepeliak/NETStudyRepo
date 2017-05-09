using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _003_Polymorphism
{
    class Program
    {
        static void Main(string[] args)
        {
            var sqlConnection = new SqlConnection("MySqlServerInstance");
            var oracleConnection = new OracleConnection("MyOracleServerInstance");
            var command = new CustomDbCommand(oracleConnection, "SELECT * FROM PRODUCTS");

            command.Execute();
        }
    }
}
