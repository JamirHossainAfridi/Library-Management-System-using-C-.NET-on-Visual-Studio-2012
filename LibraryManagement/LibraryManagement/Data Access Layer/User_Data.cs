using System;
using System.Data.SqlClient;
using System.Data;

namespace LibraryManagement.Data_Access_Layer
{
    class User_Data
    {
        SqlConnection con;
        public User_Data()
        {
            con = new SqlConnection(@"Data Source=DESKTOP-I9E8UQR;Initial Catalog=Library_Managment;Integrated Security=True");
            //if (con.state == connectionstate.closed)
            //{
            //    con.open();
            //}
        }
        public DataTable GetUsers(string name, string password)
        {
            con.Open();
            string query = string.Format("SELECT * FROM Users WHERE username='{0}'and password='{1}'", name, password);
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;

        }
    }
}
