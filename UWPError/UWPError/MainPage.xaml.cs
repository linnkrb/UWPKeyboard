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
            await Task.Delay(600);

            FocusEntry.Focus();


            await Task.Delay(1200);
           
            FocusEntryRendere.Focus();
            await Task.Delay(6000);

            FocusEntryRendere.ShowKeyboard = true;
            await Task.Delay(1200);

            FocusEntryRendere.ShowKeyboard = false;


            await Task.Delay(1200);

            FocusEntry.Focus();
        }

        private void Entry_Focused(object sender, FocusEventArgs e)
        {
            Debug.WriteLine("FocusEntry - got focus");
   
        }

        private void FocusEntryRendere_Focused(object sender, FocusEventArgs e)
        {
            Debug.WriteLine("FocusEntryRendere - got focus");
            FocusEntryRendere.ShowKeyboard = true;

        }

        
    }
}
