using System.Collections.Generic;
using MediatR;
using OP.RememberTheDate.WebService.Models;

namespace OP.RememberTheDate.WebService.Queries
{
    public class DatesByNameQuery : IRequest<IEnumerable<DateModel>>
    {
        public string EventName { get; set; }
    }
}