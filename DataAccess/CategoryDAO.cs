using BusinessObject;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class CategoryDAO : BaseDAL
    {
        private static CategoryDAO? instance = null;
        private static readonly Object instanceLock = new object();
        private CategoryDAO() { }
        public static CategoryDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null) instance = new CategoryDAO();
                }
                return instance;
            }
        }
        public IEnumerable<Category> GetAllCategory()
        {
            List<Category> list = new List<Category>();
            IDataReader? dataReader = null;
            string SQLSelect = "SELECT categoryID, categoryTitle FROM tblCategory";
            try
            {
                dataReader = dataProvider.GetDataReader(SQLSelect, CommandType.Text, out connection);
                while (dataReader.Read())
                {
                    Category category = new Category
                    {
                        CategoryID = dataReader.GetInt32(0),
                        CategoryTitle = dataReader.GetString(1)
                    };
                    list.Add(category);
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
        public Category? GetCategoryByID(int categoryID)
        {
            Category? category = null;
            IDataReader? dataReader = null;
            string SQLSelect = "SELECT categoryTitle FROM tblCategory WHERE categoryID = @categoryID";
            try
            {
                var param = dataProvider.CreateParameter("@categoryID", 4, categoryID, DbType.Int32);
                dataReader = dataProvider.GetDataReader(SQLSelect, CommandType.Text, out connection, param);
                if (dataReader.Read())
                {
                    category = new Category
                    {
                        CategoryID = categoryID,
                        CategoryTitle = dataReader.GetString(0)
                    };
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
            return category;
        }
    }
}
