using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Microsoft.Data.SqlClient;

namespace EntityContorsoPets.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public DateTime OrderPlacedDate { get; set; }
        public DateTime? OrderFufilled { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public ICollection<ProductOrder> ProductOrders { get; set; }

        /*  */
        public IList<Order> ListAllOrders()
        {
            try
            {
                /*  */
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=EntityContorsoPets;Integrated ecSurity=True; ConnectRetryCount=0";
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "SELECT * FROM dbo.Customers";
                cmd.Connection = conn;

                /*  */
                SqlDataReader ER;
                IList<Order> listOrders = new List<Order>();

                conn.Open(); //
                ER = cmd.ExecuteReader(); //

                /*  */
                if (ER.HasRows)
                {
                    while (ER.Read())
                    {
                        /*  */
                        Order order = new Order();

                        //all collumns field
                        order.OrderId = Convert.ToInt32(ER["OrderID"]);
                        order.OrderPlacedDate = Convert.ToDateTime(ER["OrderPlacedDate"]);
                        order.OrderFufilled = Convert.ToDateTime(ER["OrderFufilled"]);
                        order.CustomerId = Convert.ToInt32(ER["CustomerID"]);
                        order.Customer = ((Customer)ER["Customer"]);
                        listOrders.Add(order);

                    }
                }

                return listOrders;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
