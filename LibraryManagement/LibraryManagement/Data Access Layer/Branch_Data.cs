using System;
using System.Data.SqlClient;
using System.Data;

namespace LibraryManagement.Data_Access_Layer
{
    public class Branch_Data
    {
        SqlConnection con;
        public Branch_Data()
        {
            con = new SqlConnection(@"Data Source=DESKTOP-I9E8UQR;Initial Catalog=Library_Managment;Integrated Security=True");
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
        }

        public DataTable GetAllBranchs()
        {
            string query = string.Format("SELECT * FROM branchs");
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
            
        }
        public bool Insert(string name)
        {
            con.Open();
            string query = string.Format("INSERT INTO branchs(name) VALUES('{0}')", name);
            SqlCommand cmd = new SqlCommand(query, con);
            int rows = -1;
            rows = cmd.ExecuteNonQuery();
            if (rows >= 0)
            {
                return true;
            }
            return false;
        }
        public bool Delete(string name)
        {
            con.Open();
            string query = string.Format("DELETE FROM branchs WHERE name='{0}' ", name);
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
        public bool DeleteBranchBook(string branchName)
        {
            con.Open();
            string query = string.Format("DELETE FROM books WHERE branch='{0}' ", branchName);
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
        //~Branch_Data()
    
        //{
        //if (con.State == ConnectionState.Open)
        //    {
        //        con.Close();
        //    }
        //  }

    }
}
