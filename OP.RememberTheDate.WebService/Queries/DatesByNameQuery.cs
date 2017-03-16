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
    public class DatesByNameQuery : IRequest<IEnumerable<DateModel>>
    {
        [Required]
        public string EventName { get; set; }

        public IEnumerable<DateModel> GetRegisteredDatesContainingTheStringInNameFrom(IReadStorage<DateModel> readStorage)
        {
            IEnumerable<DateModel> result = readStorage.GetRegisteredDatesNamedLike(this.EventName);
            return result;
        }
    }
}