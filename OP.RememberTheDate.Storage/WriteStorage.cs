using NPoco;
using OP.RememberTheDate.Storage.Contracts;
using OP.RememberTheDate.Storage.Model;

// ReSharper disable ClassNeverInstantiated.Global
// ReSharper disable InconsistentNaming

namespace OP.RememberTheDate.Storage
{
    public class WriteStorage : IWriteStorage<DateModel>
    {
        private readonly Database database;

        public WriteStorage()
        {
            database = StorageFactory.Database.GetDatabase();
        }

        public void RegisterDateForEvent(DateModel model)
        {
            database.Insert(model);
        }
    }
}
