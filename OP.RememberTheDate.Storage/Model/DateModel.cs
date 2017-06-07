using System;

namespace OP.RememberTheDate.Storage.Model
{
    public class DateModel
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string EventToMark { get; set; }
    }
}