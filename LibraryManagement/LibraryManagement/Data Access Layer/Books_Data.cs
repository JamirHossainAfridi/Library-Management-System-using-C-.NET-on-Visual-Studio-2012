using System;
using System.Data.SqlClient;
using System.Data;

namespace LibraryManagement.Data_Access_Layer
{
    public class Books_Data
    {
         SqlConnection con;
        public Books_Data()
        {
            con = new SqlConnection(@"Data Source=DESKTOP-I9E8UQR;Initial Catalog=Library_Managment;Integrated Security=True");
            //if (con.State == ConnectionState.Closed)
            //{
            //    con.Open();
            //}
        }
        public DataTable GetAllBooks()
        {
            string query = string.Format("SELECT * FROM books");
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable GetAllBooks(string bName)
        {
            string query = string.Format("SELECT * FROM books WHERE b_name like '%{0}%'", bName);
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable GetBooks(string bName)
        {
            string query = string.Format("SELECT * FROM books WHERE b_name like '%{0}%'", bName);
            SqlCommand cmd = new SqlCommand(query, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            con.Close();
            return dt;

        }
        public bool Insert(string name, string detail, string author, string publication, string branch, string price, int quantity, int av_quantity, int iss_quantity)
        {
            con.Open();
            string query = string.Format("INSERT INTO books(b_name,detail,author,publication,branch,price,quantity,av_quantity,iss_quantity) VALUES('{0}','{1}','{2}','{3}','{4}','{5}',{6},{7},{8})", name, detail, author, publication, branch, price + ".00TK", quantity,av_quantity,iss_quantity);
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
        public bool Delete(string  bname)
        {
            con.Open();
            string query = string.Format("DELETE FROM books WHERE b_name='{0}' ", bname);
            SqlCommand cmd = new SqlCommand(query, con);
            int rows = -1;
            rows = cmd.ExecuteNonQuery();
            if (rows >= 0)
            {
                return true;
            }
            return false;
        }
        public bool AddBook(int quantity,string bname)
        {
            con.Open();
            string query = string.Format("UPDATE books SET quantity = quantity+{0},av_quantity=quantity+{0}  where b_name='{1}'", quantity,bname);
            SqlCommand cmd = new SqlCommand(query, con);
            int rows = -1;
            rows = cmd.ExecuteNonQuery();
            if (rows >= 0)
            {
                return true;
            }
            return false;
        }

        public bool DeleteBook(int quantity,string bname)
        {
            con.Open();
            string query = string.Format("UPDATE books SET quantity = quantity-{0},av_quantity=quantity-{0} where b_name='{1}'", quantity, bname);
            SqlCommand cmd = new SqlCommand(query, con);
            int rows = -1;
            rows = cmd.ExecuteNonQuery();
            if (rows >= 0)
            {
                return true;
            }
            return false;
        }
        public bool UpdateAvailabeQuantity(string bname)
        {
            con.Open();
            string query = string.Format("UPDATE books SET av_quantity=av_quantity-1 WHERE b_name ='{0}' ", bname);
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
        public bool UpdateIssueQuantity(string bname)
        {
            con.Open();
            string query = string.Format("UPDATE books SET av_quantity=av_quantity+1 WHERE b_name ='{0}' ", bname);
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
