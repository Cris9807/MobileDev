using Kohn11014674.Models;
using Kohn11014674.Views;
using Kohn11014674.Services;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Collections.Generic;

namespace Kohn11014674.ViewModels
{
    public class UsersViewModel : BaseViewModel
    {
        private User _selectedUser;

        public ObservableCollection<User> Users { get; }

        public Command LoadUsersCommand { get; }

        public Command<User> UserTapped { get; }

        public UsersViewModel()
        {
            Title = "Users";

            Users = new ObservableCollection<User>();

            LoadUsersCommand = new Command(async () => await ExecuteLoadUsersCommand());

            UserTapped = new Command<User>(OnUserSelected);
        }


        async Task ExecuteLoadUsersCommand()
        {
            IsBusy = true;
            try
            {
                Users.Clear();
                var users = await UserDataStore.GetUsers();
                foreach(var user in users)
                {
                    Users.Add(user);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public void OnAppearing()
        {
            IsBusy = true;
            SelectedUser = null;
        }

        public User SelectedUser
        {
            get => _selectedUser;
            set
            {
                SetProperty(ref _selectedUser, value);
                OnUserSelected(value);
            }
        }

        async void OnUserSelected(User user)
        {
            if(user == null)
            {
                return;
            }
            await Shell.Current.GoToAsync($"{nameof(UserDetailPage)}?{nameof(UserDetailViewModel.UserId)}={user.Id}");
        }


    }
}