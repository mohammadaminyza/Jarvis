using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Jarvis.VoiceAssistant.Services
{
    public interface ISpeechRecognitionService
    {
        Task<string> Recognize();
        Task Response(string speech);
    }
}
