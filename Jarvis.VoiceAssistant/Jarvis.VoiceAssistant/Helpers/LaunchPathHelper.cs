using System;
using System.Collections.Generic;
using System.Text;
using Jarvis.VoiceAssistant.DependencyServices;
using Xamarin.Forms;

namespace Jarvis.VoiceAssistant.Helpers
{
    public static class LaunchPathHelper
    {
        public static string GetRootPath()
        {
            return DependencyService.Get<ILauncherManager>().GetRoot();
        }

        public static List<string> GetMusicsPaths()
        {
            return DependencyService.Get<ILauncherManager>().GetMusicsPaths();
        }
    }
}
