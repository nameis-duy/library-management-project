using BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repository
{
    public  class StudentRepository : IStudentRepository
    {
        public IEnumerable<Student> GetAllStudents() => StudentDAO.Instance.GetStudentList();
        public void AddStudent(Student student) => StudentDAO.Instance.AddStudent(student);
        public void UpdateStudent(Student student) => StudentDAO.Instance.UpdateStudent(student);
    }
}
