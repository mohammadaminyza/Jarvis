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
        private ISpeechRecognitionService _speechRecognitionService = new SpeechSpeechRecognitionService();
        public MainPage()
        {
            InitializeComponent();
        }

        private async void StartVoiceAssistant_OnClicked(object sender, EventArgs e)
        {
            SoundWave.IsAnimationPlaying = true;

            StartBtn.BackgroundColor = Color.Red;

            await _speechRecognitionService.Recognize();



            StartBtn.BackgroundColor = Color.Aquamarine;

        }


        private async void ResponseOrder_OnClicked(object sender, EventArgs e)
        {
            StopBtn.BackgroundColor = Color.Aqua;


            var speech = _speechRecognitionService.GetLastRecognize();
            Speecked.Text = speech;

            if (speech != "")
            {
                var result = await _speechRecognitionService.Response(speech);
                Speecked.Text = result;
            }

            StopBtn.BackgroundColor = Color.CornflowerBlue;

            SoundWave.IsAnimationPlaying = false;
        }
    }
}
