using System.Collections.Generic;
using OP.RememberTheDate.Storage.Contracts;
using OP.RememberTheDate.Storage.Model;
using OP.RememberTheDate.WebService.Queries;

namespace OP.RememberTheDate.WebService.Handlers
{
    public class DatesByNameQueryHandler : QueryHandler<DatesByNameQuery, IEnumerable<DateModel>>
    {
        public DatesByNameQueryHandler(IReadStorage<DateModel> readStorage) : base(readStorage)
        {
        }

        public override IEnumerable<DateModel> Handle(DatesByNameQuery datesByNameQuery)
        {
            return datesByNameQuery.GetRegisteredDatesContainingTheStringInNameFrom(readStorage);
        }
    }
}