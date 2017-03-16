namespace OP.RememberTheDate.Storage
{
    public interface IWriteStorage<in T>
    {
        void RegisterDateForEvent(T model);
    }
}
