using System;
using System.Collections.Generic;
using System.Text;
using Jarvis.VoiceAssistant.Renders;
using Jarvis.VoiceAssistant.UWP.Renders;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;
using Jarvis.VoiceAssistant.UWP.Comman;

[assembly: ExportRenderer(typeof(FullEntry), typeof(FullEntryRender))]
namespace Jarvis.VoiceAssistant.UWP.Renders
{
    class FullEntryRender : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            if (e.OldElement != null)
            {
                var fullEntry = e.NewElement as FullEntry;

                this.Background = fullEntry.ColorBack.ToBrush();
            }

            base.OnElementChanged(e);

        }
    }
}
