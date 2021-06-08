using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Models;
using Application.Common;

namespace Application.DataAccess
{
    public static class DataAccess
    {
        static DataAccess()
        {

        }

        public static List<Customer> GetCustomers()
        {
            string connectionString = "Server = ESSEE-PC; Database = RepasoN44; Trusted_Connection = true;";
            try
            {
                List<Customer> customers = new List<Customer>();
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    SqlCommand sqlCommand = new SqlCommand();
                    sqlCommand.Connection = sqlConnection;
                    sqlCommand.CommandType = CommandType.Text;
                    sqlCommand.CommandText = "SELECT * FROM Customers";
                    sqlConnection.Open();
                    SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                    while (sqlDataReader.Read())
                    {
                        Customer customer = new Customer(sqlDataReader["Name"].ToString(), sqlDataReader["LastName"].ToString(), int.Parse(sqlDataReader["Age"].ToString()));
                        customer.Id = long.Parse(sqlDataReader["Id"].ToString());
                        customers.Add(customer);
                    }
                    return customers;
                }
            }catch (Exception e)
            {
                throw e;
            }           
        }

        public static void GetCustomersById()
        {

        }

        public static void InsertCustomers()
        {

        }

        public static void UpdateCustomers()
        {

        }

        public static void DeleteCustomers()
        {

        }




    }
}
