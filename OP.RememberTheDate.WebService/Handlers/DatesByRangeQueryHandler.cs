using System;
using System.Collections.Generic;
using System.Linq;
using MediatR;
using OP.RememberTheDate.Storage.Model;
using OP.RememberTheDate.WebService.Queries;

namespace OP.RememberTheDate.WebService.Handlers
{
    public class DatesByRangeQueryHandler : IRequestHandler<DatesByRangeQuery, IEnumerable<DateModel>>
    {
        public IEnumerable<DateModel> Handle(DatesByRangeQuery datesByRangeQuery)
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

            IEnumerable<DateModel> result = repository.Where(EventIsInTheRange(datesByRangeQuery));

            return result;
        }

        private Func<DateModel, bool> EventIsInTheRange(DatesByRangeQuery datesByRangeQuery)
        {
            return i => i.Date > datesByRangeQuery.From && i.Date < datesByRangeQuery.To;
        }
    }
}