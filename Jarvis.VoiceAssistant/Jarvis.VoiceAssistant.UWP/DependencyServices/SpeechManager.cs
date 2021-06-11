using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Speech.Recognition;
using System.Text;
using System.Threading.Tasks;
using Jarvis.Domain.Entities;
using Jarvis.VoiceAssistant.DependencyServices;
using Jarvis.VoiceAssistant.UWP.DependencyServices;

[assembly: Xamarin.Forms.Dependency(typeof(SpeechManager))]
namespace Jarvis.VoiceAssistant.UWP.DependencyServices
{
    class SpeechManager : ISpeechManager
    {
        private List<Command> _commands = new List<Command>();
        private string _lastRecognize = "";
        private void AddSentences(IEnumerable<Command> commands)
        {
            //TODO Speech Recognizer
        }

        private void SendResult(string commandText)
        {
            _lastRecognize = commandText;
        }

        public void ConfigSpeechRecognizer(IEnumerable<Command> commands)
        {
            _commands.AddRange(commands);

            AddSentences(commands);
        }

        public void Recognizer()
        {

        }

        private void RecognitionEngineOnSpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            SendResult(e.Result.Text);
        }

        public string GetLastRecognizer()
        {
            return _lastRecognize;
        }
    }
}
