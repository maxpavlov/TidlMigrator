using System;
using System.Threading.Tasks;
using OpenTidl.Methods;
using OpenTidl.Models;
using OpenTidl.Models.Base;

namespace TidlMigrator.App.ThingsToBackup
{
    public interface ISomethingToMigrate<T>
    {
        string FriendlyName { get; }
        Func<OpenTidlSession, Task<T>> GetIt { get; }
        void PutIt(OpenTidlSession session, T itemsToPut);
    }
}