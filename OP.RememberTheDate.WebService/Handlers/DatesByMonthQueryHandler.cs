using System.Collections.Generic;
using OP.RememberTheDate.Storage.Contracts;
using OP.RememberTheDate.Storage.Model;
using OP.RememberTheDate.WebService.Queries;

namespace OP.RememberTheDate.WebService.Handlers
{
    public class DatesByMonthQueryHandler : QueryHandler<DatesByMonthQuery, IEnumerable<DateModel>>
    {
        public DatesByMonthQueryHandler(IReadStorage<DateModel> readStorage)
            : base(readStorage)
        {
        }

        public override IEnumerable<DateModel> Handle(DatesByMonthQuery datesByMonthQuery)
        {
            return datesByMonthQuery.GetRegisteredDatesOnSpecificMonthFrom(readStorage);
        }
    }
}