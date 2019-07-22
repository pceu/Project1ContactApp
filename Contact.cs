using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Project1
{
    public class Contact
    {
        // class attributes
        public string Name { get; set; }
        public string PhoneNum { get; set; }
        public string Email { get; set; }
        public string Company { get; set; }
        public int Image { get; set; }

        // class constructor
        public Contact(String name, String phoneNum, String email, String company, int image)
        {
            this.Name = name;
            this.PhoneNum = phoneNum;
            this.Email = email;
            this.Company = company;
            this.Image = image;
        }

    }
}