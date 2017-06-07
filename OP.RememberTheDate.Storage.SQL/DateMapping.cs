using NPoco.FluentMappings;
using OP.RememberTheDate.Storage.Model;

namespace OP.RememberTheDate.Storage.SQL
{
    public class DateMapping : Map<DateModel>
    {
        public DateMapping()
        {
            PrimaryKey(x => x.Id);
            TableName("RegisteredDates");
        }
    }
}
