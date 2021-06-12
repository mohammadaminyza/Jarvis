using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Jarvis.VoiceAssistant.DependencyServices
{
    public interface ILauncherManager
    {
        string GetRoot();
        List<string> GetMusicsPaths();
    }
}
