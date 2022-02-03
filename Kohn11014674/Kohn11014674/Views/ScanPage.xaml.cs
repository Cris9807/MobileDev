using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Kohn11014674.Services;
using Kohn11014674.Models;

namespace Kohn11014674.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ScanPage : ContentPage
    {
        public ScanPage()
        {
            InitializeComponent();
        }

        public void resultScan(ZXing.Result result)
        {
            String resultString = "";
            int numericValue;
            Device.BeginInvokeOnMainThread(() =>
            {
                resultString = result.QrcodeFormat.ToString();
                
            });
            
            if(int.TryParse(resultString, numericValue))
            {
                User user = UserDataStore.GetUser(resultString);
                if(user != null)
                {
                    Shell.Current.GoToAsync($"{nameof(UserDetailPage)}?{nameof(UserDetailViewModel.UserId)}={user.Id}");
                }
            }
        }
    }
}