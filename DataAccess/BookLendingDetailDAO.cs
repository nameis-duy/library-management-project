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
    public class BookLendingDetailDAO : BaseDAL
    {
        private static BookLendingDetailDAO? instance;
        private static readonly object instanceLock = new object();
        private BookLendingDetailDAO() { }
        public static BookLendingDetailDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new BookLendingDetailDAO();
                    }
                    return instance;
                }
            }
        }
        //-------------------------------------------------------------
        public IEnumerable<BookLendingDetail> GetListBookLending()
        {
            IDataReader dataReader = null;
            string SQLSelect = "SELECT lenDes.lendID, lenDes.bookID, bo.title, lenDes.quantity\n" + 
                                "from tblLendingDetail lenDes\n" +
                                "inner join tblBook bo\n" +
                                "on bo.bookID = lenDes.bookID";
            var bookLendings = new List<BookLendingDetail>();
            try
            {
                dataReader = dataProvider.GetDataReader(SQLSelect, CommandType.Text, out connection);
                while (dataReader.Read())
                {
                    bookLendings.Add(new BookLendingDetail
                    {
                        LendID = dataReader.GetInt32(0),
                        bookID = dataReader.GetInt32(1),
                        bookTitle = dataReader.GetString(2),
                        quantity = dataReader.GetInt32(3),
                    });
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                if (dataReader != null)
                {
                    dataReader.Close();
                }
                CloseConnection();
            }
            return bookLendings;
        }

        public void AddLendingDetail(BookLendingDetail book)
        {
            string SQLInsert = "INSERT tblLendingDetail VALUES(@lendID, @bookID, @quantity)";
            var parameters = new List<SqlParameter>();
            try
            {
                parameters.Add(dataProvider.CreateParameter("@lendID", 4, book.LendID, DbType.Int32));
                parameters.Add(dataProvider.CreateParameter("@bookID", 4, book.bookID, DbType.Int32));
                parameters.Add(dataProvider.CreateParameter("@quantity", 4, book.quantity, DbType.Int32));
                dataProvider.UpdateDB(SQLInsert, CommandType.Text, parameters.ToArray());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                //CloseConnection();
            }
        }
    }
}
