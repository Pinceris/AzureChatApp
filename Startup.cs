﻿using Owin;
using Microsoft.Owin;
using AzureChatApp.Repository;
using ServiceStack.Redis;
using System.Collections.Generic;

[assembly: OwinStartup(typeof(SignalRChat.Startup))]
namespace SignalRChat
{
    public class Startup
    {
        public static readonly InAppRepo ChatRepository = new InAppRepo();
        public static Dictionary<string, string> ActiveSessionPairs = new Dictionary<string, string>();
        public void Configuration(IAppBuilder app)
        {
            // Any connection or hub wire up and configuration should go here
            app.MapSignalR();
        }
    }
}