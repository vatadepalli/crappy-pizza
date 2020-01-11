using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using BOL;

namespace DAL {
    public class UserRepo {

        public static String connString = string.Empty;
        static UserRepo() {
            connString = ConfigurationManager.ConnectionStrings["pizzadb"].ConnectionString;
        }

        // Get User
        public static User GetUser(String email) {
            User user = null;

            string cmdText = "SELECT * FROM Members WHERE email = @email";
            /*string cmdText = "SELECT * FROM Pizza";*/
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = connString;

            SqlCommand cmd = new SqlCommand(cmdText, conn as SqlConnection);
           cmd.Parameters.AddWithValue("email", email);


            try {
                conn.Open();

                SqlDataReader reader = cmd.ExecuteReader();

             
                if (reader.Read()) {
                    user = new User();
                    user.Username = reader["username"].ToString();
                    user.Email = reader["email"].ToString();
                    user.Password = reader["password"].ToString();
                    user.Role = reader["role"].ToString();
                }
             
                reader.Close();
            }
            catch (SqlException e) {
                throw e;
            }
            finally {
                conn.Close();
            }

            return user;

        }

        public static void AddUser(User user) {
            string cmdText = "INSERT INTO Members(username, email, password, role) VALUES(@username, @email, @password, @role)";
            /*string cmdText = "SELECT * FROM Pizza";*/
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = connString;

            SqlCommand cmd = new SqlCommand(cmdText, conn as SqlConnection);
            cmd.Parameters.AddWithValue("username", user.Username);
            cmd.Parameters.AddWithValue("email", user.Email);
            cmd.Parameters.AddWithValue("password", user.Password);
            cmd.Parameters.AddWithValue("role", user.Role);

            try {
                conn.Open();

                cmd.ExecuteNonQuery();
            }
            catch (SqlException e) {
                throw e;
            }
            finally {
                conn.Close();
            }
        }
    }
}
