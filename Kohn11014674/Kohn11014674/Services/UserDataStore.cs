using Kohn11014674.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Essentials;
using QuickType;
using Newtonsoft.Json;
using System.Net.Http;
using System.Diagnostics;

namespace Kohn11014674.Services
{
    public static class UserDataStore
    {
        public static SQLiteAsyncConnection db;

        public static async Task Init()
        {
            if(db != null)
            {
                return;
            }
            var databasePath = Path.Combine(FileSystem.AppDataDirectory, "MyUsers.db");

            db = new SQLiteAsyncConnection(databasePath);
            await db.CreateTableAsync<User>();
        }

        public static async Task DeleteUsers()
        {
            await db.DeleteAllAsync<User>();
        }

        public static async Task AddUser(String lastName, String firstName, String picUrl, String phoneNumber, String dateOfBirth)
        {
            await Init();

            var user = new User
            {
                LastName = lastName,
                FirstName = firstName,
                PictureUrl = picUrl,
                PhoneNumber = phoneNumber,
                DateOfBirth = dateOfBirth
            };

            await db.InsertAsync(user);
        }

        public static async Task RemoveUser(int id)
        {
            await Init();

            await db.DeleteAsync<User>(id);
            
        }

        public static async Task<IEnumerable<User>> GetUsers()
        {
            await Init();

            var users = await db.Table<User>().ToListAsync();

            var sorted = users.OrderBy(o => o.FullName).ToList();

            return sorted;
        }

        public static async Task AddRandomUsers(int amount)
        {
            for(int i = 1; i <= amount; i++)
            {
                var url = "https://randomuser.me/api/?inc=name,picture,phone,dob";
                var httpClient = new HttpClient();
                var result = await httpClient.GetStringAsync(url);
                var data = JsonConvert.DeserializeObject<Welcome>(result);

                String lastName = "";
                String firstName = "";
                String birthDay = "";
                String pictureUrl;
                String phone = "";
                String id = "";

                List<UserHelper> userHelper = data.Results.Select(x => new UserHelper()
                {
                    Name = x.Name,
                    Phone = x.Phone,
                    Dob = x.Dob,
                    Picture = x.Picture
                }).ToList();

                UserHelper helper = userHelper[0];

                lastName = helper.Name.Last;
                firstName = helper.Name.First;
                phone = helper.Phone;
                pictureUrl = helper.Picture.Large.ToString();
                birthDay = helper.Dob.Date.DateTime.ToShortDateString();

                await AddUser(lastName, firstName, pictureUrl, phone, birthDay);
            }
        }

        public static async Task<User> GetUser(String id)
        {
            int queryID = Int32.Parse(id);
            await Init();

            var user = await db.Table<User>().FirstOrDefaultAsync(u => u.Id == queryID);
            return user;
        }

    }
}
