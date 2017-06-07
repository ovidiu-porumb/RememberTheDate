using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using OP.RememberTheDate.Storage.Contracts;
using OP.RememberTheDate.Storage.Model;

namespace OP.RememberTheDate.Storage.Mongo
{
    public class MongoReadStorage : IReadStorage<DateModel>
    {
        private readonly IMongoClient client;
        private readonly IMongoDatabase database;

        public MongoReadStorage(string connectionString)
        {
            client = new MongoClient(connectionString);
            database = client.GetDatabase("RememberTheDate");
        }

        public IEnumerable<DateModel> GetRegisteredDatesFromYear(int year)
        {
            // mongo db linq driver does not know of the eq between dates
            var firstDateOfTheYear = new DateTime(year, 1, 1);
            var lastDateOfTheYear = new DateTime(year, 12, 31);

            var collection = database.GetCollection<DateModel>("RegisteredDates").AsQueryable();

            return
                IAsyncCursorSourceExtensions.ToList(
                    collection.Where(e => e.Date >= firstDateOfTheYear && e.Date <= lastDateOfTheYear));
        }

        public IEnumerable<DateModel> GetRegisteredDatesNamedLike(string eventName)
        {
            var collection = database.GetCollection<DateModel>("RegisteredDates").AsQueryable();

            return
                IAsyncCursorSourceExtensions.ToList(collection.Where(e => e.EventToMark.ToLower().Contains(eventName)));
        }

        public IEnumerable<DateModel> GetRegisteredDatesInsideInterval(DateTime from, DateTime to)
        {
            var collection = database.GetCollection<DateModel>("RegisteredDates").AsQueryable();

            return IAsyncCursorSourceExtensions.ToList(collection.Where(e => e.Date >= from && e.Date <= to));
        }

        public IEnumerable<DateModel> GetRegisteredDatesFromMonth(int month)
        {
            var collection =
                IAsyncCursorSourceExtensions.ToList(database.GetCollection<DateModel>("RegisteredDates").AsQueryable());

            return collection.Where(e => e.Date.Month == month);
        }
    }
}