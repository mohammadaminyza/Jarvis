﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Jarvis.VoiceAssistant.DependencyServices
{
    public interface IStatusBarColorService
    {
        void ChangeStatusBarColor(Color color);
    }
}
