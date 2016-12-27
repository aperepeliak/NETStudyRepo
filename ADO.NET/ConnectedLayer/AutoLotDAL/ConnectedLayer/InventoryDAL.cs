using AutoLotDAL.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoLotDAL.ConnectedLayer
{
    public class InventoryDAL
    {
        private SqlConnection _sqlConnection = null;

        public void InsertAuto(NewCar car)
        {
            string sql = "Insert into inventory" +
                $"(Make, Color, PetName) Values ('{car.Make}', '{car.Color}', '{car.PetName}')";

            using (var command = new SqlCommand(sql, _sqlConnection))
            {
                command.ExecuteNonQuery();
            }
        }

        public void DeleteCar(int id)
        {
            string sql = $"Delete from Inventory where CarId = '{id}'";
            using (var command = new SqlCommand(sql, _sqlConnection))
            {
                try
                {
                    command.ExecuteNonQuery();
                }
                catch (SqlException ex)
                {
                    Exception error = new Exception("Sorry! That car is on order!", ex);
                    throw error;
                }
            }
        }

        public void UpdateCarPetName(int id, string newPetName)
        {
            string sql = $"Update Inventory Set PetName = '{newPetName}' Where CarId = '{id}'";
            using (var command = new SqlCommand(sql, _sqlConnection))
            {
                command.ExecuteNonQuery();
            }
        }

        public List<NewCar> GetAllInventoryAsList()
        {
            List<NewCar> inv = new List<NewCar>();

            string sql = "Select * from Inventory";

            using (var command = new SqlCommand(sql, _sqlConnection))
            {
                SqlDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    inv.Add(new NewCar
                    {
                        CarId = (int)dataReader["CarId"],
                        Color = (string)dataReader["Color"],
                        Make = (string)dataReader["Make"],
                        PetName = (string)dataReader["PetName"]
                    });
                }
                dataReader.Close();
            }

            return inv;
        }

        public string LookUpPetName(int carID)
        {
            string carPetName;

            using (var command = new SqlCommand("GetPetName", _sqlConnection))
            {
                command.CommandType = CommandType.StoredProcedure;

                // Input param
                SqlParameter param = new SqlParameter
                {
                    ParameterName = "@carID",
                    SqlDbType = SqlDbType.Int,
                    Value = carID,
                    Direction = ParameterDirection.Input
                };

                command.Parameters.Add(param);

                // Output param
                param = new SqlParameter
                {
                    ParameterName = "@petName",
                    SqlDbType = SqlDbType.Char,
                    Size = 10,
                    Direction = ParameterDirection.Output
                };

                command.Parameters.Add(param);

                // Executing stored proc
                command.ExecuteNonQuery();

                carPetName = (string)command.Parameters["@petName"].Value;
            }

            return carPetName;
        }

        public void ProcessCreditRisk(bool throwEx, int custID)
        {
            string fName;
            string lName;

            var cmdSelect = new SqlCommand($"Select * from Customers where CustId = {custID}",
                _sqlConnection);

            using (var dataReader = cmdSelect.ExecuteReader())
            {
                if (dataReader.HasRows)
                {
                    dataReader.Read();
                    fName = (string)dataReader["FirstName"];
                    lName = (string)dataReader["LastName"];
                }
                else
                {
                    return;
                }
            }

            var cmdRemove =
                new SqlCommand($"Delete from Customers where CustId = {custID}",
                _sqlConnection);

            var cmdInsert =
                new SqlCommand("Insert into CreditRisks" +
                $"(FirstName, LastName) Values('{fName}', '{lName}')",
                _sqlConnection);

            SqlTransaction tx = null;

            try
            {
                tx = _sqlConnection.BeginTransaction();

                // Enlisting commands in the transaction
                cmdInsert.Transaction = tx;
                cmdRemove.Transaction = tx;

                cmdInsert.ExecuteNonQuery();
                cmdRemove.ExecuteNonQuery();

                // Error simulation
                if (throwEx)
                {
                    throw new Exception("Error! Transaction failed...");
                }

                tx.Commit();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                tx?.Rollback();
            }
        }

        public void OpenConnection(string connectionString)
        {
            _sqlConnection = new SqlConnection { ConnectionString = connectionString };
            _sqlConnection.Open();
        }

        public void CloseConnection() => _sqlConnection.Close();
    }
}
