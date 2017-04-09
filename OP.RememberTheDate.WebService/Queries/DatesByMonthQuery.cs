using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MediatR;
using OP.RememberTheDate.Storage.Contracts;
using OP.RememberTheDate.Storage.Model;

// ReSharper disable ArrangeThisQualifier
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global

namespace OP.RememberTheDate.WebService.Queries
{
    public class DatesByMonthQuery : IRequest<IEnumerable<DateModel>>
    {
        [Required]
        [Range(1, 12, ErrorMessage = "The month number must be set between 1 (January) and 12 (December).")]
        public Months Month { get; set; }

        public IEnumerable<DateModel> GetRegisteredDatesOnSpecificMonthFrom(IReadStorage<DateModel> readStorage)
        {
            IEnumerable<DateModel> result = readStorage.GetRegisteredDatesFromMonth((int)this.Month);
            return result;
        }
    }
}