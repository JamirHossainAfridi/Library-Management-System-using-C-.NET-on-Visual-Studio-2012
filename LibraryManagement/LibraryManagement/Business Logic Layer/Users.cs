using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagement.Data_Access_Layer;

namespace LibraryManagement.Business_Logic_Layer
{
    class Users
    {
        public string Name {get;set; }
        public string Password {get;set; }

        User_Data ud = new User_Data();
        Users us;
        public List<Users> GetUsers(string name,string password)
        {
            var users = ud.GetUsers(name, password);
            List<Users> list = new List<Users>();
            for (int i = 0; i < users.Rows.Count; i++)
            {
                us = new Users();
                us.Name = users.Rows[i][0].ToString();
               us.Password =users.Rows[i][1].ToString();
                
                list.Add(us);
            }
            return list;
        }
    }
}
