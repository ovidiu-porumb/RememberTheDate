using MediatR;
using OP.RememberTheDate.Storage;
using OP.RememberTheDate.Storage.Model;

namespace OP.RememberTheDate.WebService.Handlers
{
    public abstract class RequestHandler<T> : IRequestHandler<T> where T : IRequest
    {
        // ReSharper disable once InconsistentNaming
        protected readonly IStorage<DateModel> storage;

        protected RequestHandler(IStorage<DateModel> storage)
        {
             this.storage = storage;
        }

        public abstract void Handle(T message);
    }
}