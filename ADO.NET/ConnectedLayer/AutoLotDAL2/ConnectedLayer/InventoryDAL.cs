using AutoLotDAL2.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoLotDAL2.ConnectedLayer
{
    public class InventoryDAL : IDisposable
    {
        private readonly string _connStr;

        private SqlConnection _sqlConnection = null;

        public InventoryDAL() { }
        public InventoryDAL(string connectionString)
        {
            _connStr = connectionString;
            // OpenConnection();
        }

        public void OpenConnection()
        {
            _sqlConnection = new SqlConnection
            {
                ConnectionString = _connStr
            };

            _sqlConnection.Open();
        }
        public void OpenConnection(string connectionString)
        {
            _sqlConnection = new SqlConnection
            {
                ConnectionString = connectionString
            };

            _sqlConnection.Open();
        }

        public void Dispose() => CloseConnection();
        public void CloseConnection() => _sqlConnection.Close();

        public void InsertAuto(int id, string color, string make, string petName)
        {
            string sql = "Insert Into Inventory" +
                $"(Make, Color, PetName) Values" +
                "('@Make', '@Color', '@PetName')";

            using (var command = new SqlCommand(sql, _sqlConnection))
            {
                command.Parameters.AddRange(new[]
                {
                    new SqlParameter
                    {
                        ParameterName = "@Make",
                        Value = make,
                        SqlDbType = SqlDbType.Char,
                        Size = 10
                    },
                    new SqlParameter
                    {
                        ParameterName = "@Color",
                        Value = color,
                        SqlDbType = SqlDbType.Char,
                        Size = 10
                    },
                    new SqlParameter
                    {
                        ParameterName = "@PetName",
                        Value = petName,
                        SqlDbType = SqlDbType.Char,
                        Size = 10
                    }
                });

                command.ExecuteNonQuery();
            }
        }
        public void InsertAuto(NewCar car)
        {
            string sql = "Insert Into Inventory" +
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
                    var error = new Exception("Sorry! That car is on order!", ex);
                    throw error;
                }
            }
        }

        public void UpdateCarPetName(int id, string newPetName)
        {
            string sql = $"Update Inventory Set PetName = '{newPetName}' Where CarId = '{id}'";
            using (SqlCommand command = new SqlCommand(sql, _sqlConnection))
            {
                command.ExecuteNonQuery();
            }
        }
        public string LookUpPetName(int carId)
        {
            string carPetName = string.Empty;

            using (var command = new SqlCommand("GetPetName", _sqlConnection))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddRange(new[]
                {
                    new SqlParameter
                    {
                        ParameterName = "@carID",
                        SqlDbType = SqlDbType.Int,
                        Value = carId,
                        Direction = ParameterDirection.Input
                    },
                    new SqlParameter
                    {
                        ParameterName = "@petName",
                        SqlDbType = SqlDbType.Char,
                        Size = 10,
                        Direction = ParameterDirection.Output
                    }
                });

                command.ExecuteNonQuery();

                carPetName = (string)command.Parameters["@petName"].Value;
            }

            return carPetName;
        }

        public List<NewCar> GetAllInventoryAsList()
        {
            var inv = new List<NewCar>();

            string sql = "Select * From Inventory";
            using (var command = new SqlCommand(sql, _sqlConnection))
            {
                using (var dataReader = command.ExecuteReader())
                {
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
                }
            }

            return inv;
        }
        public DataTable GetAllInventoryAsDataTable()
        {
            var dataTable = new DataTable();

            string sql = "Select * From Inventory";

            using (var command = new SqlCommand(sql, _sqlConnection))
            {
                using (var dataReader = command.ExecuteReader())
                {
                    dataTable.Load(dataReader);
                }
            }

            return dataTable;
        }

        public TResult Universal<TSource, TResult>(Func<TSource, TResult> method, TSource source)
        {
            OpenConnection();
            TResult result = method(source);
            CloseConnection();
            return result;
        }
        public TResult Universal<T1, T2, TResult>(Func<T1, T2, TResult> method, T1 s1, T2 s2)
        {
            OpenConnection();
            TResult result = method(s1, s2);
            CloseConnection();
            return result;
        }
        public TResult Universal<T1, T2, T3, TResult>(Func<T1, T2, T3, TResult> method, T1 s1, T2 s2, T3 s3)
        {
            OpenConnection();
            TResult result = method(s1, s2, s3);
            CloseConnection();
            return result;
        }

        public void ExecuteAction<T>(Action<T> actionMethod, T source)
        {
            OpenConnection();
            actionMethod(source);
            CloseConnection();
        }
        public void ExecuteAction<T1,T2>(Action<T1, T2> actionMethod, T1 s1, T2 s2)
        {
            OpenConnection();
            actionMethod(s1, s2);
            CloseConnection();
        }



    }
}
