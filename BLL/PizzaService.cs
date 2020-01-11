using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BOL;
using DAL;

namespace BLL
{
    public class PizzaService {
        // Get all pizzas
        public static List<Pizza> GetAllPizzas() {
            return PizzaRepo.GetPizzas();
        }


    }
    
}
