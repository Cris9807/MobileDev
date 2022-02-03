using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Kohn11014674.Services;

namespace Kohn11014674.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPage : ContentPage
    {
        public SettingsPage()
        {
            InitializeComponent();


        }

        async void OnAddusers(object sender, System.EventArgs e)
        {
            string n = await DisplayPromptAsync("Enter:", "Enter the number of users:", initialValue: "10", maxLength: 2, keyboard: Keyboard.Numeric);
            await UserDataStore.AddRandomUsers(Int32.Parse(n));
        }

        async void OnDelete(object sender, System.EventArgs e)
        {
            await UserDataStore.DeleteUsers();
        }
    }
}