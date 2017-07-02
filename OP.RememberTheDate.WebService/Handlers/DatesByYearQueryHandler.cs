using System.Collections.Generic;
using OP.RememberTheDate.Storage.Contracts;
using OP.RememberTheDate.Storage.Model;
using OP.RememberTheDate.WebService.Handlers.BaseHandlers;
using OP.RememberTheDate.WebService.Queries;

namespace OP.RememberTheDate.WebService.Handlers
{
    public class DatesByYearQueryHandler : QueryHandler<DatesByYearQuery, IEnumerable<DateModel>>
    {
        public DatesByYearQueryHandler(IReadStorage<DateModel> readStorage)
            : base(readStorage)
        {
        }

        public override IEnumerable<DateModel> Handle(DatesByYearQuery datesByYearQuery)
        {
            return datesByYearQuery.GetRegisteredDatesOnSpecificYearFrom(readStorage);
        }
    }
}