using System;
using System.Collections.Generic;
using System.Text;

namespace Jarvis.VoiceAssistant.DependencyServices
{
    public interface ISqlitePathManager
    {
        string GetSqlitePath(string dbName);
    }
}
