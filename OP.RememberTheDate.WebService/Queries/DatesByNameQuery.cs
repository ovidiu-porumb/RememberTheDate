using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MediatR;
using OP.RememberTheDate.Storage.Model;

namespace OP.RememberTheDate.WebService.Queries
{
    public class DatesByNameQuery : IRequest<IEnumerable<DateModel>>
    {
        [Required]
        public string EventName { get; set; }
    }
}