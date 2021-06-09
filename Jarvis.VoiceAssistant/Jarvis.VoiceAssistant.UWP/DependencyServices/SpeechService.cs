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

[assembly: Xamarin.Forms.Dependency(typeof(SpeechService))]
namespace Jarvis.VoiceAssistant.UWP.DependencyServices
{
    class SpeechService : ISpeechService
    {
        private SpeechRecognitionEngine _recognitionEngine = new SpeechRecognitionEngine();
        private List<Command> _commands = new List<Command>();
        private string _lastRecognize = "";
        private void AddSentences(IEnumerable<Command> commands)
        {
            Choices sentences = new Choices();
            var sentencesList = _commands.Select(n => n.CommandSentence).ToArray();
            sentences.Add(sentencesList);
            GrammarBuilder sentencesGrammarBuilder = new GrammarBuilder();
            sentencesGrammarBuilder.Append(sentences);
            Grammar sentencesGrammar = new Grammar(sentencesGrammarBuilder);
            _recognitionEngine.LoadGrammarAsync(sentencesGrammar);
        }

        private void SendResult(string commandText)
        {
            _lastRecognize = commandText;
        }

        public void ConfigSpeechRecognizer(IEnumerable<Command> commands)
        {
            _commands.AddRange(commands);
            _recognitionEngine.SetInputToDefaultAudioDevice();
            AddSentences(commands);
        }

        public void Recognizer()
        {
            _recognitionEngine.Recognize();
            _recognitionEngine.SpeechRecognized += RecognitionEngineOnSpeechRecognized;
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
