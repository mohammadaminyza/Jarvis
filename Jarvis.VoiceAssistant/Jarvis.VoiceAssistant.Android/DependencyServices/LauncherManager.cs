using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jarvis.VoiceAssistant.DependencyServices;
using Jarvis.VoiceAssistant.Droid.DependencyServices;
using Xamarin.Essentials;
using Environment = System.Environment;

[assembly: Xamarin.Forms.Dependency(typeof(LauncherManager))]
namespace Jarvis.VoiceAssistant.Droid.DependencyServices
{
    class LauncherManager : ILauncherManager
    {
        public string GetRoot()
        {
            var root = Path.Combine("/storage/emulated/0/");

            return root;
        }

        public List<string> GetMusicsPaths()
        {
            var musicPath = Path.Combine(GetRoot(), "Music/Music");
            var downloadPath = Path.Combine(GetRoot(), "Download");
            var managerPath = Path.Combine(GetRoot(), "ADM");

            var flacMusicPath = Directory.GetFiles(musicPath, "*.flac", SearchOption.AllDirectories);
            var mp3MusicPath = Directory.GetFiles(musicPath, "*.flac", SearchOption.AllDirectories);

            var flacDownloadPath = Directory.GetFiles(downloadPath, "*.flac", SearchOption.AllDirectories);
            var mp3DownloadPath = Directory.GetFiles(downloadPath, "*.flac", SearchOption.AllDirectories);

            var flacManagerPath = Directory.GetFiles(managerPath, "*.flac", SearchOption.AllDirectories);
            var mp3ManagerPath = Directory.GetFiles(managerPath, "*.flac", SearchOption.AllDirectories);

            var allMusics = new List<string>();

            allMusics.AddRange(flacMusicPath.ToArray());
            allMusics.AddRange(mp3MusicPath.ToArray());

            allMusics.AddRange(flacDownloadPath.ToArray());
            allMusics.AddRange(mp3DownloadPath.ToArray());

            allMusics.AddRange(flacManagerPath.ToArray());
            allMusics.AddRange(mp3ManagerPath.ToArray());

            return allMusics;
        }
    }
}