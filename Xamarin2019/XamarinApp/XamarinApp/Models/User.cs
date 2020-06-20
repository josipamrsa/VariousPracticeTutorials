using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;


namespace XamarinApp.Models
{
    public class User
    {
        [PrimaryKey]
        [AutoIncrement]
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public User() { }
        public User(string username, string password)
        {
            this.Username = username;
            this.Password = password;
        }

        public bool CheckInformation()
        {
            if (this.Username.Equals("") && this.Password.Equals(""))
                return false;
            else
                return true;
        }
    }
}
