using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Authentication
{
    public class HandleUsers
    {
        public string adminFile = "../../../Authentication/Admin.txt";
        public string customerFile = "../../../Authentication/Customer.txt";

        public void Register(User user)
        {
            using (StreamWriter sw = new StreamWriter(user.getType() == "ADMIN" ? adminFile:customerFile,true))
            {
                sw.WriteLine(user.FormatForData());
                sw.Close();
            }
        }

         public long Login(string username, string password, int code = 0)
        {
            using (StreamReader sw = new StreamReader(code != 0 ? adminFile:customerFile))
            {
                string line;
                char[] separator = { '_' };
                while ((line = sw.ReadLine()) != null)
                {
                    string[] aux = line.Split(separator);
                    if ((aux[3] == username) && (aux[4] == password))
                    {
                        
                        if(code != 0 && code != 35057)
                        {
                            return 0;
                        }
                        sw.Close();
                        
                        return long.Parse(aux[0]);
                    }
                }
                sw.Close();
            }
            return 0;
        }

        public User getUserById(long id)
        {
            using (StreamReader sw = new StreamReader(adminFile))
            {
                string line;
                char[] separator = { '_' };
                while ((line = sw.ReadLine()) != null)
                {
                    string[] aux = line.Split(separator);
                    if (long.Parse(aux[0]) == id)
                    {
                        sw.Close();
                        return new Admin(long.Parse(aux[0]), aux[1], aux[2], aux[3], aux[4], aux[5]);
                    }
                }
            }
            using (StreamReader sw = new StreamReader(customerFile))
            {
                string line;
                char[] separator = { '_' };
                while ((line = sw.ReadLine()) != null)
                {
                    string[] aux = line.Split(separator);
                    if (long.Parse(aux[0]) == id)
                    {
                        sw.Close();
                        return new Customer(long.Parse(aux[0]), aux[1], aux[2], aux[3], aux[4], Int32.Parse(aux[6]), aux[5]);
                    }
                }
            }
            return new User();
        }
    }
}
