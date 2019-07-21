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
        private string name;
        private string phoneNum;
        private string email;
        private string company;
        private int image;

        // class constructor
        public Contact(String name, String phoneNum, String email, String company, int image)
        {
            this.name = name;
            this.phoneNum = phoneNum;
            this.email = email;
            this.company = company;
            this.image = image;
        }

        public String getName()
        {
            return name;
        }

        public String getPhoneNum()
        {
            return phoneNum;
        }

        public String getEmail()
        {
            return email;
        }

        public String getCompany()
        {
            return company;
        }

        public int getImage()
        {
            return image;
        }

        public void setName(String name)
        {
            this.name = name;
        }

        public void setPhoneNum(String phoneNum)
        {
            this.phoneNum = phoneNum;
        }

        public void setEmail(String email)
        {
            this.email = email;
        }

        public void setCompany(String company)
        {
            this.company = company;
        }

        public void setImage(int image)
        {
            this.image = image;
        }

    }
}