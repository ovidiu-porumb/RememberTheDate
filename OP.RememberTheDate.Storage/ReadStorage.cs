using System.Collections.Generic;
using System.Linq;
using NPoco;
using OP.RememberTheDate.Storage.Model;

namespace OP.RememberTheDate.Storage
{
    public class ReadStorage : IReadStorage<DateModel>
    {
        private readonly Database database;

        public ReadStorage()
        {
            database = StorageFactory.Database.GetDatabase();
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
