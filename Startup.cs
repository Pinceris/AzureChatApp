using Owin;
using Microsoft.Owin;
using AzureChatApp.Repository;
using ServiceStack.Redis;

[assembly: OwinStartup(typeof(SignalRChat.Startup))]
namespace SignalRChat
{
    public class Startup
    {
        public static readonly ChatRepo ChatRepository = new ChatRepo(new RedisClient("localhost"));
        public void Configuration(IAppBuilder app)
        {
            // Any connection or hub wire up and configuration should go here
            app.MapSignalR();
        }
    }
}