using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL { 
    public class Pizza {
        private String name;
        private String description;
        private String type; // Small, Medium, Large
        private Double price;

        public string Name { get => name; set => name = value; }
        public string Description { get => description; set => description = value; }
        public string Type { get => type; set => type = value; }
        public double Price { get => price; set => price = value; }


    }
}
