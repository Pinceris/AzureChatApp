using Owin;
using Microsoft.Owin;
using AzureChatApp.Repository;
using System.Collections.Generic;

[assembly: OwinStartup(typeof(SignalRChat.Startup))]
namespace SignalRChat
{
    public class Startup
    {
        private static readonly string connStr = "mongodb://root:root@cluster0-shard-00-00-9fzg3.mongodb.net:27017,cluster0-shard-00-01-9fzg3.mongodb.net:27017,cluster0-shard-00-02-9fzg3.mongodb.net:27017/test?ssl=true&replicaSet=Cluster0-shard-0&authSource=admin&retryWrites=true&w=majority";
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