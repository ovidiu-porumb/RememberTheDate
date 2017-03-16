using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MediatR;
using OP.RememberTheDate.Storage;
using OP.RememberTheDate.Storage.Model;

// ReSharper disable ArrangeThisQualifier
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global

namespace OP.RememberTheDate.WebService.Queries
{
    public class DatesByYearQuery : IRequest<IEnumerable<DateModel>>
    {
        [Required]
        [Range(1, 10000, ErrorMessage = "I strongly believe that the first 10.000 years from the Current Era should suffice for the purposes of this application.")]
        public int Year { get; set; }

        public IEnumerable<DateModel> QueryOverStorage(IReadStorage<DateModel> readStorage)
        {
            IEnumerable<DateModel> result = readStorage.GetRegisteredDatesFromYear(this.Year);
            return result;
        }
    }
}