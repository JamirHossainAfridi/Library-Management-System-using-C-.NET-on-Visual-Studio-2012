using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagement.Data_Access_Layer;
namespace LibraryManagement.Business_Logic_Layer
{
    public class Department
    {
        public string Name { set; get; }



        Branch_Data d = new Branch_Data();
        Department b;

        public List<Department> GetAllBranchs()
        {
            var branchs = bd.GetAllBranchs();
            List<Department> list = new List<Department>();
            for (int i = 0; i < branchs.Rows.Count; i++)
            {
                b = new Department();
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

    }
}
