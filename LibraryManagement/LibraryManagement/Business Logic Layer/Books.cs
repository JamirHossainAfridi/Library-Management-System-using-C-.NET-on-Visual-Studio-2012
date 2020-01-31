using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagement.Data_Access_Layer;

namespace LibraryManagement.Business_Logic_Layer
{
   public class Books
    {
        public string B_Name { get; set; }
        public string Detail { get; set; }
        public string Author { get; set; }
        public string Publication { get; set;}
        public string Branch{ get; set; }
        public string Price{ get; set; }
        public int Quantity{ get; set; }
        public int AvQuantity { get; set; }
        public int IssQuantity { get; set; }
      

        Books_Data  bd = new Books_Data();
        Books b;
        public List<Books> GetAllBooks()
        {
            var books = bd.GetAllBooks();
            List<Books> list = new List<Books>();
            for (int i = 0; i < books.Rows.Count; i++)
            {
                b = new Books();
                b.B_Name = books.Rows[i][0].ToString();
                b.Detail = books.Rows[i][1].ToString();
                b.Author = books.Rows[i][2].ToString();
                b.Publication = books.Rows[i][3].ToString();
                b.Branch = books.Rows[i][4].ToString();
                b.Price = books.Rows[i][5].ToString();
                b.Quantity = int.Parse(books.Rows[i][6].ToString());
                b.Quantity = int.Parse(books.Rows[i][6].ToString());
                b.AvQuantity = int.Parse(books.Rows[i][7].ToString());

                list.Add(b);
            }
            return list;
        }
        public List<Books> GetAllBooks(string bname)
        {
            var books = bd.GetAllBooks(bname);
            List<Books> list = new List<Books>();
            for (int i = 0; i < books.Rows.Count; i++)
            {
                b = new Books();
                b.B_Name = books.Rows[i][0].ToString();
                b.Detail = books.Rows[i][1].ToString();
                b.Author = books.Rows[i][2].ToString();
                b.Publication = books.Rows[i][3].ToString();
                b.Branch = books.Rows[i][4].ToString();
                b.Price = books.Rows[i][5].ToString();
                b.Quantity = int.Parse(books.Rows[i][6].ToString());
                b.Quantity = int.Parse(books.Rows[i][6].ToString());
                b.AvQuantity = int.Parse(books.Rows[i][7].ToString());

                list.Add(b);
            }
            return list;
        }
        public List<Books> GetBooks(string Book)
        {
            var books = bd.GetBooks(Book);
            List<Books> list = new List<Books>();
            for (int i = 0; i < books.Rows.Count; i++)
            {
                b = new Books();
                b.B_Name = books.Rows[i][0].ToString();
                b.Detail = books.Rows[i][1].ToString();
                b.Author = books.Rows[i][2].ToString();
                b.Publication = books.Rows[i][3].ToString();
                b.Branch = books.Rows[i][4].ToString();
                b.Price = books.Rows[i][5].ToString();
                b.Quantity = int.Parse(books.Rows[i][6].ToString());
                b.AvQuantity = int.Parse(books.Rows[i][7].ToString());

                list.Add(b);
            }
            return list;
        }
        public bool CreateBooks(string name, string detail, string author, string publication, string branch, string price, int quantity, int av_quantity, int iss_quantity)
        {
            return bd.Insert(name,detail,author,publication,branch,price,quantity,av_quantity,iss_quantity);
        }
        public bool DeleteBook(string bname)
        {
            return bd.Delete(bname);
        }
        public bool AddQuantity(int quantity,string bname)
        {
            return bd.AddBook(quantity,bname);
        }
        public bool DeleteQuantity(int quantity,string bname)
        {
            return bd.DeleteBook(quantity,bname);
        }
        public bool AvilableQuantity(string bname)
        {
            return bd.UpdateAvailabeQuantity(bname);
        }
        public bool IsssueQuantity(string bname)
        {
            return bd.UpdateIssueQuantity(bname);
        }
    }
}
