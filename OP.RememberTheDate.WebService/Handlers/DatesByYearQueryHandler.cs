using System.Collections.Generic;
using MediatR;
using OP.RememberTheDate.Storage;
using OP.RememberTheDate.Storage.Model;
using OP.RememberTheDate.WebService.Queries;

namespace OP.RememberTheDate.WebService.Handlers
{
    public class DatesByYearQueryHandler : IRequestHandler<DatesByYearQuery, IEnumerable<DateModel>>
    {
        public IEnumerable<DateModel> Handle(DatesByYearQuery datesByYearQuery)
        {
            var storage = new StorageHandler();
            IEnumerable<DateModel> result = storage.GetRegisteredDatesFromYear(datesByYearQuery.Year);

            return result;
        }
    }
}