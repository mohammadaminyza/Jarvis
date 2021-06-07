﻿using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Android.Speech;
using Jarvis.Domain.Entities;
using Jarvis.VoiceAssistant.DependencyServices;
using Jarvis.VoiceAssistant.Droid.DependencyServices;

[assembly: Xamarin.Forms.Dependency(typeof(SpeechService))]
namespace Jarvis.VoiceAssistant.Droid.DependencyServices
{
    class SpeechService : ISpeechService
    {
        public void ConfigSpeechRecognizer(IEnumerable<Command> commands)
        {

        }

        public string Recognizer()
        {
            MainActivity.Current.RecognizeSpeech();

            return MainActivity.LastSpeechText;
        }

    }
}