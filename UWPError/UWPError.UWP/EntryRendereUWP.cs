using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Input;
using Xamarin.Forms;
using UWPError;
using Xamarin.Forms.Platform.UWP;
using System.ComponentModel;
using System.Diagnostics;
using Windows.UI.ViewManagement;

[assembly: ExportRenderer(typeof(CustomEntry), typeof(UWPError.UWP.EntryRendereUWP))]
namespace UWPError.UWP
{
    public class EntryRendereUWP : Xamarin.Forms.Platform.UWP.EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                if (Element is CustomEntry customEntry)
                {
                    Control.InputScope = new InputScope()
                    {
                        Names = { new InputScopeName(InputScopeNameValue.Number) }
                    };
                }

                FormsTextBox nativeTextBox = Control;
                nativeTextBox.PreventKeyboardDisplayOnProgrammaticFocus = false;

            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            Debug.WriteLine($"Property changed: {e.PropertyName}");

            if (e.PropertyName == CustomEntry.ShowKeyboardProperty.PropertyName)
            {
                if(sender is CustomEntry)
                {

                    Debug.WriteLine($"Show keyboard ?: {((CustomEntry)sender).ShowKeyboard}");

                    if (((CustomEntry)sender).ShowKeyboard == true)
                            InputPane.GetForCurrentView().TryShow();
                    else
                        InputPane.GetForCurrentView().TryHide();
                }

            }


        }
    }
}