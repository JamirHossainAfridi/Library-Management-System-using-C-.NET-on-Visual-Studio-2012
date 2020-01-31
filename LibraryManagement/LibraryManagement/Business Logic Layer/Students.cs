using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagement.Data_Access_Layer;

namespace LibraryManagement.Business_Logic_Layer
{
    public class Students
    {
        public string ID{set;get;}
        public string Name{set;get;}
        public string Department{set;get;}
        public string Gender{set;get;}
        public string Dob{set;get;}
        public string Contact{set;get;}
        public int Panalty{set;get;}

        Students_Data sd = new Students_Data();
        Students s;


        public List<Students> GetAllStudent(string ID)
        {
            var students = sd.GetAllStudent(ID);
            List<Students> list = new List<Students>();
            for (int i = 0; i < students.Rows.Count; i++)
            {
                s = new Students();
                s.ID = students.Rows[i][0].ToString();
                s.Name = students.Rows[i][1].ToString();
                s.Department = students.Rows[i][2].ToString();
                s.Gender = students.Rows[i][3].ToString();
                s.Dob = students.Rows[i][4].ToString();
                s.Contact = students.Rows[i][5].ToString();
                s.Panalty = int.Parse(students.Rows[i][6].ToString());

                list.Add(s);
            }
            return list;
        }
        public List<Students> GetAllStudent()
        {
            var students = sd.GetAllStudent();
            List<Students> list = new List<Students>();
            for (int i = 0; i < students.Rows.Count; i++)
            {
                s = new Students();
                s.ID = students.Rows[i][0].ToString();
                s.Name = students.Rows[i][1].ToString();
                s.Department = students.Rows[i][2].ToString();
                s.Gender = students.Rows[i][3].ToString();
                 s.Dob = students.Rows[i][4].ToString();
                s.Contact = students.Rows[i][5].ToString();
                s.Panalty = int.Parse(students.Rows[i][6].ToString());

                list.Add(s);
            }
            return list;
        }
     
        public bool CreateStudents(string id, string name, string department, string gender, string dob, string contact,int panalty)
        {
            return sd.Insert(id,name,department,gender,dob,contact,panalty);
        }
        public bool UpdateStudent(string name, string department, string dob, string contact, int panalty,string id)
        {
            return sd.UpdateStudent(name,department,dob,contact,panalty,id);
        }
        public bool DeleteStudent(string id)
        {
            return sd.Delete(id);
        }
        public bool UpdatePanalty(string id, int panalty)
        {
            return(sd.UpdatePanalty(id,panalty));
        }
        public bool UpdateStudentPanalty(string id)
        {
            return (sd.UpdateStudentPanalty(id));
        }
        
       
    }
}
