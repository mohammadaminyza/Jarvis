using System;
using System.Collections.Generic;
using System.Text;
using Jarvis.VoiceAssistant.DependencyServices;
using Xamarin.Forms;

namespace Jarvis.VoiceAssistant.Helpers
{
    public static class LaunchHelper
    {
        public static string GetRootPath()
        {
            return DependencyService.Get<ILauncherManager>().GetRoot();
        }
    }
}
