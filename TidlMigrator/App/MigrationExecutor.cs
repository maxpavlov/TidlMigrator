using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using OpenTidl.Methods;
using TidlMigrator.App.ThingsToBackup;

namespace TidlMigrator.App
{
    public class MigrationExecutor
    {
        private readonly OpenTidlSession _session1;
        private readonly OpenTidlSession _session2;

        public MigrationExecutor(OpenTidlSession session1, OpenTidlSession session2)
        {
            _session1 = session1;
            _session2 = session2;
        }

        public async Task Migrate<T>(ISomethingToMigrate<T> somethingToMigrate)
        {
            var itemName = typeof(T).Name;
            Console.WriteLine($"Migrating up {itemName}");
            var jsonList = await somethingToMigrate.GetIt.Invoke(_session1);
            Console.WriteLine($"{itemName} items retrived from the source account. Updating destination.");
            somethingToMigrate.PutIt(_session2, jsonList);
            Console.WriteLine($"{itemName} are placed in the destination account.");
        }
    }
}