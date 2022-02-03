using QuickType;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kohn11014674.Models
{
    class UserHelper
    {
        public Name Name { get; set; }

        public Dob Dob { get; set; }

        public String Phone { get; set; }

        public Picture Picture { get; set; }

        public String BirthDayString => DateTime.Parse(Dob.ToString()).ToShortDateString();

        public String FullName()
        {
            return Name.First + " " + Name.Last;
        }
    }
}
