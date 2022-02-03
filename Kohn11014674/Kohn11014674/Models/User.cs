using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Kohn11014674.Models
{
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public String PictureUrl { get; set; }
        public String LastName { get; set; }
        public String FirstName { get; set; }

        public String PhoneNumber { get; set; }

        public String DateOfBirth { get; set; }

        public String FullName
        {
            get => FirstName + " " + LastName;
        }
    }
}
