using System.Collections.Generic;
using MediatR;
using OP.RememberTheDate.WebService.Models;

namespace OP.RememberTheDate.WebService.Queries
{
    public class DatesByMonthQuery : IRequest<IEnumerable<DateModel>>
    {
        public Months Month { get; set; }
    }
}