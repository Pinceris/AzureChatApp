namespace AzureChatApp
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Message
    {
        public Message ()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }

        [StringLength(50)]
        public string sender_name { get; set; }

        [Column("message")]
        public string message1 { get; set; }

        public DateTime? created_at { get; set; }
    }
}
