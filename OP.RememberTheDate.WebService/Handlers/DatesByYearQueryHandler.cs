using System;
using System.Collections.Generic;
using System.Linq;
using MediatR;
using OP.RememberTheDate.WebService.Models;
using OP.RememberTheDate.WebService.Queries;

namespace OP.RememberTheDate.WebService.Handlers
{
    public class DatesByYearQueryHandler : IRequestHandler<DatesByYearQuery, IEnumerable<DateModel>>
    {
        public IEnumerable<DateModel> Handle(DatesByYearQuery datesByYearQuery)
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

            IEnumerable<DateModel> result = repository.Where(EventYearIsInTheMonth(datesByYearQuery));

            return result;
        }

        private Func<DateModel, bool> EventYearIsInTheMonth(DatesByYearQuery datesByYearQuery)
        {
            return i => i.Date.Year == datesByYearQuery.Year;
        }
    }
}