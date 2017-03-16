using System.Collections.Generic;
using OP.RememberTheDate.Storage;
using OP.RememberTheDate.Storage.Model;
using OP.RememberTheDate.WebService.Queries;

namespace OP.RememberTheDate.WebService.Handlers
{
    public class DatesByRangeQueryHandler : QueryHandler<DatesByRangeQuery, IEnumerable<DateModel>>
    {
        public DatesByRangeQueryHandler(IReadStorage<DateModel> readStorage)
            : base(readStorage)
        {
        }

        public override IEnumerable<DateModel> Handle(DatesByRangeQuery datesByRangeQuery)
        {
            return datesByRangeQuery.GetRegisteredDatesInsideIntervalFrom(readStorage);
        }
    }
}