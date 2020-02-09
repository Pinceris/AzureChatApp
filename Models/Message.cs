namespace AzureChatApp
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using MongoDB.Bson;
    using MongoDB.Bson.Serialization.Attributes;

    public partial class Message
    {
        public Message ()
        {
            Id = Guid.NewGuid();
            created_at = DateTime.Now;
        }
        [BsonId]
        public Guid Id { get; set; }

        [BsonElement("sender_name")]
        public string sender_name { get; set; }

        [BsonElement("message1")]
        public string message1 { get; set; }

        [BsonElement("created_at")]
        public DateTime? created_at { get; set; }
    }
}
