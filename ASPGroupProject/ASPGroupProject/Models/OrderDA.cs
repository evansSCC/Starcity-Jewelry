using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ASPGroupProject.Models
{
    public class OrderDA
    {
        private static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public static Order GetOrderById(int id)
        {
            Order o = new Order();
            List<Product> list = GetAllProductsInOrder(id);
            string statement = "select * from orders where id = @id";
            SqlConnection con = new SqlConnection(GetConnectionString());
            SqlCommand query = new SqlCommand(statement, con);
            query.Parameters.AddWithValue("@id", id);
            con.Open();
            SqlDataReader reader = query.ExecuteReader(CommandBehavior.CloseConnection);
            query.Parameters.Clear();
            while (reader.Read())
            {
                o = new Order(Convert.ToInt16(reader["id"]), list, reader["u_id"].ToString(), Convert.ToDateTime(reader["date"]), true);
            }
            reader.Close();
            return o;
        }

        public static List<Product> GetAllProductsInOrder(int orderId)
        {
            List<Product> products = new List<Product>();

            string statement = "Select Product.Id, Product.name, Product.price, Product.qty, Product.description, Product.category, Product.image FROM Product INNER JOIN product_order ON product_order.product_id = Product.Id WHERE product_order.order_id = @id";
            SqlConnection con = new SqlConnection(GetConnectionString());
            SqlCommand query = new SqlCommand(statement, con);
            query.Parameters.AddWithValue("@id", orderId);
            con.Open();
            SqlDataReader reader = query.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                Product p = new Product(Convert.ToInt16(reader["id"]), reader["name"].ToString(), reader["description"].ToString(), reader["category"].ToString(), Convert.ToDecimal(reader["price"]), reader["image"].ToString(), Convert.ToInt16(reader["qty"]));
                products.Add(p);
            }
            reader.Close();

            return products;
        }

        public static void AddNewOrder(String userID, String address, String city, String state, String zip, String country)
        {
            string statement = "INSERT INTO Orders (u_id, ship_address, ship_city, ship_state, ship_zip, ship_country) VALUES (@userID, @address, @city, @state,@zip, @country)";
            SqlConnection con = new SqlConnection(GetConnectionString());
            SqlCommand insert = new SqlCommand(statement, con);
            insert.Parameters.AddWithValue("@userID", userID);
            insert.Parameters.AddWithValue("@address", address);
            insert.Parameters.AddWithValue("@city", city);
            insert.Parameters.AddWithValue("@state", state);
            insert.Parameters.AddWithValue("@zip", zip);
            insert.Parameters.AddWithValue("@country", country);
            con.Open();
            SqlDataReader reader = insert.ExecuteReader(CommandBehavior.CloseConnection);
            reader.Close();
        }

        public static void AddOrderItems(int OrderID, List<Product> cart)
        {
            foreach (Product p in cart)
            {
                string statement = "INSERT INTO product_orders (order_id, product_id, qty) VALUES (@oid, @pid, @qty)";
                SqlConnection con = new SqlConnection(GetConnectionString());
                SqlCommand insert = new SqlCommand(statement, con);
                insert.Parameters.AddWithValue("@oid", OrderID);
                insert.Parameters.AddWithValue("@pid", p.Id);
                insert.Parameters.AddWithValue("@qty", 1);
                con.Open();
                SqlDataReader reader = insert.ExecuteReader(CommandBehavior.CloseConnection);
                reader.Close();
            }
            
        }

}
}