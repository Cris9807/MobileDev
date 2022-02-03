using Kohn11014674.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Xamarin.Forms;

namespace Kohn11014674.ViewModels
{
    [QueryProperty(nameof(UserId), nameof(UserId))]
    public class UserDetailViewModel : BaseViewModel
    {
        private String userId;

        private String pictureUrl;
        private String lastName;
        private String firstName;
        private String phoneNumber;
        private String dateOfBirth;
        public String PictureUrl 
        {
            get => pictureUrl;
            set => SetProperty(ref pictureUrl, value);
        }
        public String LastName
        {
            get => lastName;
            set => SetProperty(ref lastName, value);
        }
        public String FirstName
        {
            get => firstName;
            set => SetProperty(ref firstName, value);
        }

        public String PhoneNumber
        {
            get => phoneNumber;
            set => SetProperty(ref phoneNumber, value);
        }

        public String DateOfBirth
        {
            get => dateOfBirth;
            set => SetProperty(ref dateOfBirth, value);
        }

        public String FullName
        {
            get => FirstName + " " + LastName;
        }

        public String UserId
        {
            get => userId;
            set
            {
                userId = value;
                LoadUserId(value);
            }
        }

        public async void LoadUserId(string userID)
        {
            try
            {
                var user = await UserDataStore.GetUser(userID);

                FirstName = user.FirstName;
                LastName = user.LastName;
                PhoneNumber = user.PhoneNumber;
                DateOfBirth = user.DateOfBirth;
                PictureUrl = user.PictureUrl;
                
            }
            catch (Exception e)
            {
                Debug.WriteLine("Failed to load user");
            }
        }
    }
}
