using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Jarvis.Domain.Entities;
using Jarvis.VoiceAssistant.DependencyServices;
using Jarvis.VoiceAssistant.Helpers;
using Xamarin.Essentials;
using Xamarin.Forms;

using Command = Jarvis.Domain.Entities.Command;

namespace Jarvis.VoiceAssistant.Services
{
    public class SpeechSpeechRecognitionService : ISpeechRecognitionService
    {
        private List<Command> _commands = new List<Command>();
        private ICommandService _commandService = new CommandService();

        public SpeechSpeechRecognitionService()
        {
            var commands = _commandService.GetAllCommands();

            _commands.AddRange(commands);

            SpeechServiceHelper.Config(_commands);
        }

        private async Task RequestAudioRecorderPermission()
        {
            if (await Permissions.CheckStatusAsync<Permissions.Microphone>() != PermissionStatus.Granted)
            {
                await Permissions.RequestAsync<Permissions.Microphone>();
            }

            if (await Permissions.CheckStatusAsync<Permissions.StorageWrite>() != PermissionStatus.Granted)
            {
                await Permissions.RequestAsync<Permissions.StorageWrite>();
            }

            if (await Permissions.CheckStatusAsync<Permissions.StorageRead>() != PermissionStatus.Granted)
            {
                await Permissions.RequestAsync<Permissions.StorageRead>();
            }

            if (await Permissions.CheckStatusAsync<Permissions.Speech>() != PermissionStatus.Granted)
            {
                await Permissions.RequestAsync<Permissions.Speech>();
            }

            if (await Permissions.CheckStatusAsync<Permissions.LaunchApp>() != PermissionStatus.Granted)
            {
                await Permissions.RequestAsync<Permissions.LaunchApp>();
            }
        }

        private async Task Speech(string speech)
        {
            await TextToSpeech.SpeakAsync(speech);
        }

        public async Task Recognize()
        {
            await RequestAudioRecorderPermission();

            SpeechServiceHelper.Recognizer();
        }

        public async Task<string> Response(string speech)
        {
            var commandResult = _commands.SingleOrDefault(p => p.CommandSentence.Contains(speech))?.ResultSentence ?? "Oh Didn't Get That";

            var rootAddress = LaunchHelper.GetRootPath();

            await Speech(commandResult);

            return commandResult;
        }

        public string GetLastRecognize()
        {
            var recognizeText = SpeechServiceHelper.GetLastRecognizer();

            return recognizeText;
        }
    }
}
