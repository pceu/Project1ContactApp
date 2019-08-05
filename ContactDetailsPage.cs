using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.Content;
using Android.Views;
using Android.Widget;

namespace Project1
{
    [Activity(Label = "ContactDetailsPage")]
    public class ContactDetailsPage : Activity
    {
        ImageView contactImage;
        TextView detailsFullName, phoneNumber, emailAddress, companyName;
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
            // depending on which icon (person1 or 2) is choosed assign a drawable for the contact image
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

            // PHone Call Button
            phoneCallButton.Click += delegate
            {
                // check phone call permission and activate phone call if permitted
                if (ContextCompat.CheckSelfPermission(this, Manifest.Permission.CallPhone) == (int)Permission.Granted)
                {
                    if (!String.IsNullOrEmpty(iPhoneNum))
                    {
                        Intent callIntent = new Intent(Intent.ActionCall);
                        callIntent.SetData(Android.Net.Uri.Parse("tel:" + iPhoneNum));
                        StartActivity(callIntent);
                    }
                }
                else // if not permitted, then ask for runtime permission
                {                    
                    string[] PermissionsLocation = { Manifest.Permission.CallPhone };
                    RequestPermissions(PermissionsLocation, 0);
                    // pop message to let user know to allow for permission
                    var toast = Toast.MakeText(this, "Allow Phone call permission for this feature to work!", ToastLength.Long);
                    toast.Show();
                }
                
            };

            // Send Message Button
            messageButton.Click += delegate
            {
                // check send sms permission and activate send sms if permitted
                if (ContextCompat.CheckSelfPermission(this, Manifest.Permission.CallPhone) == (int)Permission.Granted)
                {
                    if (!String.IsNullOrEmpty(iPhoneNum))
                    {
                        Intent messageIntent = new Intent(Intent.ActionView);
                        messageIntent.SetData(Android.Net.Uri.Parse("tel:" + iPhoneNum));
                        StartActivity(messageIntent);
                    }
                }
                else // if not permitted, then ask for runtime permission
                {
                    string[] PermissionsLocation = { Manifest.Permission.SendSms };
                    RequestPermissions(PermissionsLocation, 0);
                    // pop message to let user know to allow for permission
                    var toast = Toast.MakeText(this, "Allow Send SMS permission for this feature to work!", ToastLength.Long);
                    toast.Show();
                }
            };

            // Send email Button
            // open email and send email when email button is pressed
            emailButton.Click += delegate
            {
                Intent emailIntent = new Intent(Intent.ActionView);
                emailIntent.SetData(Android.Net.Uri.Parse("mailto:" + iEmail));
                StartActivity(emailIntent);
            };


        }
    }
}