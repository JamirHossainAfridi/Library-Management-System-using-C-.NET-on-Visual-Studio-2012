using System;
using System.Data.SqlClient;
using System.Data;

namespace LibraryManagement.Data_Access_Layer
{
    public class Students_Data
    {
         SqlConnection con;
         public Students_Data()
         {
             con = new SqlConnection(@"Data Source=DESKTOP-I9E8UQR;Initial Catalog=Library_Managment;Integrated Security=True");
             //if (con.state == connectionstate.closed)
             //{
             //    con.open();
             //}
         }
        
         public DataTable GetAllStudent(string id)
         {
             con.Open();
             string query = string.Format("SELECT * FROM students WHERE id like '%{0}%'", id);
             SqlCommand cmd = new SqlCommand(query, con);
             SqlDataAdapter da = new SqlDataAdapter(cmd);
             DataTable dt = new DataTable();
             da.Fill(dt);
             con.Close();
             return dt;

         }
         public DataTable GetAllStudent()
         {
             string query = string.Format("SELECT * FROM students");
             SqlCommand cmd = new SqlCommand(query, con);
             SqlDataAdapter da = new SqlDataAdapter(cmd);
             DataTable dt = new DataTable();
             da.Fill(dt);
             con.Close();
             return dt;

         }
    
         public bool Insert(string id,string name,string department,string gender,string dob,string contact,int panalty)
         {

             con.Open();
             string query = string.Format("INSERT INTO students(id,name,department,gender,dob,contact,panalty) VALUES('{0}','{1}','{2}','{3}','{4}','{5}',{6})", id, name, department, gender, dob, contact,panalty);
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
         public bool UpdateStudent(string name,string department,string dob,string contact,int panalty,string id)
         {
             con.Open();
             string query = string.Format("UPDATE students SET name ='{0}',department='{1}', dob='{2}',contact='{3}',panalty={4} where id='{5}'", name, department, dob, contact, panalty,id);
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
         public bool Delete(string id)
         {
             con.Open();
             string query = string.Format("DELETE FROM students WHERE id='{0}' ", id);
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
         public bool UpdatePanalty(string id,int panalty)
         {
             //con.Open();
             string query = string.Format("UPDATE students SET panalty={1} WHERE id='{0}' ",id,panalty);
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

         public bool UpdateStudentPanalty(string id)
         {
             //UpdateSPanalty();

             con.Open();
             string query = string.Format("UPDATE students SET panalty=(SELECT sum(panalty) FROM books_issued WHERE  panalty is not null and sid='{0}'  and (SELECT count(sid) FROM books_issued where panalty is not null and sid='{0}' )>0) where id='{0}' ",id );         
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
