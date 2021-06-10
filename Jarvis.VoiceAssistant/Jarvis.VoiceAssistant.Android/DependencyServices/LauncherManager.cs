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
using Jarvis.VoiceAssistant.DependencyServices;
using Jarvis.VoiceAssistant.Droid.DependencyServices;
using Environment = System.Environment;

[assembly: Xamarin.Forms.Dependency(typeof(LauncherManager))]
namespace Jarvis.VoiceAssistant.Droid.DependencyServices
{
    class LauncherManager : ILauncherManager
    {
        public string GetRoot()
        {
            var backingFile = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyMusic), "Music/");

            return backingFile;
        }
    }
}