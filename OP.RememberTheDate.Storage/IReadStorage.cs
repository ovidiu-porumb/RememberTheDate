using System;
using System.Collections.Generic;
using OP.RememberTheDate.Storage.Model;

namespace OP.RememberTheDate.Storage
{
    public interface IReadStorage<out T>
    {
        IEnumerable<T> GetRegisteredDatesFromYear(int year);
        IEnumerable<T> GetRegisteredDatesNamedLike(string eventName);
        IEnumerable<DateModel> GetRegisteredDatesInsideInterval(DateTime from, DateTime to);
        IEnumerable<DateModel> GetRegisteredDatesFromMonth(int month);
    }
}
