using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using MongoDB.Driver;

namespace AzureChatApp.Repository
{
    public class ChatRepo : IChatRepo
    {
        private readonly IMongoClient MongoClient;
        private readonly IMongoDatabase DB;
        private readonly IMongoCollection<Message> Messages;

        public ChatRepo(string connStr, string database)
        {
            MongoClient = new MongoClient(connStr);
            DB = MongoClient.GetDatabase(database);
            Messages = DB.GetCollection<Message>(database);
        }

        public IList<Message> GetAll()
        {
            return Messages.Find(new BsonDocument()).ToList();
        }

        public Message Get(Guid id)
        {
            var getFilter = Builders<Message>.Filter.Eq("Id", id);

            return Messages.Find(getFilter).FirstOrDefault();
        }

        public Message Store(Message message)
        {
            Messages.InsertOne(message);

            return message;
        }

        public void Delete(Guid id)
        {
            var deleteFilter = Builders<Message>.Filter.Eq("Id", id);

            Messages.DeleteOne(deleteFilter);
        }
    }
}