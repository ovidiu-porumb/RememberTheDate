namespace OP.RememberTheDate.Storage
{
    public interface IWriteStorage<in T>
    {
        void Insert(T elementToInsert);
    }
}
