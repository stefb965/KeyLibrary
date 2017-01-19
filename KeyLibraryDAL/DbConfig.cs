using KeyLibraryDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyLibraryDAL
{
    public class DbConfig
    {
        
        string dbname { get; set; }
        string dbhost { get; set; }
        string dbuser { get; set; }
        string dbpwd { get; set; }
        public DbConfig()
        {
            dbname = "";
            dbhost = "";
            dbuser = "";
            dbpwd = "";
        }
        public string BuildConn()
        {
            DbConfig config = new DbConfig();
            string conn;
            conn = "server=" + config.dbhost + ";uid=" + config.dbuser + ";pwd=" + config.dbpwd + ";database=" + config.dbname + ";";
            return conn;
        }
    }
}
