using System;
using System.Data.SqlClient;
using System.Data;

namespace LibraryManagement.Data_Access_Layer
{
    public class Publications_Data
    {
  
        SqlConnection con;
        public Publications_Data()
        {
            con = new SqlConnection(@"Data Source=DESKTOP-I9E8UQR;Initial Catalog=Library_Managment;Integrated Security=True");
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
        }

        public DataTable GetAllPublication()
        {
        
            string query = string.Format("SELECT * FROM publications");
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
            
        }
        public bool Insert(string pname)
        {
            con.Open();
            string query = string.Format("INSERT INTO publications(pname) VALUES('{0}')", pname);
            SqlCommand cmd = new SqlCommand(query, con);
            int rows = -1;
            rows = cmd.ExecuteNonQuery();
            //con.Close();
            if (rows >= 0)
            {
                return true;
            }
            return false;
        }
        public bool Delete(string pname)
        {
            con.Open();
            string query = string.Format("DELETE FROM publications WHERE pname='{0}' ", pname);
            SqlCommand cmd = new SqlCommand(query, con);
            int rows = -1;
            rows = cmd.ExecuteNonQuery();
            con.Close();
            if (rows >= 0)
            {
                return true;
            }
            return false;
        }
        public bool DeletPublicationBook(string pName)
        {
            con.Open();
            string query = string.Format("DELETE FROM books WHERE publication='{0}' ", pName);
            SqlCommand cmd = new SqlCommand(query, con);
            int rows = -1;
            rows = cmd.ExecuteNonQuery();
            con.Close();
            if (rows >= 0)
            {
                return true;
            }
            return false;
        }
    }
}
