using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication
{
    public class Admin: User
    {
        int code = 35057;
        
        public Admin():base() { }


        public Admin(string fname, string lname,string username, string password, string type = "Admin") 
            :base(fname,lname,username,password,type) {
        }

        public Admin(long id,string fname, string lname, string username, string password, string type = "Admin") 
            : base(id,fname, lname, username, password, type)
        {
        }


        override public string FormatForData()
        {
            string format = String.Format("{1}{0}{2}{0}{3}{0}{4}{0}{5}{0}{6}",
                "_",
                base.getId(),
                base.getFirstName(),
                base.getLastName(),
                base.getUsername(),
                base.getPassword(),
                "ADMIN");
            return format;
        }

        public int getCode()
        {
            return this.code;
        }
    }
}
