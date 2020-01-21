using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AzureChatApp.Models
{
    public class ChatViewModel
    {
        public Dictionary<string, string> SessionNicks { get; set; }
        public IList<Message> Messages { get; set; }
    }
}