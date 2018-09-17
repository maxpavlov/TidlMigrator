using System;
using System.Linq;
using System.Threading.Tasks;
using OpenTidl.Methods;
using OpenTidl.Models;
using OpenTidl.Models.Base;

namespace TidlMigrator.App.ThingsToBackup
{
    public class FavoriteArtists : ISomethingToMigrate<JsonList<JsonListItem<ArtistModel>>>
    {
        public string FriendlyName => "Favorite Artists";
        public Func<OpenTidlSession, Task<JsonList<JsonListItem<ArtistModel>>>> GetIt => session => session.GetFavoriteArtists();
        public void PutIt(OpenTidlSession session, JsonList<JsonListItem<ArtistModel>> itemsToPut)
        {
            foreach (var itemToPut in itemsToPut.Items)
            {
                session.AddFavoriteArtist(itemToPut.Item.Id);
            }
        }
    }
}