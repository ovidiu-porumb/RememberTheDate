namespace OP.RememberTheDate.Storage
{
    public class StorageHandler : IStorage<DateModel>
    {
        public void Insert(DateModel elementToInsert)
        {
            StorageFactory.Database.GetDatabase().Insert(elementToInsert);
        }
    }
}
