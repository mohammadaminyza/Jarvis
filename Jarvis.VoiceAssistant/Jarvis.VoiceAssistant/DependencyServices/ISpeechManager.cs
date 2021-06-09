using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Jarvis.Domain.Entities;

namespace Jarvis.VoiceAssistant.DependencyServices
{
    public interface ISpeechManager
    {
        void ConfigSpeechRecognizer(IEnumerable<Command> commands);
        void Recognizer();
        string GetLastRecognizer();
    }
}
