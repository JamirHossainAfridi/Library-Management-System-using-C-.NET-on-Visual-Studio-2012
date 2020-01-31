using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagement.Data_Access_Layer;

namespace LibraryManagement.Business_Logic_Layer
{
    public class Issued
    {
        public string SID { get; set; }
        public string SName { get; set; }
        public string SDepartment { get; set; }
        public string BName { get; set; }
        public string Issued_Date{ get; set; }
        public string Return_Date { get; set; }
        public int Panalty { get; set; }

        Issued_Data id = new Issued_Data();
        Issued iss;
        public List<Issued> GetAllIssueBooks()
        {
            var books = id.GetAllIsssueBooks();
            List<Issued> list = new List<Issued>();
            for (int i = 0; i < books.Rows.Count; i++)
            {
                iss = new Issued();

                iss.SID = books.Rows[i][0].ToString();
                iss.SName = books.Rows[i][1].ToString();
                iss.SDepartment = books.Rows[i][2].ToString();
                iss.BName = books.Rows[i][3].ToString();
                iss.Issued_Date = books.Rows[i][4].ToString();
                iss.Return_Date = books.Rows[i][5].ToString();

                iss.Panalty = int.Parse(books.Rows[i][6].ToString());
              

                list.Add(iss);
            }
            return list;
        }
        public List<Issued> GetAllIssueBooks(string bname)
        {
            var books = id.GetAllIsssueBooks(bname);
            List<Issued> list = new List<Issued>();
            for (int i = 0; i < books.Rows.Count; i++)
            {
                iss = new Issued();

                iss.SID = books.Rows[i][0].ToString();
                iss.SName = books.Rows[i][1].ToString();
                iss.SDepartment = books.Rows[i][2].ToString();
                iss.BName = books.Rows[i][3].ToString();
                iss.Issued_Date = books.Rows[i][4].ToString();
                iss.Return_Date = books.Rows[i][5].ToString();
                iss.Panalty = int.Parse(books.Rows[i][6].ToString());

                list.Add(iss);
            }
            return list;
        }

        public List<Issued> GetIssueBooks(string sid)
        {
            var books = id.GetIsssueBooks(sid);
            List<Issued> list = new List<Issued>();
            for (int i = 0; i < books.Rows.Count; i++)
            {
                iss = new Issued();

                iss.SID = books.Rows[i][0].ToString();
                iss.SName = books.Rows[i][1].ToString();
                iss.SDepartment = books.Rows[i][2].ToString();
                iss.BName = books.Rows[i][3].ToString();
                iss.Issued_Date = books.Rows[i][4].ToString();
                iss.Return_Date = books.Rows[i][5].ToString();
                iss.Panalty = int.Parse(books.Rows[i][6].ToString());

                list.Add(iss);
            }
            return list;
        }
        public bool CreatIssue(string sid, string sname, string sdepartment, string bname, string issDate, string reDate,int panalty)
        {
            return (id.InsertIssue(sid,sname,sdepartment,bname,issDate,reDate,panalty));
        }
        public bool UpdatePanalty()
        {
            return (id.UpdatePanalty());
        }
        public bool DeleteIssue(string sid,string bname)
        {
            return(id.DeleteIssue(sid,bname));
        }
    }
}
