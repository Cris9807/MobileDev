using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Kohn11014674.ViewModels;

namespace Kohn11014674.Views
{
    public partial class UserDetailPage : ContentPage
    {
        public UserDetailPage()
        {
            InitializeComponent();
            BindingContext = new UserDetailViewModel();
        }
    }
}