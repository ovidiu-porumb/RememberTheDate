using NPoco;
using OP.RememberTheDate.Storage.Contracts;
using OP.RememberTheDate.Storage.Model;

// ReSharper disable ClassNeverInstantiated.Global
// ReSharper disable InconsistentNaming

namespace OP.RememberTheDate.Storage.SQL
{
    public class SqlWriteStorage : IWriteStorage<DateModel>
    {
        private readonly Database database;

        public SqlWriteStorage()
        {
            database = StorageFactory.Database.GetDatabase();
        }

        public void RegisterDateForEvent(DateModel model)
        {
            database.Insert(model);
        }
    }
}
