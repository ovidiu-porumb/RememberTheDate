using System;
using System.Collections.Generic;
using MediatR;
using OP.RememberTheDate.Storage;
using OP.RememberTheDate.Storage.Model;
// ReSharper disable ArrangeThisQualifier

namespace OP.RememberTheDate.WebService.Queries
{
    public class DatesByRangeQuery : IRequest<IEnumerable<DateModel>>
    {
        public DateTime From { get; set; }
        public DateTime To { get; set; }

        public IEnumerable<DateModel> QueryOverStorage(IReadStorage<DateModel> readStorage)
        {
            IEnumerable<DateModel> result = readStorage.GetRegisteredDatesInsideInterval(this.From, this.To);
            return result;
        }
    }
}