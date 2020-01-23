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


        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _redisClient.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}