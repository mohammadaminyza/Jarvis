using Jarvis.VoiceAssistant.DependencyServices;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Jarvis.VoiceAssistant.Helpers
{
    public static class SqliteHelper
    {
        public static string GetSqlitePath(string dbName = "JarvisLocalDB")
        {
            return DependencyService.Get<ISqlitePathManager>().GetSqlitePath(dbName);
        }
    }
}
