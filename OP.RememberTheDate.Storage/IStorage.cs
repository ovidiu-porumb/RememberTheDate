namespace OP.RememberTheDate.Storage
{
    public interface IStorage<in T>
    {
        void Insert(T elementToInsert);
    }
}
