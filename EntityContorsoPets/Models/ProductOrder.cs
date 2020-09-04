using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;using System.Text;
using Microsoft.Data.SqlClient;

namespace EntityContorsoPets.Models
{
    public class ProductOrder
    {
        [Key]
        public int ProductOrderId { get; set; }
        public int Quantity { get; set; }
        public int ProductID { get; set; }
        public int OrderID { get; set; }
        public Order Order { get; set; }
        public Product Product { get; set; }

        public IList<ProductOrder> ListAllProductOrders()
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
                IList<ProductOrder> listProductOrders = new List<ProductOrder>();

                conn.Open(); //
                ER = cmd.ExecuteReader(); //

                /*  */
                if (ER.HasRows)
                {
                    while (ER.Read())
                    {
                        /*  */
                        ProductOrder productOrder = new ProductOrder();

                        //all collumns field
                        productOrder.ProductOrderId = Convert.ToInt32(ER["OrderID"]);
                        productOrder.Quantity = Convert.ToInt32(ER["Quantity"]);
                        productOrder.Product = ((Product)ER["OrderID"]);
                        productOrder.Order = ((Order)ER["OrderID"]);
                        productOrder.ProductID = Convert.ToInt32(ER["ProductID"]);
                        productOrder.OrderID = Convert.ToInt32(ER["OrderID"]);
                        listProductOrders.Add(productOrder);

                    }
                }

                return listProductOrders;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}