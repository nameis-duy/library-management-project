using BusinessObject;
using DataAccess.Repository;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class StudentDAO : BaseDAL
    {
        private static StudentDAO? instance = null;
        private static readonly Object instanceLock = new object();
        private StudentDAO() { }
        public static StudentDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null) instance = new StudentDAO();
                }
                return instance;
            }
        }

        public IEnumerable<Student> GetStudentList()
        {
            IDataReader? dataReader = null;
            string SQLSelect = "SELECT studentID, name, generation, gender, DOB, debt FROM tblStudent";
            List<Student> list = new List<Student>();
            try
            {
                dataReader = dataProvider.GetDataReader(SQLSelect, CommandType.Text, out connection);
                while (dataReader.Read())
                {
                    Student student = new Student
                    {
                        StudentID = dataReader.GetInt32(0),
                        Name = dataReader.GetString(1),
                        Generation = dataReader.GetString(2),
                        Gender = dataReader.GetBoolean(3),
                        DOB = dataReader.GetDateTime(4),
                        Debt = dataReader.GetDouble(5)
                        
                    };
                    list.Add(student);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (dataReader != null) dataReader.Close();
                CloseConnection();
            }
            return list;
        }        
        //public Student GetProductByID(int id)
        //{
        //    Student Student = null;
        //    IDataReader dataReader = null;
        //    string SQLSelect = "SELECT ProductID, CategoryId, ProductName, Weight, UnitPrice, UnitInStock"
        //                     + " FROM Student WHERE ProductID = @ProductID";
        //    try
        //    {
        //        var param = dataProvider.CreateParameter("@ProductID", 4, id, DbType.Int32);
        //        dataReader = dataProvider.GetDataReader(SQLSelect, CommandType.Text, out connection, param);
        //        if (dataReader.Read())
        //        {
        //            Student = new Student
        //            {
        //                ProductId = id,
        //                ProductCategoryId = dataReader.GetInt32(1),
        //                ProductName = dataReader.GetString(2),
        //                Weight = dataReader.GetString(3),
        //                UnitPrice = dataReader.GetDecimal(4),
        //                UnitInStock = dataReader.GetInt32(5)
        //            };
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //    finally
        //    {
        //        if (dataReader != null)
        //            dataReader.Close();
        //        CloseConnection();
        //    }
        //    return Student;
        //}
        public void AddStudent(Student Student)
        {
            try
            {
                string SQLUpdate = "INSERT tblStudent VALUES (@studentID, @name, @generation, @gender, @DOB, @debt)";
                var parameters = new List<SqlParameter>();
                parameters.Add(dataProvider.CreateParameter("@studentID", 4, Student.StudentID, DbType.Int32));
                parameters.Add(dataProvider.CreateParameter("@name", 50, Student.Name, DbType.String));
                parameters.Add(dataProvider.CreateParameter("@generation", 3, Student.Generation, DbType.String));
                parameters.Add(dataProvider.CreateParameter("@gender", 1, Student.Gender, DbType.Boolean));
                parameters.Add(dataProvider.CreateParameter("@DOB", 8, Student.DOB, DbType.DateTime));
                parameters.Add(dataProvider.CreateParameter("@debt", 16, Student.Debt, DbType.Double));
                dataProvider.UpdateDB(SQLUpdate, CommandType.Text, parameters.ToArray());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }
        public void UpdateStudent(Student Student)
        {
            try
            {
                string SQLUpdate = "UPDATE tblStudent SET name = @name, generation = @generation,"
                                 + " gender = @gender, DOB = @DOB, debt = @debt WHERE studentID = @studentID";
                var parameters = new List<SqlParameter>();
                parameters.Add(dataProvider.CreateParameter("@studentID", 4, Student.StudentID, DbType.Int32));
                parameters.Add(dataProvider.CreateParameter("@name", 50, Student.Name, DbType.String));
                parameters.Add(dataProvider.CreateParameter("@generation", 3, Student.Generation, DbType.String));
                parameters.Add(dataProvider.CreateParameter("@gender", 1, Student.Gender, DbType.Boolean));
                parameters.Add(dataProvider.CreateParameter("@DOB", 8, Student.DOB, DbType.DateTime));
                parameters.Add(dataProvider.CreateParameter("@debt", 16, Student.Debt, DbType.Double));
                dataProvider.UpdateDB(SQLUpdate, CommandType.Text, parameters.ToArray());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                CloseConnection();
            }
        }
        //public void RemoveProduct(int productId)
        //{
        //    try
        //    {
        //        string SQLUpdate = "DELETE Student WHERE ProductId = @ProductID";
        //        var parameter = dataProvider.CreateParameter("@ProductID", 4, productId, DbType.Int32);
        //        dataProvider.UpdateDB(SQLUpdate, CommandType.Text, parameter);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    }
        //    finally
        //    {
        //        CloseConnection();
        //    }
        //}
    }
}
