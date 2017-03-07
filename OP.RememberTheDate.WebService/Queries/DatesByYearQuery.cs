using System.Collections.Generic;
using MediatR;
using OP.RememberTheDate.WebService.Models;

namespace OP.RememberTheDate.WebService.Queries
{
    public class DatesByYearQuery : IRequest<IEnumerable<DateModel>>
    {
        public int Year { get; set; }
    }
}