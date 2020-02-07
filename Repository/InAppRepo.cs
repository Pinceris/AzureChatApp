using AzureChatApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AzureChatApp.Repository
{
    public class InAppRepo
    {
        public List<Message> getAllMessages()
        {
            List<Message> messages = new List<Message>();
            using (var msgContext = new MessageContext())
            {
                messages = msgContext.Messages.ToList();
            }

            return messages;
        }
    }
}