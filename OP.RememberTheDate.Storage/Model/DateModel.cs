using System;

namespace OP.RememberTheDate.Storage.Model
{
    public class DateModel
    {
        public const string TableName = "RegisteredDates";

        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string EventToMark { get; set; }
    }
}