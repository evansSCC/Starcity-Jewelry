using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ASPGroupProject.Models
{
    public class UserDA
    {
        private static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        }

        public static User GetUserById(int id)
        {
            User u = new User();

            string statement = "select Id, uname, password, email, bill_country, bill_address, bill_city, bill_state, bill_zip, phone from AspNetUsers where id = @id";
            SqlConnection con = new SqlConnection(GetConnectionString());
            SqlCommand query = new SqlCommand(statement, con);
            query.Parameters.AddWithValue("@id", id);
            con.Open();
            SqlDataReader reader = query.ExecuteReader(CommandBehavior.CloseConnection);
            query.Parameters.Clear();
            while (reader.Read())
            {
                //u = new User(Convert.ToInt16(reader["uID"]), reader["email"].ToString(), reader["bill_country"].ToString(), reader["bill_address"].ToString(), reader["bill_city"].ToString(), reader["bill_state"].ToString(), reader["bill_zip"].ToString(), reader["phone"].ToString());
            }
            reader.Close();
            return u;
        }

        public static User GetUserByEmail(string email)
        {
            User u = new User();

            string statement = "select Id, email, bill_country, bill_address, bill_city, bill_state, bill_zip, phone, uID, fName, lName from Users where email = @email";
            SqlConnection con = new SqlConnection(GetConnectionString());
            SqlCommand query = new SqlCommand(statement, con);
            query.Parameters.AddWithValue("@email", email);
            con.Open();
            SqlDataReader reader = query.ExecuteReader(CommandBehavior.CloseConnection);
            query.Parameters.Clear();
            while (reader.Read())
            {
                u = new User(Convert.ToInt16(reader["uID"]), reader["email"].ToString(), reader["bill_country"].ToString(), reader["bill_address"].ToString(), reader["bill_city"].ToString(), reader["bill_state"].ToString(), reader["bill_zip"].ToString(), reader["phone"].ToString(), reader["uID"].ToString(), reader["fName"].ToString(), reader["lName"].ToString(), reader["Suffix"].ToString());
            }
            reader.Close();
            return u;
        }

        public static List<User> GetAllUsers()
        {
            List<User> users = new List<User>();
            User u = new User();

            string statement = "select Id, uname, password, email, bill_country, bill_address, bill_city, bill_state, bill_zip, phone from AspNetUsers";
            SqlConnection con = new SqlConnection(GetConnectionString());
            SqlCommand query = new SqlCommand(statement, con);
            con.Open();
            SqlDataReader reader = query.ExecuteReader(CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                //TODO fix this; User class and external DB updated
                //u = new User(Convert.ToInt16(reader["Id"]), reader["uname"].ToString(), reader["password"].ToString(), reader["email"].ToString(), reader["bill_country"].ToString(), reader["bill_address"].ToString(), reader["bill_city"].ToString(), reader["bill_state"].ToString(), reader["bill_zip"].ToString(), reader["phone"].ToString());
                //users.Add(u);
            }
            reader.Close();

            return users;
        }
    }
}