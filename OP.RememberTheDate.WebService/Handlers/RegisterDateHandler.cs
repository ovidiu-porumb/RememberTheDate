using OP.RememberTheDate.Storage.Contracts;
using OP.RememberTheDate.Storage.Model;
using OP.RememberTheDate.WebService.BaseHandlers.Handlers;
using OP.RememberTheDate.WebService.Commands;

namespace OP.RememberTheDate.WebService.Handlers
{
    public class RegisterDateHandler : CommandHandler<RegisterDate>
    {
        public RegisterDateHandler(IWriteStorage<DateModel> writeStorage)
            : base(writeStorage)
        {
        }

        public override void Handle(RegisterDate dateToRegister)
        {
            dateToRegister.RegisterDateForEventOn(writeStorage);
        }
    }
}