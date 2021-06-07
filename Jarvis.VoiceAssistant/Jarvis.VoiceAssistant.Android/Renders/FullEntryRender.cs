using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.Graphics.Drawables;
using Jarvis.VoiceAssistant.Droid.Renders;
using Jarvis.VoiceAssistant.Renders;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(FullEntry), typeof(FullEntryRender))]
namespace Jarvis.VoiceAssistant.Droid.Renders
{
    class FullEntryRender : EntryRenderer
    {
        public FullEntryRender(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement == null)
            {
                //Control.SetBackgroundResource(Resource.Layout.rounded_shape);
                var coustomeEntry = e.NewElement as FullEntry;


                var BackgroundColorInput = Android.Graphics.Color.ParseColor(coustomeEntry.ColorBack.ToHex());

                var BorderColorInput = Android.Graphics.Color.ParseColor(coustomeEntry.ColorBorder.ToHex());


                var gradientDrawable = new GradientDrawable();
                gradientDrawable.SetCornerRadius(30f);
                gradientDrawable.SetStroke(5, BorderColorInput);
                gradientDrawable.SetColor(BackgroundColorInput);
                Control.SetBackground(gradientDrawable);

                Control.SetPadding(50, Control.PaddingTop, Control.PaddingRight,
                    Control.PaddingBottom);
            }
        }
    }
}