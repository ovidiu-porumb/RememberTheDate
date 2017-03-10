using MediatR;
using OP.RememberTheDate.Storage;
using OP.RememberTheDate.WebService.Commands;

namespace OP.RememberTheDate.WebService.Handlers
{
    public class RegisterDateHandler : IRequestHandler<RegisterDate>
    {
        public void Handle(RegisterDate dateToRegister)
        {
            var writeModel = new DateModel
            {
                Date = dateToRegister.Date,
                EventToMark = dateToRegister.EventToMark
            };

            var storageHandler = new StorageHandler();
            storageHandler.Insert(writeModel);
        }
    }
}