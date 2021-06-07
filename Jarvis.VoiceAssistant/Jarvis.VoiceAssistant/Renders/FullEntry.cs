using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Jarvis.VoiceAssistant.Renders
{
    public class FullEntry : Entry
    {
        public static readonly BindableProperty ColorBackProperty = BindableProperty.Create(nameof(ColorBack), typeof(Color), typeof(Color), Color.Blue);
        public static readonly BindableProperty ColorBorderProperty = BindableProperty.Create(nameof(ColorBorder), typeof(Color), typeof(Color), Color.DarkBlue);


        public Color ColorBack
        {
            get
            {
                return (Color)GetValue(ColorBackProperty);
            }
            set
            {
                SetValue(ColorBackProperty, value);
            }
        }
        public Color ColorBorder
        {
            get
            {
                return (Color)GetValue(ColorBorderProperty);
            }
            set
            {
                SetValue(ColorBorderProperty, value);
            }
        }

    }
}
