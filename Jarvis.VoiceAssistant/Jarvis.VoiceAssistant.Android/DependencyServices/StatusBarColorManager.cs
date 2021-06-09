using System;
using Android.OS;
using System.Collections.Generic;
using System.Threading.Tasks;
using Android.Util;
using Jarvis.VoiceAssistant.DependencyServices;
using Plugin.CurrentActivity;
using Xamarin.Forms;

[assembly: Xamarin.Forms.Dependency(typeof(Jarvis.VoiceAssistant.Droid.DependencyServices.StatusBarColorManager))]
namespace Jarvis.VoiceAssistant.Droid.DependencyServices
{
    public class StatusBarColorManager : IStatusBarColorManager
    {
        public void ChangeStatusBarColor(Color color)
        {
            if (Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop)
            {
                var androidColor =
                    Android.Graphics.Color.ParseColor(color.ToHex());

                CrossCurrentActivity.Current.Activity.Window.SetStatusBarColor(androidColor);
            }
        }
    }
}