using System;
using MediatR;
using OP.RememberTheDate.Storage;
using OP.RememberTheDate.Storage.Model;
// ReSharper disable ArrangeThisQualifier
// ReSharper disable MemberCanBePrivate.Global

namespace OP.RememberTheDate.WebService.Commands
{
    public class RegisterDate : IRequest
    {
        public DateTime Date { get; set; }
        public string EventToMark { get; set; }

        public void ExecuteOnStorage(IWriteStorage<DateModel> writeStorage)
        {
            var writeModel = new DateModel
            {
                Date = this.Date,
                EventToMark = this.EventToMark
            };

            writeStorage.Insert(writeModel);
        }
    }
}