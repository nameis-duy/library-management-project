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
    public class BookDAO : BaseDAL
    {
        private static BookDAO? instance = null;
        private static readonly Object instanceLock = new object();
        private BookDAO() { }
        public static BookDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null) instance = new BookDAO();
                }
                return instance;
            }
        }

        public IEnumerable<Book> GetBookList()
        {
            IDataReader? dataReader = null;
            string SQLSelect = "SELECT bookID, title, categoryID, printer, author, publishYear, quantity, price FROM tblBook";
            List<Book> list = new List<Book>();
            try
            {
                dataReader = dataProvider.GetDataReader(SQLSelect, CommandType.Text, out connection);
                while (dataReader.Read())
                {
                    int categoryID = dataReader.GetInt32(2);
                    ICategoryRepository repo = new CategoryRepository();
                    Category? category = repo.GetCategoryByID(categoryID);
                    Book book = new Book
                    {
                        BookID = dataReader.GetInt32(0),
                        Title = dataReader.GetString(1),
                        Category = category,
                        Printer = dataReader.GetString(3),
                        Author = dataReader.GetString(4),
                        PublishYear = dataReader.GetString(5),
                        Quantity = dataReader.GetInt32(6),
                        Price = dataReader.GetDouble(7)
                    };
                    list.Add(book);
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
        public int GetNextSeed()
        {
            return GetNextSeed("tblBook");
        }
        //public Book GetProductByID(int id)
        //{
        //    Book Book = null;
        //    IDataReader dataReader = null;
        //    string SQLSelect = "SELECT ProductID, CategoryId, ProductName, Weight, UnitPrice, UnitInStock"
        //                     + " FROM Book WHERE ProductID = @ProductID";
        //    try
        //    {
        //        var param = dataProvider.CreateParameter("@ProductID", 4, id, DbType.Int32);
        //        dataReader = dataProvider.GetDataReader(SQLSelect, CommandType.Text, out connection, param);
        //        if (dataReader.Read())
        //        {
        //            Book = new Book
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
        //    return Book;
        //}
        public void AddBook(Book Book)
        {
            try
            {
                string SQLUpdate = "INSERT tblBook VALUES (@title, @categoryID, @printer, @author, @publishYear, @quantity, @price)";
                var parameters = new List<SqlParameter>();
                parameters.Add(dataProvider.CreateParameter("@title", 30, Book.Title, DbType.String));
                parameters.Add(dataProvider.CreateParameter("@CategoryID", 4, Book.Category.CategoryID, DbType.Int32));
                parameters.Add(dataProvider.CreateParameter("@printer", 50, Book.Printer, DbType.String));
                parameters.Add(dataProvider.CreateParameter("@author", 20, Book.Author, DbType.String));
                parameters.Add(dataProvider.CreateParameter("@publishYear", 4, Book.PublishYear, DbType.String));
                parameters.Add(dataProvider.CreateParameter("@quantity", 16, Book.Quantity, DbType.Int32));
                parameters.Add(dataProvider.CreateParameter("@price", 4, Book.Price, DbType.Double));
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
        public void UpdateBook(Book Book)
        {
            try
            {
                string SQLUpdate = "UPDATE tblBook SET categoryID = @CategoryID, title = @title,"
                                 + " printer = @printer, author = @author, publishYear = @publishYear, quantity = @quantity, price = @price WHERE bookID = @bookID";
                var parameters = new List<SqlParameter>();
                parameters.Add(dataProvider.CreateParameter("@title", 30, Book.Title, DbType.String));
                parameters.Add(dataProvider.CreateParameter("@CategoryID", 4, Book.Category.CategoryID, DbType.Int32));
                parameters.Add(dataProvider.CreateParameter("@printer", 50, Book.Printer, DbType.String));
                parameters.Add(dataProvider.CreateParameter("@author", 20, Book.Author, DbType.String));
                parameters.Add(dataProvider.CreateParameter("@publishYear", 4, Book.PublishYear, DbType.String));
                parameters.Add(dataProvider.CreateParameter("@quantity", 16, Book.Quantity, DbType.Int32));
                parameters.Add(dataProvider.CreateParameter("@price", 4, Book.Price, DbType.Double));
                parameters.Add(dataProvider.CreateParameter("@bookID", 4, Book.BookID, DbType.Int32));
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
        //        string SQLUpdate = "DELETE Book WHERE ProductId = @ProductID";
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
