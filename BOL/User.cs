using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL {
    public class User {
        private String username;
        private String email;
        private String password;
        private String role; // Customer, Admin

        public User() { }

        public User(String username, String email, String password, String role) {
            Username = username;
            Email = email;
            Password = password;
            Role = role;
        }

        public string Username { get => username; set => username = value; }
        public string Email { get => email; set => email = value; }
        public string Password { get => password; set => password = value; }
        public string Role { get => role; set => role = value; }
    }
}
