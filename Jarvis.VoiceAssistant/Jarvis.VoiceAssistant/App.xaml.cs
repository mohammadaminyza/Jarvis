using System;
using Jarvis.Core.Services;
using Jarvis.VoiceAssistant.DependencyServices;
using SimpleInjector;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Jarvis.VoiceAssistant
{
    public partial class App : Application
    {
        private static Container _dependecies = new Container();
        private static Container _container = new Container();

        public static Container Container
        {
            get
            {
                return _container;
            }
        }


        public App()
        {
            ChangeStateBarColor(Color.FromHex("#145DA0"), Color.FromHex("#B1D4E0"));

            InitializeComponent();

            MainPage = new MainPage();

            Container.Register<Jarvis.VoiceAssistant.Services.ICommandService, Jarvis.VoiceAssistant.Services.CommandService>();
        }

        protected override void OnStart()
        {
            ChangeStateBarColor(Color.FromHex("#145DA0"), Color.FromHex("#B1D4E0"));
        }

        protected override void OnSleep()
        {
            ChangeStateBarColor(Color.FromHex("#145DA0"), Color.FromHex("#B1D4E0"));
        }

        protected override void OnResume()
        {
            ChangeStateBarColor(Color.FromHex("#145DA0"), Color.FromHex("#B1D4E0"));
        }

        private void ChangeStateBarColor(Color darkMode, Color lightMode)
        {
            if (RequestedTheme == OSAppTheme.Dark)
            {
                DependencyService.Get<IStatusBarColorManager>()
                    .ChangeStatusBarColor(darkMode);
            }

            else
            {
                DependencyService.Get<IStatusBarColorManager>()
                    .ChangeStatusBarColor(lightMode);
            }
        }
    }
}
