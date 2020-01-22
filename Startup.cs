using Owin;
using Microsoft.Owin;
using AzureChatApp.Repository;
using ServiceStack.Redis;
using System.Collections.Generic;

[assembly: OwinStartup(typeof(SignalRChat.Startup))]
namespace SignalRChat
{
    public class Startup
    {
        public static readonly ChatRepo ChatRepository = new ChatRepo(new RedisClient("q5zvOrQkvV2pidlU8I9SvMbKWjYIUX7ZAP7DOovnexU=@matas-message-cache.redis.cache.windows.net?ssl=true"));
        public static Dictionary<string, string> ActiveSessionPairs = new Dictionary<string, string>();
        public void Configuration(IAppBuilder app)
        {
            // Any connection or hub wire up and configuration should go here
            app.MapSignalR();
        }
    }
}