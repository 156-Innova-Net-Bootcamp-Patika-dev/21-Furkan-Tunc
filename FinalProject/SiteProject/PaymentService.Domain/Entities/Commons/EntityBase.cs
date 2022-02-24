using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentService.Domain.Entities.Commons
{
    public abstract class EntityBase
    {
        [BsonId]
        public ObjectId ID { get; set; }
    }
}
