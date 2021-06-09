using Jarvis.VoiceAssistant.DependencyServices;
using Jarvis.VoiceAssistant.UWP.DependencyServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[assembly: Xamarin.Forms.Dependency(typeof(SqlitePathManger))]
namespace Jarvis.VoiceAssistant.UWP.DependencyServices
{
    class SqlitePathManger : ISqlitePathManager
    {
        public string GetSqlitePath(string dbName)
        {
            var path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);

            return Path.Combine(path, dbName);
        }
    }
}
