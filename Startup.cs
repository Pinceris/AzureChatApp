using Owin;
using Microsoft.Owin;
using AzureChatApp.Repository;
using System.Collections.Generic;
using System.Configuration;

[assembly: OwinStartup(typeof(SignalRChat.Startup))]
namespace SignalRChat
{
    public class Startup
    {
        private static readonly string connStr = ConfigurationManager.ConnectionStrings["MongoConnectionString"].ConnectionString;
        private static readonly string database = "chat";

        public static readonly ChatRepo ChatRepository = new ChatRepo(connStr, database);
        public static Dictionary<string, string> ActiveSessionPairs = new Dictionary<string, string>();
        
        public void Configuration(IAppBuilder app)
        {
            // Any connection or hub wire up and configuration should go here
            app.MapSignalR();
        }
    }
}