using System;
using System.Collections.Generic;
using System.Linq;
using NPoco;
using OP.RememberTheDate.Storage.Contracts;
using OP.RememberTheDate.Storage.Model;

// ReSharper disable InconsistentNaming

namespace OP.RememberTheDate.Storage
{
    // ReSharper disable ClassNeverInstantiated.Global
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

        public IEnumerable<DateModel> GetRegisteredDatesInsideInterval(DateTime from, DateTime to)
        {
            return database.Query<DateModel>().Where(e => e.Date > from && e.Date < to).ToList();
        }

        public IEnumerable<DateModel> GetRegisteredDatesFromMonth(int month)
        {
            //nasty hack 'cause the where clause apparently cannot access a property of the datetime value
            return database.Query<DateModel>().ToList().Where(e => e.Date.Month == month);
        }
    }
}
