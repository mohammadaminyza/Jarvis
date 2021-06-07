using System;
using System.Collections.Generic;
using System.Text;
using Jarvis.VoiceAssistant.DependencyServices;
using Xamarin.Forms;
using Command = Jarvis.Domain.Entities.Command;

namespace Jarvis.VoiceAssistant.Helpers
{
    public static class SpeechServiceHelper
    {
        public static void Config(IEnumerable<Command> commands)
        {
            DependencyService.Get<ISpeechService>().ConfigSpeechRecognizer(commands);
        }

        public static string Recognizer()
        {
            return DependencyService.Get<ISpeechService>().Recognizer();
        }
    }
}
