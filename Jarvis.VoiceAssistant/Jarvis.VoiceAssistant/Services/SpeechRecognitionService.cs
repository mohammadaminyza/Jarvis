using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Jarvis.Domain.Entities;
using Jarvis.VoiceAssistant.Helpers;
using Xamarin.Essentials;

namespace Jarvis.VoiceAssistant.Services
{
    public class SpeechSpeechRecognitionService : ISpeechRecognitionService
    {
        private List<Command> _commands = new List<Command>();
        private ICommandService _commandService;

        public SpeechSpeechRecognitionService(ICommandService commandService)
        {
            _commandService = commandService;

            _commands.AddRange(_commandService.GetAllCommands().Result);

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
        }


        public async Task<string> Recognize()
        {
            await RequestAudioRecorderPermission();

            var recognizeText = SpeechServiceHelper.Recognizer();

            return recognizeText;
        }

        public async Task Response(string speech)
        {
            var commandResult = _commands.SingleOrDefault(p => p.CommandSentence.ToLower().Trim() == speech).ResultSentence;

            await TextToSpeech.SpeakAsync(commandResult);
        }
    }
}
