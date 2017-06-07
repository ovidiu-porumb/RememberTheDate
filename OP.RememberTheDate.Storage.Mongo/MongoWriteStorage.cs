using System;
using MongoDB.Bson;
using MongoDB.Driver;
using OP.RememberTheDate.Storage.Contracts;
using OP.RememberTheDate.Storage.Model;

namespace OP.RememberTheDate.Storage.Mongo
{
    public class MongoWriteStorage : IWriteStorage<DateModel>
    {
        private readonly IMongoClient client;
        private readonly IMongoDatabase database;

        public MongoWriteStorage(string connectionString)
        {
            client = new MongoClient(connectionString);
            database = client.GetDatabase("RememberTheDate");
        }

        public void RegisterDateForEvent(DateModel model)
        {
            var document = new BsonDocument
            {
                {"date", model.Date},
                {"eventToMark", model.EventToMark}
            };

            database.GetCollection<BsonDocument>("RegisteredDates").InsertOne(document);
        }
    }
}