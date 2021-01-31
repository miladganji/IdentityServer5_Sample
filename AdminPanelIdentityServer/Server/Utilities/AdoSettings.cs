
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
//using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace blazorSource.Server.Ado
{
    public class AdoSettings:IDisposable
    {
        public string DataSource { get; set; }
        public string userid { get; set; }
        public string  Password { get; set; }
        public string Database { get; set; }
        public SqlConnection Connection { get; set; } 
        public string  ConnectionString { get; set; }
        public AdoSettings()
        {
            DataSource = "172.18.71.55";
            Database = "DB04";
            userid = "Ganji.M";
            Password = "Ganji.M";
            ConnectionString = "Data Source="+ DataSource+"; database="+ Database +";user id="+ userid+"; password="+Password+";";
            Connection = new SqlConnection(ConnectionString);
        }

        public void Connect()
        {

            Connection.Open();
        }

        public void DisConnect()
        {
            Connection.Close();
        }

        public void Dispose()
        {
            DisConnect();
        }
    }
}
