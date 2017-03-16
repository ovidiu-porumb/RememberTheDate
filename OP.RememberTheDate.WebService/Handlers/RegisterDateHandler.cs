using OP.RememberTheDate.Storage;
using OP.RememberTheDate.Storage.Model;
using OP.RememberTheDate.WebService.Commands;

namespace OP.RememberTheDate.WebService.Handlers
{
    public class RegisterDateHandler : RequestHandler<RegisterDate>
    {
        public RegisterDateHandler(IStorage<DateModel> storage)
            : base(storage)
        {
        }

        public override void Handle(RegisterDate dateToRegister)
        {
            var writeModel = new DateModel
            {
                Date = dateToRegister.Date,
                EventToMark = dateToRegister.EventToMark
            };

            storage.Insert(writeModel);
        }
    }
}