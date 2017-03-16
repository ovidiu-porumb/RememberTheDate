using System;
using System.ComponentModel.DataAnnotations;
using MediatR;
using OP.RememberTheDate.Storage;
using OP.RememberTheDate.Storage.Model;

// ReSharper disable ArrangeThisQualifier
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedAutoPropertyAccessor.Global

namespace OP.RememberTheDate.WebService.Commands
{
    public class RegisterDate : IRequest
    {
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public string EventToMark { get; set; }

        public void ExecuteOnStorage(IWriteStorage<DateModel> writeStorage)
        {
            var writeModel = new DateModel
            {
                Date = this.Date,
                EventToMark = this.EventToMark
            };

            writeStorage.RegisterDateForEvent(writeModel);
        }
    }
}