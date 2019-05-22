using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ASPGroupProject.Models
{
    public class ProductDA
    {
        private static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public static Product GetProductById(int id)
        {
            Product p = new Product();

            string statement = "select * from product where id = @id";
            SqlConnection con = new SqlConnection(GetConnectionString());
            SqlCommand query = new SqlCommand(statement, con);
            query.Parameters.AddWithValue("@id", id);
            con.Open();
            SqlDataReader reader = query.ExecuteReader(CommandBehavior.CloseConnection);
            query.Parameters.Clear();
            while (reader.Read())
            {
                p = new Product(reader["name"].ToString(), reader["description"].ToString(), reader["category"].ToString(), Convert.ToDecimal(reader["price"]), reader["image"].ToString(), Convert.ToInt16(reader["qty"]));
            }

            return p;
        }
    }
}