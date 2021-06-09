using System;
using System.Globalization;
using Windows.UI.ViewManagement;
using Jarvis.VoiceAssistant.DependencyServices;
using Xamarin.Forms;
using Jarvis.VoiceAssistant.UWP.Comman;


[assembly: Xamarin.Forms.Dependency(typeof(Jarvis.VoiceAssistant.UWP.DependencyServices.StatusBarColorManager))]
namespace Jarvis.VoiceAssistant.UWP.DependencyServices
{
    public class StatusBarColorManager : IStatusBarColorManager
    {
        public void ChangeStatusBarColor(Color color)
        {

            var titleBar = ApplicationView.GetForCurrentView().TitleBar;

            var hexColor = color.ToHex();

            var a = ExtensionsColorUwp.HexToA(hexColor);
            var r = ExtensionsColorUwp.HexToR(hexColor);
            var g = ExtensionsColorUwp.HexToG(hexColor);
            var b = ExtensionsColorUwp.HexToB(hexColor);

            titleBar.BackgroundColor = Windows.UI.Color.FromArgb(a, r, g, b);
            titleBar.ButtonBackgroundColor = Windows.UI.Color.FromArgb(a, r, g, b);
        }
    }
}