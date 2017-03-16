using System.Collections.Generic;
using System.Linq;
using NPoco;
using OP.RememberTheDate.Storage.Model;

// ReSharper disable InconsistentNaming

namespace OP.RememberTheDate.Storage
{
    public class StorageHandler : IStorage<DateModel>
    {
        private readonly Database database;

        public StorageHandler()
        {
            database = StorageFactory.Database.GetDatabase();
        }

        public void Insert(DateModel elementToInsert)
        {
            database.Insert(elementToInsert);
        }

        public IEnumerable<DateModel> GetRegisteredDatesFromYear(int year)
        {
            //nasty hack 'cause the where clause apparently cannot access a property of the datetime value
            return database.Query<DateModel>().ToList().Where(e => e.Date.Year == year);
        }

        public IEnumerable<DateModel> GetRegisteredDatesNamedLike(string eventName)
        {
            return database.Query<DateModel>().Where(e => e.EventToMark.ToLower().Contains(eventName.ToLower())).ToList();
        }
    }
}
