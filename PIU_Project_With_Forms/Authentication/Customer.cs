using Authentication;
using System.IO;
using System;
using System.Reflection.Emit;
using System.Collections.Generic;


namespace Authentication
{
    public class Customer:User
    {
        int Buget;
  
        public Customer() : base()
        {
           Buget = 0;
        }

        public Customer(string fname,string lname,string username, string password, int buget, string type = "Customer")
        : base(fname, lname, username, password, type)
        {
            Buget = buget;
        }

        public Customer(long id,string fname, string lname, string username, string password, int buget, string type = "Customer")
        : base(id,fname, lname, username, password, type)
        {
            Buget = buget;
        }

        override public string FormatForData()
        {
            string format = String.Format("{1}{0}{2}{0}{3}{0}{4}{0}{5}{0}{6}{0}{7}",
                "_",
                base.getId(),
                base.getFirstName(),
                base.getLastName(),
                base.getUsername(),
                base.getPassword(),
                "CUSTOMER",
                Buget);
            return format;
        }

        public int GetBuget()
        {
            return this.Buget;
        }

        public void SetBuget(int value)
        {
            this.Buget = value;
        }

    }
}
