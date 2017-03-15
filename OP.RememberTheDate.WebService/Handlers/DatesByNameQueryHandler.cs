using System.Collections.Generic;
using MediatR;
using OP.RememberTheDate.Storage;
using OP.RememberTheDate.Storage.Model;
using OP.RememberTheDate.WebService.Queries;

namespace OP.RememberTheDate.WebService.Handlers
{
    public class DatesByNameQueryHandler : IRequestHandler<DatesByNameQuery, IEnumerable<DateModel>>
    {
        public IEnumerable<DateModel> Handle(DatesByNameQuery datesByNameQuery)
        {
            var storage = new StorageHandler();
            IEnumerable<DateModel> result = storage.GetRegisteredDatesNamedLike(datesByNameQuery.EventName);

            return result;
        }
    }
}