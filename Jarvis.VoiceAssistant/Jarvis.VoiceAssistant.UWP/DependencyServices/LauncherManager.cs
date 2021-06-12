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
        public List<string> GetMusicsPaths()
        {
            string[] mp3Musics = Directory.GetFiles(@"E:\Music", "*.mp3", SearchOption.AllDirectories);
            string[] flacMusics = Directory.GetFiles(@"E:\Music", "*.flac", SearchOption.AllDirectories);

            var allMusics = new List<string>();

            allMusics.AddRange(mp3Musics.ToList());
            allMusics.AddRange(flacMusics.ToList());

            return allMusics;
        }

        public string GetRoot()
        {

            return "C:\\";
        }
    }
}
