using System;
using System.Threading.Tasks;
using OpenTidl.Methods;
using OpenTidl.Models;
using OpenTidl.Models.Base;

namespace TidlMigrator.App.ThingsToBackup
{
    public class FavoritePlaylists : ISomethingToMigrate<JsonList<JsonListItem<PlaylistModel>>>
    {
        public string FriendlyName => "Favorite Playlists";
        public Func<OpenTidlSession, Task<JsonList<JsonListItem<PlaylistModel>>>> GetIt => session => session.GetFavoritePlaylists();
        public void PutIt(OpenTidlSession session, JsonList<JsonListItem<PlaylistModel>> itemsToPut)
        {
            foreach (var itemToPut in itemsToPut.Items)
            {
                session.AddFavoritePlaylist(itemToPut.Item.Uuid);
            }
        }
    }
}
