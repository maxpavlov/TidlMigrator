using System;
using System.Threading.Tasks;
using OpenTidl.Methods;
using OpenTidl.Models;
using OpenTidl.Models.Base;

namespace TidlMigrator.App.ThingsToBackup
{
    public class FavoriteTracks : ISomethingToMigrate<JsonList<JsonListItem<TrackModel>>>
    {
        public string FriendlyName => "Favorite Tracks";
        public Func<OpenTidlSession, Task<JsonList<JsonListItem<TrackModel>>>> GetIt => session => session.GetFavoriteTracks();
        public void PutIt(OpenTidlSession session, JsonList<JsonListItem<TrackModel>> itemsToPut)
        {
            foreach (var itemToPut in itemsToPut.Items)
            {
                session.AddFavoriteTrack(itemToPut.Item.Id);
            }
        }
    }
}