using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Project1
{
    [Activity(Label = "ContactDetailsPage")]
    public class ContactDetailsPage : Activity
    {
        ImageView contactImage;
        TextView detailsFullName, phoneNumber, emailAddress, companyName, editButton;
        Button phoneCallButton, messageButton, emailButton;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_contact_details_page);

            // Create your application here
            // assign (buttons, textviews, and imageView) id to elements in this class
            contactImage = FindViewById<ImageView>(Resource.Id.contactImage);
            detailsFullName = FindViewById<TextView>(Resource.Id.detailsFullName);
            phoneNumber = FindViewById<TextView>(Resource.Id.phoneNumber);
            emailAddress = FindViewById<TextView>(Resource.Id.emailAddress);
            companyName = FindViewById<TextView>(Resource.Id.companyName);
            editButton = FindViewById<TextView>(Resource.Id.editButton);
            phoneCallButton = FindViewById<Button>(Resource.Id.phoneCallButton);
            messageButton = FindViewById<Button>(Resource.Id.messageButton);
            emailButton = FindViewById<Button>(Resource.Id.emailButton);

            // Store data sent through Intent in tem variables
            String iName = (String)Intent.GetStringExtra("name");
            String iPhoneNum = (String)Intent.GetStringExtra("phoneNum");
            String iEmail = (String)Intent.GetStringExtra("email");
            String iCompany = (String)Intent.GetStringExtra("company");
            int iImage = (int)Intent.GetIntExtra("image", 1);

            // display data sent from MainActivity(listView) in this activity
            detailsFullName.Text = iName;
            phoneNumber.Text = iPhoneNum;
            emailAddress.Text = iEmail;
            companyName.Text = iCompany;
            if(iImage == 1)
            {
                int resImage = (int)typeof(Resource.Drawable).GetField("person1").GetValue(null);
                contactImage.SetImageResource(resImage);
            }
            else
            {
                int resImage = (int)typeof(Resource.Drawable).GetField("person2").GetValue(null);
                contactImage.SetImageResource(resImage);
            }

            phoneCallButton.Click += delegate
            {
                string[] PermissionsLocation = { Manifest.Permission.CallPhone};
                RequestPermissions(PermissionsLocation, 0);
                if (!String.IsNullOrEmpty(iPhoneNum))
                {
                    Intent callIntent = new Intent(Intent.ActionCall);
                    callIntent.SetData(Android.Net.Uri.Parse("tel: " + iPhoneNum));
                    StartActivity(callIntent);
                }
            };


        }
    }
}