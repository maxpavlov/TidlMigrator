using System;
using System.Threading.Tasks;
using TidlMigrator.App.ThingsToBackup;
using TidlMigrator.App.TidalIntegration;

namespace TidlMigrator.App
{
    public static class MigratorFacade
    {
        public static async Task MigrateEverything(string username1, string password1, string username2, string password2)
        {
            var session1 = await TidalIntegrator.LoginUserAsync(username1, password1);
            if (session1 == null)
            {
                Console.WriteLine("Session1: Could not log in :(");
                return;
            }

            var session2 = await TidalIntegrator.LoginUserAsync(username2, password2);
            if (session2 == null)
            {
                Console.WriteLine("Session 2: Could not log in :(");
                return;
            }

            var migrationExecutor = new MigrationExecutor(session1, session2);

            await migrationExecutor.Migrate(new FavoriteArtists());
            await migrationExecutor.Migrate(new FavoriteTracks());
            await migrationExecutor.Migrate(new FavoriteAlbums());
            await migrationExecutor.Migrate(new FavoritePlaylists());
            await migrationExecutor.Migrate(new UserPlaylists());

            Console.WriteLine("Done migrating everything!");
        }
    }
}