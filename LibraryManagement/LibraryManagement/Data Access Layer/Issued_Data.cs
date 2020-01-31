using System;
using System.Data.SqlClient;
using System.Data;

namespace LibraryManagement.Data_Access_Layer
{
    public class Issued_Data
    {
        SqlConnection con;
        public Issued_Data()
        {
            con = new SqlConnection(@"Data Source=DESKTOP-I9E8UQR;Initial Catalog=Library_Managment;Integrated Security=True");
            //if (con.State == ConnectionState.Closed)
            //{
            //    con.Open();
            //}
        }

        public DataTable GetAllIsssueBooks()
        {
            string query = string.Format("SELECT * FROM books_issued");
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable GetAllIsssueBooks(string bname)
        {
            string query = string.Format("SELECT * FROM books_issued WHERE bname like'%{0}%' ",bname);
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }
        public DataTable GetIsssueBooks(string sid)
        {
          con.Open();
            string query = string.Format("SELECT * FROM books_issued  WHERE sid  like'%{0}%'", sid);
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }


        public bool InsertIssue(string sid,string sname,string sdepartment,string bname ,string issDate,string reDate,int panalty)
        {
            con.Open();
            string query = string.Format("INSERT INTO books_issued(sid,sname,sdepartment,bname,iss_date,ret_date,panalty) VALUES('{0}','{1}','{2}','{3}','{4}','{5}',{6})",sid,sname,sdepartment,bname,issDate,reDate,panalty );
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
        public bool UpdatePanalty()
        {
            

            string dat = DateTime.Now.ToString("dd-MM-yyyy");
            con.Open();
            string query = string.Format("UPDATE books_issued SET panalty=panalty+10 WHERE  '{0}' >ret_date and panalty=0  ", dat);
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
        public bool DeleteIssue(string id,string bname)
        {
            con.Open();
            string query = string.Format("DELETE FROM books_issued WHERE sid='{0}' and bname='{1}' ", id,bname);
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
