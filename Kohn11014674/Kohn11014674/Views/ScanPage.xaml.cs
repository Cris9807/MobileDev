using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Kohn11014674.Services;
using Kohn11014674.Models;
using Kohn11014674.ViewModels;

namespace Kohn11014674.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ScanPage : ContentPage
    {
        public ScanPage()
        {
            InitializeComponent();
        }

        public async void resultScan(ZXing.Result result)
        {
            String resultString = "";
            int numericValue;
            Device.BeginInvokeOnMainThread(() =>
            {
                resultString = result.Text;
                
            });
            
            if(int.TryParse(resultString, out numericValue))
            {
                User user = await UserDataStore.GetUser(resultString);
                if(user != null)
                {
                    Shell.Current.GoToAsync($"{nameof(UserDetailPage)}?{nameof(UserDetailViewModel.UserId)}={user.Id}");
                }
            }
        }
    }
}