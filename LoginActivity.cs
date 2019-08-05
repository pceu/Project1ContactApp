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
    [Activity(Label = "LoginActivity", MainLauncher = true)]
    public class LoginActivity : Activity
    {
        // a list of LoginDetails object/s (username & password) to contain hardcoded login credentials
        List<LoginDetails> loginDetails = new List<LoginDetails>();

        Button loginButton;
        EditText userNameInput;
        EditText passwordInput;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_login);

            // Create your application here
            userNameInput = FindViewById<EditText>(Resource.Id.userNameInput);
            passwordInput = FindViewById<EditText>(Resource.Id.passwordInput);
            loginButton = FindViewById<Button>(Resource.Id.loginButton);

            // add hardcoded loginDetails
            loginDetails.Add(new LoginDetails("smith", "sm123"));
            loginDetails.Add(new LoginDetails("jack", "j66"));

            // validate login details with hardcoded login details when loginButton is pressed
            loginButton.Click += delegate
            {
                // compare the provided login credentials (username & password) with each credential in the loginDetails List
                foreach(LoginDetails l in loginDetails)
                {
                    // if success (match username and password), bring user to main page
                    if(userNameInput.Text.Equals(l.UserName) && passwordInput.Text.Equals(l.Password))
                    {
                        var intent = new Intent(this, typeof(Project1.MainActivity));
                        StartActivity(intent);
                        break;
                    }
                    else
                    {
                        // if the provided information is incorrect, then inform user that an invalid login details has been provided
                        AlertDialog.Builder alertDialog = new AlertDialog.Builder(this);
                        alertDialog.SetTitle("Invalid Login");
                        alertDialog.SetMessage("You have entered an invalid login details");
                        alertDialog.SetNeutralButton("OK", delegate
                        {
                            alertDialog.Dispose();
                        });
                        alertDialog.Show();
                        // emptied username and password textfield
                        userNameInput.Text= "";
                        passwordInput.Text = "";
                    }
                }
            };

        }

        // Inner class/child class for loginDetails list
        protected class LoginDetails
        {
            public string UserName { get; set; }
            public string Password { get; set; }
            public LoginDetails(string username, string password)
            {
                this.UserName = username;
                this.Password = password;
            }
        }
    }
}