using System;
using System.Threading.Tasks;
using OpenTidl.Methods;
using OpenTidl.Models;
using OpenTidl.Models.Base;

namespace TidlMigrator.App.ThingsToBackup
{
    public class UserPlaylists : ISomethingToMigrate<JsonList<PlaylistModel>>
    {
        public string FriendlyName => "Playlists";
        public Func<OpenTidlSession, Task<JsonList<PlaylistModel>>> GetIt => session => session.GetUserPlaylists();
        public void PutIt(OpenTidlSession session, JsonList<PlaylistModel> itemsToPut)
        {
            foreach (var itemToPut in itemsToPut.Items)
            {
                session.AddFavoritePlaylist(itemToPut.Uuid);
            }
        }
    }
}
