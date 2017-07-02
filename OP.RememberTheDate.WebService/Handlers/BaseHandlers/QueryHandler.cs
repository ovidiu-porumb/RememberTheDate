using MediatR;
using OP.RememberTheDate.Storage.Contracts;
using OP.RememberTheDate.Storage.Model;

namespace OP.RememberTheDate.WebService.Handlers.BaseHandlers
{
    public abstract class QueryHandler<T, U> : IRequestHandler<T, U> where T : IRequest<U>
    {
        // ReSharper disable once InconsistentNaming
        protected readonly IReadStorage<DateModel> readStorage;

        protected QueryHandler(IReadStorage<DateModel> readStorage)
        {
            this.readStorage = readStorage;
        }

        public abstract U Handle(T message);
    }
}