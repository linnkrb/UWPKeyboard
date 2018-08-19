using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace UWPError
{
    public class CustomEntry: Entry
    {

        public static readonly BindableProperty ShowKeyboardProperty = BindableProperty.Create(nameof(ShowKeyboard), typeof(bool), typeof(CustomEntry), false);
        public bool ShowKeyboard
        {
            get => (bool)GetValue(ShowKeyboardProperty);
            set => SetValue(ShowKeyboardProperty, value);
        }
    }
}
