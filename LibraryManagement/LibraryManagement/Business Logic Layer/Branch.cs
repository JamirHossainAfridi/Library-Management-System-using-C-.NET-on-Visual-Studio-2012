using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagement.Data_Access_Layer;
namespace LibraryManagement.Business_Logic_Layer
{
    public class Branch
    {
        public string Name{set;get; }



        Branch_Data bd = new Branch_Data();
        Branch b;

        public List<Branch> GetAllBranchs()
        {
            var branchs = bd.GetAllBranchs();
            List<Branch> list = new List<Branch>();
            for (int i = 0; i < branchs.Rows.Count; i++)
            {
                b = new Branch();
                b.Name = branchs.Rows[i][0].ToString();
             

                list.Add(b);
            }
            return list;
        }

        public bool CreateBranch(string name)
        {
            return bd.Insert(name);
        }
        public bool DeleteBranch(string name)
        {
            return bd.Delete(name);
            
        }
        public bool DeleteBranchBooks(string name)
        {
            return (bd.DeleteBranchBook(name));
        }

    }
}
