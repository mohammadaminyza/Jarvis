using Jarvis.VoiceAssistant.DependencyServices;
using Jarvis.VoiceAssistant.UWP.DependencyServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

[assembly: Xamarin.Forms.Dependency(typeof(LauncherManager))]
namespace Jarvis.VoiceAssistant.UWP.DependencyServices
{
    class LauncherManager : ILauncherManager
    {
        public string GetRoot()
        {

            var backingFile = Path.Combine(@"E:\Music", "Amir Tataloo - Ba To.flac");

            return backingFile;
        }
    }
}
