using System;
using System.Threading.Tasks;
using OpenTidl.Methods;
using OpenTidl.Models;
using OpenTidl.Models.Base;

namespace TidlMigrator.App.ThingsToBackup
{
    public class FavoriteAlbums : ISomethingToMigrate<JsonList<JsonListItem<AlbumModel>>>
    {
        public string FriendlyName => "Favorite Albums";
        public Func<OpenTidlSession, Task<JsonList<JsonListItem<AlbumModel>>>> GetIt => session => session.GetFavoriteAlbums();
        public void PutIt(OpenTidlSession session, JsonList<JsonListItem<AlbumModel>> itemsToPut)
        {
            foreach (var itemToPut in itemsToPut.Items)
            {
                session.AddFavoriteAlbum(itemToPut.Item.Id);
            }
        }
    }
}
