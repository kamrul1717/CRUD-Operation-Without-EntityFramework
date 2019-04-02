using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using CustomerMvcApp.Models;

namespace CustomerMvcApp.DLL
{
    public class CustomerRepository
    {
        private static string cs = ConfigurationManager.ConnectionStrings["ProjectDbContext"].ToString();
        public static SqlConnection sqlConnection = new SqlConnection(cs);
        SqlCommand sqlCommand = new SqlCommand("", sqlConnection);
        Customer customer = new Customer();

        public bool Saved(Customer customer)
        {
            bool chk = false;

            string query = @"INSERT INTO Customers([Name],[Code],[Address],[Email],[Contact],[Age],[LoyalityPoint]) VALUES
                            ('" + customer.Name + "','" + customer.Code + "','" + customer.Address + "','" + customer.Email + "','" + customer.Contact + "'," + customer.Age + "," + customer.LoyalityPoint + ");";

            sqlConnection.Open();
            sqlCommand.CommandText = query;
            int isSaved = sqlCommand.ExecuteNonQuery();

            if (isSaved > 0)
            {
                chk = true;
            }
            sqlConnection.Close();
            return chk;


        }

        public Customer GetCustomerInfo(string Code)
        {
            string findIdQuery = @"select * from Customers where Code = '" + Code + "';";

            sqlConnection.Open();

            sqlCommand.CommandText = findIdQuery;
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            if (sqlDataReader.Read())
            {
                customer.Id = Convert.ToInt32(sqlDataReader["Id"].ToString());
                customer.Name = sqlDataReader["Name"].ToString();
                customer.Code = sqlDataReader["Code"].ToString();
                customer.Address = sqlDataReader["Address"].ToString();
                customer.Email = sqlDataReader["Email"].ToString();
                customer.Contact = sqlDataReader["Contact"].ToString();
                customer.Age = Convert.ToInt32(sqlDataReader["Age"].ToString());
                customer.LoyalityPoint = Convert.ToInt32(sqlDataReader["LoyalityPoint"].ToString());
            }
            sqlConnection.Close();
            return customer;
        }

        
        public List<Customer> Show()
        {
            var dataList = new List<Customer>();
            string  query = @"SELECT * FROM Customers ORDER BY Id DESC";
            sqlCommand.CommandText = query;
            sqlConnection.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(sqlCommand);
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    var customerObj = new Customer();
                    customerObj.Id = Convert.ToInt32(dr["Id"]);
                    customerObj.Name = dr["Name"].ToString();
                    customerObj.Code = dr["Code"].ToString();
                    customerObj.Address = dr["Address"].ToString();
                    customerObj.Email = dr["Email"].ToString();
                    customerObj.Contact = dr["Contact"].ToString();
                    customerObj.Age = Convert.ToInt32(dr["Age"]);
                    customerObj.LoyalityPoint = Convert.ToInt32(dr["LoyalityPoint"]);

                    dataList.Add(customerObj);
                }
            }

            sqlConnection.Close();

            return dataList;
        }



        public bool Delete(int id)
        {
            string deleteQuery = @"Delete from Customers where Id='"+id+"'";
            sqlCommand.CommandText = deleteQuery;
            sqlConnection.Open();
            int isDeleted = sqlCommand.ExecuteNonQuery();

            sqlConnection.Close();
            if (isDeleted > 0)
            {
                return true;
            }
            return false;
        }
        public List<Customer> Search(Customer customer)
        {
            var dataList = new List<Customer>();
            string query = "";
            if (!string.IsNullOrEmpty(customer.Code))
            {
                query = @"SELECT * FROM Customers WHERE Code = '"+customer.Code+"' ORDER BY Id DESC";
            }
            else
            {
                query = @"SELECT * FROM Customers ORDER BY Id DESC";
            }
            sqlCommand.CommandText = query;
            sqlConnection.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(sqlCommand);
            da.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                foreach(DataRow dr in dt.Rows)
                {
                    var customerObj = new Customer();
                    customerObj.Id = Convert.ToInt32(dr["Id"]);
                    customerObj.Name = dr["Name"].ToString();
                    customerObj.Code = dr["Code"].ToString();
                    customerObj.Address = dr["Address"].ToString();
                    customerObj.Email = dr["Email"].ToString();
                    customerObj.Contact = dr["Contact"].ToString();
                    customerObj.Age = Convert.ToInt32(dr["Age"]);
                    customerObj.LoyalityPoint = Convert.ToInt32(dr["LoyalityPoint"]);

                    dataList.Add(customerObj);
                }
            }

            sqlConnection.Close();

            return dataList;

        }

        public Customer GetById(int id)
        {
            string query = @"select *from Customers where Id = '" + id + "'";
            sqlCommand.CommandText = query;
            sqlConnection.Open();
            SqlDataReader dr = sqlCommand.ExecuteReader();
            if (dr.Read() && dr.HasRows)
            {
                var customerObj = new Customer();

                customerObj.Id = Convert.ToInt32(dr["Id"]);
                customerObj.Name = dr["Name"].ToString();
                customerObj.Code = dr["Code"].ToString();
                customerObj.Address = dr["Address"].ToString();
                customerObj.Email = dr["Email"].ToString();
                customerObj.Contact = dr["Contact"].ToString();
                customerObj.Age = Convert.ToInt32(dr["Age"]);
                customerObj.LoyalityPoint = Convert.ToInt32(dr["LoyalityPoint"]);

                sqlConnection.Close();
                return customerObj;
            }

            sqlConnection.Close();

            return null;
        }

        public bool  Update(Customer customer)
        {
            bool chk = false;

            string query = @"UPDATE Customers SET Name = '" + customer.Name + "',Code = '" + customer.Code + "',Address = '" + customer.Address + "',Email = '" +
                customer.Email + "',Contact= '" + customer.Contact + "',Age = " + customer.Age + ",LoyalityPoint = " + customer.LoyalityPoint + " WHERE Id = " + customer.Id;
            sqlCommand.CommandText = query;
            sqlConnection.Open();
            int isAffected = sqlCommand.ExecuteNonQuery();
            if (isAffected > 0)
            {
                chk = true;
            }
            sqlConnection.Close();
            return chk;
        }
    }
}