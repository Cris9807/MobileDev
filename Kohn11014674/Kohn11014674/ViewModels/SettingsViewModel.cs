using Kohn11014674.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Kohn11014674.ViewModels
{
    class SettingsViewModel : BaseViewModel
    {
        public Command DeleteUsers { get; }
        public Command GenerateUsers { get; }

        public SettingsViewModel()
        {

        }

        async void OnDelete()
        {
            await UserDataStore.DeleteUsers();
        }

        async void OnAddUsers()
        {
            
        }

    }
}
