using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Microsoft.Data.SqlClient;

namespace EntityContorsoPets.Models
{
    public class Customer
    {
#nullable enable
        [Key]
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string email { get; set; }
#nullable disable
        public ICollection<Order> Orders { get; set; }

        public IList<Customer> ListAllProducts()
        {
            try
            {

                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=EntityContorsoPets;Integrated ecSurity=True; ConnectRetryCount=0";
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "SELECT * FROM dbo.Customers";
                cmd.Connection = conn;

                SqlDataReader ER;
                IList<Customer> listCustomers = new List<Customer>();

                conn.Open();
                ER = cmd.ExecuteReader();
                if (ER.HasRows)
                {
                    while (ER.Read())
                    {
                        Customer customer = new Customer();

                        customer.CustomerId = Convert.ToInt32(ER["ProductID"]);
                        customer.FirstName = Convert.ToString(ER["FirstName"]);
                        customer.LastName = Convert.ToString(ER["LastName"]);
                        customer.Address = Convert.ToString(ER["Address"]);
                        customer.Phone = Convert.ToString(ER["Phone"]);
                        customer.email = Convert.ToString(ER["email"]);                        
                        listCustomers.Add(customer);

                    }
                }

                return listCustomers;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
