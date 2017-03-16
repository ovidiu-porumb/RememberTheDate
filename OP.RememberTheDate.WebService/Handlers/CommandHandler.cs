using MediatR;
using OP.RememberTheDate.Storage;
using OP.RememberTheDate.Storage.Model;

namespace OP.RememberTheDate.WebService.Handlers
{
    public abstract class CommandHandler<T> : IRequestHandler<T> where T : IRequest
    {
        // ReSharper disable once InconsistentNaming
        protected readonly IWriteStorage<DateModel> writeStorage;

        protected CommandHandler(IWriteStorage<DateModel> WriteStorage)
        {
             this.writeStorage = WriteStorage;
        }

        public abstract void Handle(T message);
    }
}