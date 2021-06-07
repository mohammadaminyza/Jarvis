using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jarvis.VoiceAssistant.Helpers;
using Jarvis.VoiceAssistant.Services;
using Xamarin.Forms;

namespace Jarvis.VoiceAssistant
{
    public partial class MainPage : ContentPage
    {
        private ISpeechRecognitionService _speechRecognitionService = new SpeechSpeechRecognitionService(new CommandService());
        public MainPage()
        {
            InitializeComponent();
        }

        private async void StartVoiceAssistant_OnClicked(object sender, EventArgs e)
        {
            StartBtn.BackgroundColor = Color.Red;
            var speech = await _speechRecognitionService.Recognize();

            Speecked.Text = speech;

            if (speech != "")
            {
                await _speechRecognitionService.Response(speech);
            }

            StartBtn.BackgroundColor = Color.Aquamarine;

        }

        private void StopOrder_OnClicked(object sender, EventArgs e)
        {
            StopBtn.BackgroundColor = Color.Aqua;


            StopBtn.BackgroundColor = Color.CornflowerBlue;
        }
    }
}
