using System;
using System.Collections.Generic;
using System.Linq;
using MediatR;
using OP.RememberTheDate.Storage;
using OP.RememberTheDate.WebService.Queries;

namespace OP.RememberTheDate.WebService.Handlers
{
    public class DatesByNameQueryHandler : IRequestHandler<DatesByNameQuery, IEnumerable<DateModel>>
    {
        public IEnumerable<DateModel> Handle(DatesByNameQuery datesByNameQuery)
        {
            var repository = new List<DateModel>
            {
                new DateModel
                {
                    Date = DateTime.Now.Subtract(TimeSpan.FromDays(10)),
                    EventToMark = "First idea of doing this"
                },
                new DateModel
                {
                    Date = DateTime.Now.Subtract(TimeSpan.FromDays(5)),
                    EventToMark = "First encounter with MediatR"
                },
                new DateModel
                {
                    Date = DateTime.Now.Subtract(TimeSpan.FromDays(2)),
                    EventToMark = "Started playing around"
                },
                new DateModel
                {
                    Date = DateTime.Now,
                    EventToMark = "Current time"
                }
            };

            IEnumerable<DateModel> result = repository.Where(EventNameContainsTheString(datesByNameQuery));

            return result;
        }

        private Func<DateModel, bool> EventNameContainsTheString(DatesByNameQuery message)
        {
            return i => i.EventToMark.IndexOf(message.EventName, StringComparison.InvariantCultureIgnoreCase) >= 0;
        }
    }
}