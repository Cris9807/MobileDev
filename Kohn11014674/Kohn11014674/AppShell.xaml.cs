using Kohn11014674.ViewModels;
using Kohn11014674.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Kohn11014674
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(UserDetailPage), typeof(UserDetailPage));
        }
    }
}
