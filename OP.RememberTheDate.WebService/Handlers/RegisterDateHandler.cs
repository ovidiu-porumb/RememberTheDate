using OP.RememberTheDate.Storage;
using OP.RememberTheDate.Storage.Model;
using OP.RememberTheDate.WebService.Commands;

namespace OP.RememberTheDate.WebService.Handlers
{
    public class RegisterDateHandler : CommandHandler<RegisterDate>
    {
        public RegisterDateHandler(IWriteStorage<DateModel> WriteStorage)
            : base(WriteStorage)
        {
        }

        public override void Handle(RegisterDate dateToRegister)
        {
            var writeModel = new DateModel
            {
                Date = dateToRegister.Date,
                EventToMark = dateToRegister.EventToMark
            };

            writeStorage.Insert(writeModel);
        }
    }
}