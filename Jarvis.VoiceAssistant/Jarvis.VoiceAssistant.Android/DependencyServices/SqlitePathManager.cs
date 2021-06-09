using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Jarvis.VoiceAssistant.DependencyServices;
using Jarvis.VoiceAssistant.Droid.DependencyServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

[assembly: Xamarin.Forms.Dependency(typeof(SqlitePathManager))]
namespace Jarvis.VoiceAssistant.Droid.DependencyServices
{
    class SqlitePathManager : ISqlitePathManager
    {
        public string GetSqlitePath(string dbName)
        {
            var path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);

            return Path.Combine(path, dbName);
        }
    }
}