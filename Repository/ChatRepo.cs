using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AzureChatApp.Repository
{
    public class ChatRepo : IChatRepo, IDisposable
    {
        private readonly IRedisClient _redisClient;

        public ChatRepo(IRedisClient redisClient)
        {
            _redisClient = redisClient;
        }

        public IList<Message> GetAll()
        {
            var typedClient = _redisClient.As<Message>();

            return typedClient.GetAll();
        }

        public Message Get(Guid id)
        {
            var typedClient = _redisClient.As<Message>();

            return typedClient.GetById(id);
        }

        public Message Store(Message message)
        {
            var typedClient = _redisClient.As<Message>();

            return typedClient.Store(message);
        }

        public void Delete(Guid id)
        {
            _redisClient.DeleteById<Message>(id);
        }

        public void Dispose()
        {
            _redisClient.Dispose();
        }
    }
}