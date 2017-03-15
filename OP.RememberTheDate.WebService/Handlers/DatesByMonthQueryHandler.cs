using System;
using System.Collections.Generic;
using System.Linq;
using MediatR;
using OP.RememberTheDate.Storage.Model;
using OP.RememberTheDate.WebService.Queries;

namespace OP.RememberTheDate.WebService.Handlers
{
    public class DatesByMonthQueryHandler : IRequestHandler<DatesByMonthQuery, IEnumerable<DateModel>>
    {
        public IEnumerable<DateModel> Handle(DatesByMonthQuery datesByMonthQuery)
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

            IEnumerable<DateModel> result = repository.Where(EventMonthIsInTheMonth(datesByMonthQuery));

            return result;
        }

        private Func<DateModel, bool> EventMonthIsInTheMonth(DatesByMonthQuery datesByMonthQuery)
        {
            return i => i.Date.Month == (int)datesByMonthQuery.Month;
        }
    }
}