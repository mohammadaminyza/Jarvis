using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jarvis.Domain.Entities;
using Jarvis.VoiceAssistant.DependencyServices;
using Jarvis.VoiceAssistant.UWP.DependencyServices;
using Windows.Media.SpeechRecognition;

[assembly: Xamarin.Forms.Dependency(typeof(SpeechManager))]
namespace Jarvis.VoiceAssistant.UWP.DependencyServices
{
    class SpeechManager : ISpeechManager
    {
        private SpeechRecognizer _speechRecognizer = new SpeechRecognizer();
        private List<Command> _commands = new List<Command>();
        private string _lastRecognize = "";


        private void SendResult(string commandText)
        {
            _lastRecognize = commandText;
        }

        public async Task Recognizer()
        {
            await _speechRecognizer.CompileConstraintsAsync();

            _speechRecognizer.Timeouts.InitialSilenceTimeout = TimeSpan.FromSeconds(5);
            _speechRecognizer.Timeouts.EndSilenceTimeout = TimeSpan.FromSeconds(20);

            _speechRecognizer.UIOptions.AudiblePrompt = "Say whatever you like, I'm listening";
            _speechRecognizer.UIOptions.ExampleText = "The quick brown fox jumps over the lazy dog";
            _speechRecognizer.UIOptions.ShowConfirmation = true;
            _speechRecognizer.UIOptions.IsReadBackEnabled = true;
            _speechRecognizer.Timeouts.BabbleTimeout = TimeSpan.FromSeconds(5);

            var result = await _speechRecognizer.RecognizeWithUIAsync();

            if (result != null)
            {
                StringBuilder builder = new StringBuilder();

                builder.AppendLine(
                  $"I have {result.Confidence} confidence that you said [{result.Text}] " +
                  $"and it took {result.PhraseDuration.TotalSeconds} seconds to say it " +
                  $"starting at {result.PhraseStartTime:g}");

                var alternates = result.GetAlternates(10);

                builder.AppendLine(
                  $"There were {alternates?.Count} alternates - listed below (if any)");

                if (alternates != null)
                {
                    foreach (var alternate in alternates)
                    {
                        builder.AppendLine(
                          $"Alternate {alternate.Confidence} confident you said [{alternate.Text}]");
                    }
                }
                builder.ToString();

                _lastRecognize = result.Text;
            }
        }



        public string GetLastRecognizer()
        {
            return _lastRecognize;
        }

    }
}
