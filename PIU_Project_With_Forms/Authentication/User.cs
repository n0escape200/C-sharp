using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication
{
    public class User
    {

        long Id;
        string FirstName;
        string LastName;
        string Username;
        string Password;
        string Type;

        public User() {
            Id = -1;
            FirstName = string.Empty;
            LastName = string.Empty;
            Username = string.Empty;
            Password = string.Empty;
        }

        public User(string fname,string lname,string username,string password,string type = "unknown") {
            Id = DateTime.Now.Ticks;
            FirstName = fname;
            LastName = lname;
            Username = username;
            Password = password;
            Type = type.ToUpper();
        }

        public User(long id,string fname, string lname, string username, string password, string type = "unknown")
        {
            Id = id;
            FirstName = fname;
            LastName = lname;
            Username = username;
            Password = password;
            Type = type.ToUpper();
        }

        virtual public string FormatForData()
        {
            string format = String.Format("{1}{0}{2}{0}{3}{0}{4}{0}{5}{0}{6}",
                "_",
                Id,
                FirstName,
                LastName,
                Username,
                Password,
                "UNKNOWN");
            return format;
        }

        //Getters

        public long getId()
        {
            return this.Id;
        }

        public string getFirstName()
        {
            return this.FirstName;
        }
        public string getLastName()
        {
            return this.LastName;
        }
        public string getUsername()
        {
            return this.Username;
        }

        public string getPassword()
        {
            return this.Password;
        }
        public string getType()
        {
            return this.Type;
        }

    }
}
