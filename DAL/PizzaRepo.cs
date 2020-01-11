using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using BOL;

namespace DAL { 
    public class PizzaRepo {

        public static String connString = string.Empty;
        static PizzaRepo() {
            connString = ConfigurationManager.ConnectionStrings["pizzadb"].ConnectionString;
        }

        // Get all pizzas
        public static List<Pizza> GetPizzas() {
            List<Pizza> pizzas = new List<Pizza>();

            string cmdText = "SELECT * FROM Pizza";
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = connString;

            SqlCommand cmd = new SqlCommand(cmdText, conn as SqlConnection);

            try {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read()) {
                    Pizza pizza = new Pizza();
                    pizza.Name = reader["name"].ToString();
                    pizza.Description = reader["description"].ToString();
                    pizza.Type = reader["type"].ToString();
                    pizza.Price = Double.Parse(reader["price"].ToString());

                    pizzas.Add(pizza);
                }
                reader.Close();
            }
            catch (SqlException e) {
                throw e;
            }
            finally {
                conn.Close();
            }

            return pizzas;

        }

        // Add Pizza

        // Remove Pizza
    }
}