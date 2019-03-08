using System;
using System.Configuration;
using MySqlSugar;

namespace SugarDemo.DB
{
    public class SugarFactory
    {
        private static string config = ConfigurationManager.ConnectionStrings["LocalhostMySql"].ConnectionString;
        private SugarFactory()
        {

        }
        public static string ConnectionString
        {
            get
            {
                return config;
            }
        }
        public static SqlSugarClient GetInstance()
        {
            var db = new SqlSugarClient(ConnectionString);
            //db.IsEnableLogEvent = true;//Enable log events
            //db.LogEventStarting = (sql, par) => { Console.WriteLine(sql + " " + par + "\r\n"); };
            return db;
        }
    }
}
