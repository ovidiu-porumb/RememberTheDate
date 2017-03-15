using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MediatR;
using OP.RememberTheDate.Storage.Model;

namespace OP.RememberTheDate.WebService.Queries
{
    public class DatesByMonthQuery : IRequest<IEnumerable<DateModel>>
    {
        [Required]
        [Range(1, 12, ErrorMessage = "The month number must be set between 1 (January) and 12 (December).")]
        public Months? Month { get; set; }
    }
}