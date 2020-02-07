using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Text.RegularExpressions;
using AzureChatApp.Migrations;

namespace AzureChatApp.Models
{
    public class MessageContext : DbContext
    {
        public static string connStrToArray()
        {
            string connStr = Environment.GetEnvironmentVariable("MYSQLCONNSTR_localdb").ToString();
            string[] connArray = Regex.Split(connStr, ";");
            string connectionstring = null;
            for (int i = 0; i < connArray.Length; i++)
            {

                if (i == 1)
                {
                    string[] datasource = Regex.Split(connArray[i], ":");
                    connectionstring += datasource[0] + string.Format(";port={0};", datasource[1]);
                }
                else
                {
                    connectionstring += connArray[i] + ";";
                }
            }

            return connectionstring;
        }

        public MessageContext()
        {

            this.Database.Connection.ConnectionString = connStrToArray();
        }

        static MessageContext()
        {

            //This is important
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<MessageContext, Configuration>());
        }
        public DbSet<Message> Messages { get; set; }
    }
}