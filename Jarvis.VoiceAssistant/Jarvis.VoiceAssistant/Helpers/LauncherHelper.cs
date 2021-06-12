using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace Jarvis.VoiceAssistant.Helpers
{
    public static class LauncherHelper
    {
        public static async Task OpenUrl(string url)
        {
            await Launcher.OpenAsync(url);
        }

        public static async Task SearchInGoogle(string query)
        {
            var googleAddress = $"https://google.com/search?q={query}";

            await Launcher.OpenAsync(googleAddress);
        }

        public static string GetSongPath(string musicName)
        {
            var songsPath = LaunchPathHelper.GetMusicsPaths();
            var songPath = songsPath.FirstOrDefault(p => p.ToLower().Contains(musicName));

            return songPath;
        }

        public static async Task PlayMusic(string musicName)
        {
            var songPath = GetSongPath(musicName);

            try
            {
                await Launcher.OpenAsync(new OpenFileRequest()
                {
                    File = new ReadOnlyFile(songPath),
                    Title = "Choose Player"
                });
            }
            catch (Exception)
            {
                await TextToSpeech.SpeakAsync("Sorry Song Didn't Found");
            }
        }
    }
}
