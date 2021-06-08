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
        }


        public async Task<string> Recognize()
        {
            await RequestAudioRecorderPermission();

            var recognizeText = SpeechServiceHelper.Recognizer();

            return recognizeText;
        }

        public async Task Response(string speech)
        {
            var commandResult = _commands.SingleOrDefault(p => p.CommandSentence == speech)?.ResultSentence;

            if (commandResult == null || commandResult == "")
            {
                commandResult = "Oh Sorry, Didn't Get That";
            }

            await TextToSpeech.SpeakAsync(commandResult);
        }
    }
}
