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
    public class LibrarianDAO : BaseDAL
    {
        private static LibrarianDAO? instance = null;
        private static readonly Object instanceLock = new object();
        private LibrarianDAO() { }
        public static LibrarianDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null) instance = new LibrarianDAO();
                }
                return instance;
            }
        }
        public Librarian? GetInfo(int librarianID)
        {
            Librarian? librarian = null;
            IDataReader? dataReader = null;
            string SQLSelect = "SELECT name FROM tblLibrarian WHERE librarianID = @librarianID ";
            try
            {
                var param = dataProvider.CreateParameter("@librarianID", 4, librarianID, DbType.Int32);
                dataReader = dataProvider.GetDataReader(SQLSelect, CommandType.Text, out connection, param);
                if (dataReader.Read())
                {
                    librarian = new Librarian
                    {
                        LibrarianID = librarianID,
                        Name = dataReader.GetString(0),
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
            return librarian;
        }
        public Librarian? CheckLogin(String username, String password)
        {
            Librarian? librarian = null;
            IDataReader? dataReader = null;
            string SQLSelect = "SELECT librarianID, name FROM tblLibrarian WHERE username = @username AND password = @password ";
            try
            {
                var parameters = new List<SqlParameter>();
                parameters.Add(dataProvider.CreateParameter("@username", 20, username, DbType.String));
                parameters.Add(dataProvider.CreateParameter("@password", 16, password, DbType.String));
                dataReader = dataProvider.GetDataReader(SQLSelect, CommandType.Text, out connection, parameters.ToArray());
                if (dataReader.Read())
                {
                    librarian = new Librarian
                    {
                        LibrarianID = dataReader.GetInt32(0),
                        Name = dataReader.GetString(1),
                        Username = username,
                        Password = password,
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
            return librarian;
        }             
        public void UpdateInfo(Librarian librarian)
        {
            try
            {
                string SQLUpdate = "UPDATE tblLibrarian SET name = @name , password = @password WHERE librarianID = @librarianID";
                var parameters = new List<SqlParameter>();
                parameters.Add(dataProvider.CreateParameter("@name", 20, librarian.Name, DbType.String));
                parameters.Add(dataProvider.CreateParameter("@password", 16, librarian.Password, DbType.String));
                parameters.Add(dataProvider.CreateParameter("@librarianID", 4, librarian.LibrarianID, DbType.Int32));
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
    }
}
