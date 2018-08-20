using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace UWPError
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
            
		}

        protected override async void OnAppearing()
        {

            base.OnAppearing();

            await ShowHideKeyboardOnFocus();

        }

        private async Task ShowHideKeyboardOnFocus()
        {
            // Without dealay focus is never triggered
            await Task.Delay(100); //  smaller delay will result in that it does not get focus, and keyboard not working (sometimes even higher is needed)
            FocustStatus.Text = "Custom rendre focus and keyboard open (close again after 2 sec)";

            FocusEntryRendere.Focus();
            FocusEntryRendere.ShowKeyboard = true;

            await Task.Delay(2000);
            FocusEntryRendere.ShowKeyboard = false;

            await Task.Delay(2000);

            FocusEntry.Focus();
            FocustStatus.Text = "Expecting focus (and keyboard) (but not showing)";
            await Task.Delay(2000);

            FocusEntry.Focus();
            FocustStatus.Text = "Expecting focus (and keyboard) after a delay(but not showing)";


            await Task.Delay(2000);

            FocusEntryRendere.Focus();
            FocustStatus.Text = "Expecting focus and keyboard on custom rendre entry (but not showing)";
            await Task.Delay(2000);

            FocusEntryRendere.ShowKeyboard = true;
            FocustStatus.Text = "Explisit keyboard on custom rendre entry (showing sometimes) ";
            await Task.Delay(2000);

            FocusEntryRendere.ShowKeyboard = false;
            FocustStatus.Text = "Explisit hide keyboard on custom rendre entry (hiding)";

            await Task.Delay(2000);

            FocusEntry.Focus();
            FocustStatus.Text = "Focus on Entry (should show keyboard) (but is not)";

            await Task.Delay(2000);

            FocusEntryRendere.Focus();
            FocustStatus.Text = "Focus on Custom Entry (should show keyboard) (but is not)";


            FocusEntryRendere.Focus();
            await Task.Delay(600);
            FocusEntryRendere.ShowKeyboard = true;
            FocustStatus.Text = "Focus and the explisit show keyboard";
        }

        private void Entry_Focused(object sender, FocusEventArgs e)
        {
            Debug.WriteLine("FocusEntry - got focus");
   
        }

        private void FocusEntryRendere_Focused(object sender, FocusEventArgs e)
        {
            Debug.WriteLine("FocusEntryRendere - got focus");

        }

        private void ButonFunAgain_Clicked(object sender, EventArgs e)
        {
             ShowHideKeyboardOnFocus();
        }

        private void ButtonShowKeyboard_Clicked(object sender, EventArgs e)
        {
            FocusEntryRendere.ShowKeyboard = true;
        }

        private void ButtonHideKeyboard_Clicked(object sender, EventArgs e)
        {
            FocusEntryRendere.ShowKeyboard = false;
        }
    }
}
