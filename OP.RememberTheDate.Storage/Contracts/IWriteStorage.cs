namespace OP.RememberTheDate.Storage.Contracts
{
    public interface IWriteStorage<in T>
    {
        void RegisterDateForEvent(T model);
    }
}
