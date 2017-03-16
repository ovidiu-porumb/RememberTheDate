using System;
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
    public class DatesByRangeQuery : IRequest<IEnumerable<DateModel>>
    {
        [Required]
        public DateTime From { get; set; }
        [Required]
        public DateTime To { get; set; }

        public IEnumerable<DateModel> GetRegisteredDatesInsideIntervalFrom(IReadStorage<DateModel> readStorage)
        {
            IEnumerable<DateModel> result = readStorage.GetRegisteredDatesInsideInterval(this.From, this.To);
            return result;
        }
    }
}