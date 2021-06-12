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
            async Task MusicPlayerWithCommand(string command)
            {
                var songName = speech.ToLower().Replace("play music", "");

                await LauncherHelper.PlayMusic(songName);
            }

            if (speech.Contains("play music"))
            {
                await MusicPlayerWithCommand("play music");
            }
            else if (speech.ToLower().Contains("play song"))
            {
                await MusicPlayerWithCommand("play song");
            }
            else if (speech.ToLower().Contains("play"))
            {
                await MusicPlayerWithCommand("play");
            }
            else if (speech.ToLower().Contains("search"))
            {
                var query = speech.ToLower().Replace("search", "").Trim();

                await LauncherHelper.SearchInGoogle(query);
            }
            else if (speech.ToLower().Contains("what time is it"))
            {
                await Speech($"It's {DateTime.Now.Hour} And {DateTime.Now.Minute} O'Clock");
            }
            else if (speech.ToLower().Contains("write note"))
            {
                //Todo Write Note And Fix Api
            }
            else
            {
                var commandResult =
                    _commands.SingleOrDefault(p => p.CommandSentence == speech.ToLower().Trim())?.ResultSentence ??
                    "Oh Didn't Get That";

                var rootAddress = LaunchPathHelper.GetRootPath();

                await Speech(commandResult);
                return commandResult;

            }

            return "Done";
        }

        public string GetLastRecognize()
        {
            var recognizeText = SpeechServiceHelper.GetLastRecognizer();

            return recognizeText;
        }
    }
}
