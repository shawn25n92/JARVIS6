using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JARVIS6
{
    public class JARVISDataSource
    {
        public string Server { get; set; }
        public string Database { get; set; }
        public string UserID { get; set; }
        public string Password { get; set; }
        public string AuthType { get; set; }
        public JARVISDataSource(string Server, string Database, string UserID, string Password)
        {

        }
        public SqlConnection GetSqlServerConnection()
        {
            SqlConnection NewConnection = new SqlConnection();
            try
            {

            }
            catch(Exception e)
            {

            }
            return NewConnection;
        }
        public string GetSqlServerConnectionString()
        {
            string ConnectionString = "";
            try
            {

            }
            catch(Exception e)
            {

            }
            return ConnectionString;
        }
        public StatusObject ExecuteReaderQuery(string Query)
        {
            StatusObject SO = new StatusObject();
            try
            {

            }
            catch(Exception e)
            {
                SO = new StatusObject(e, "JARVISDATASOURCE_EXECUTEREADERQUERY_01");
            }
            return SO;
        }
        public StatusObject ExecuteNonReaderQueryFromFile(string FileDirectory)
        {
            StatusObject SO = new StatusObject();
            try
            {

            }
            catch(Exception e)
            {

            }
            return SO;
        }
        public StatusObject ExecuteReaderQuery(string Query,  params string[] FunctionsToExecute)
        {
            StatusObject SO = new StatusObject();
            try
            {

            }
            catch (Exception e)
            {
                SO = new StatusObject(e, "JARVISDATASOURCE_EXECUTEREADERQUERY_02");
            }
            return SO;
        }
    }
}
