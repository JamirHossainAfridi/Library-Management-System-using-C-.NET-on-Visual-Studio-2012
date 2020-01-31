using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagement.Data_Access_Layer;

namespace LibraryManagement.Business_Logic_Layer
{
    public class Publication
    {
        public string P_Name { set; get; }



        Publications_Data pd = new Publications_Data();
        Publication p;

        public List<Publication> GetAllPublication()
        {
            var publications = pd.GetAllPublication();
            List<Publication> list = new List<Publication>();
            for (int i = 0; i < publications.Rows.Count; i++)
            {
                p = new Publication();
                p.P_Name = publications.Rows[i][0].ToString();


                list.Add(p);
            }
           
            return list;
        }

        public bool CreatePublication(string name)
        {
            return pd.Insert(name);
        }
        public bool DeletePublication(string name)
        {
            return pd.Delete(name);

        }
        public bool DeletePublicationBooks(string pName)
        {
            return (pd.DeletPublicationBook(pName));
        }

    }
}
