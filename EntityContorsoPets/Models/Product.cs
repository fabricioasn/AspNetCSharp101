using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Microsoft.Data.SqlClient;
using EntityContorsoPets.Data;

namespace EntityContorsoPets.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required]
        public string name { get; set; }

        [Column(TypeName ="decimal(18,2)")]
        public decimal price { get; set; }

        /* Method ListAllProducts: return the Object list of Product class wich contains all its attributes, 
         * while acess the database to get the ORM dbo.Products table columns*/
        public IList<Product> ListAllProducts()
        {
            try { 
            
            /* Database Connection Start
             * Selection of all collumns from table dbo.Products*/ 
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=EntityContorsoPets;Integrated ecSurity=True; ConnectRetryCount=0";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "SELECT * FROM dbo.Products";
            cmd.Connection = conn;

            /* the DataReader Type var catches the data from DB transformationg the Entities on Objects */
            SqlDataReader ER;
            IList<Product> listProducts = new List<Product>();

            conn.Open(); // connection efective opening
            ER = cmd.ExecuteReader(); /* executes the sql command method of var CMD 
                                     * and assigns it to the ER data reader var */
            /* the linq method HasRows counts if exists registers to validate and send them to the list */
            if (ER.HasRows)
            {
                while (ER.Read())
                {
                    /* whhile each register is readed, a product object is created and it's added on list, 
                     * if it has registers */
                    Product product = new Product();

                    //all collumns field
                    product.ProductId = Convert.ToInt32(ER["ProductID"]);
                    product.name = Convert.ToString(ER["name"]);
                    product.price = Convert.ToDecimal(ER["price"]);
                    listProducts.Add(product);

                }
            }

            return listProducts;
            }catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
