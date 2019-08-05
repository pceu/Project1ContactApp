using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Project1
{
    [Activity(Label = "CreateNewContact")]
    public class CreateNewContact : Activity
    {
        Button saveButton;
        Button cancelButton;
        EditText contactNameInput;
        EditText phoneNumberInput;
        EditText emailInput;
        EditText companyInput;

        private static String errorMessage;

        // radio button variable for checking whether which option is checked for contact image
        RadioButton person1;
        RadioButton person2;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_create_new_contact);

            // Create your application here
            // assign each variables defined in above to the related id in XML file
            saveButton = FindViewById<Button>(Resource.Id.saveButton);
            cancelButton =FindViewById<Button>(Resource.Id.cancelButton);
            contactNameInput = FindViewById<EditText>(Resource.Id.contactNameInput);
            phoneNumberInput = FindViewById<EditText>(Resource.Id.phoneNumberInput);
            emailInput = FindViewById<EditText>(Resource.Id.emailInput);
            companyInput = FindViewById<EditText>(Resource.Id.urCompanyInput);
            person1 = FindViewById<RadioButton>(Resource.Id.contactIcon1);
            person2 = FindViewById<RadioButton>(Resource.Id.contactIcon2);

            // save button ( save and add the newly created Contact object to the Contact List in main page
            saveButton.Click += delegate
            {
                // validate text entered first (such as email, phone) and create the new Contact only validation is successed
                if (validateData())
                {
                    Intent intent = new Intent(this, typeof(Project1.MainActivity));
                    /*intent.PutExtra("contactName", contactNameInput.Text);
                    intent.PutExtra("phoneNumber", phoneNumberInput.Text);
                    intent.PutExtra("email", emailInput.Text);
                    intent.PutExtra("company", companyInput.Text);
                    if(person1.Checked) { intent.PutExtra("image", 1); }
                    else { intent.PutExtra("image", 2); }*/
                    MainActivity.ContactData.Add(new Contact(contactNameInput.Text, phoneNumberInput.Text, emailInput.Text, companyInput.Text, whichImage()));
                    StartActivity(intent);
                }
                else
                {
                    // show alert message to user what did they do wrong
                    AlertDialog.Builder alertDialog = new AlertDialog.Builder(this);
                    alertDialog.SetTitle("Opps!");
                    alertDialog.SetMessage(errorMessage);
                    alertDialog.SetNeutralButton("OK", delegate
                    {
                        alertDialog.Dispose();
                    });
                    alertDialog.Show();
                }
            };

            // Cancel Button - bring user to main page again without adding or creating any Contact object to the list
            cancelButton.Click += delegate
            {
                Intent intent = new Intent(this, typeof(Project1.MainActivity));
                StartActivity(intent);
            };
            
        }

        public void saveContact(View view)
        {
            if(validateData())
            {
                Intent intent = new Intent(this, typeof(Project1.MainActivity));
                /*intent.PutExtra("contactName", contactNameInput.Text);
                intent.PutExtra("phoneNumber", phoneNumberInput.Text);
                intent.PutExtra("email", emailInput.Text);
                intent.PutExtra("company", companyInput.Text);
                if(person1.Checked) { intent.PutExtra("image", 1); }
                else { intent.PutExtra("image", 2); }*/
                MainActivity.ContactData.Add(new Contact(contactNameInput.Text, phoneNumberInput.Text, emailInput.Text, companyInput.Text, whichImage()));
                StartActivity(intent);
            }
        }

        // data validation for name, phone number, email and so on
        public bool validateData()
        {
            bool result;
            if(String.IsNullOrEmpty(contactNameInput.Text))
            {
                result = false;
                errorMessage = "Name cannot be empty!";
                return result;
            }
            if (String.IsNullOrEmpty(phoneNumberInput.Text) && !phoneNumberInput.Text.All(char.IsDigit))
            {
                result = false;
                errorMessage = "Phone number cannot be empty or contains other than digits";
                return result;
            }
            if(!String.IsNullOrEmpty(emailInput.Text))
            {
                if(!IsValidEmailAddress(emailInput.Text))
                {
                    result = false;
                    errorMessage = "Invalid email address!";
                    return result;
                }
            }
            if(String.IsNullOrEmpty(companyInput.Text))
            {
                companyInput.Text = "";
            }
            if (!person1.Checked && !person2.Checked)
            {
                result = false;
                errorMessage = "Choose one image for contact image!";
                return result;
            }

            return true;
        }

        // get snippet from https://www.codeproject.com/Questions/560442/codeplusforplus
        public bool IsValidEmailAddress(string s)
        {
            if (string.IsNullOrEmpty(s))
                return false;
            else
            {
                var regex = new Regex(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");
                return regex.IsMatch(s) && !s.EndsWith(".");
            }
        }


        // whichImage retuns 1 if person 1 check box is checked, or returns 2 otherwise
        public int whichImage()
        {
            if (person1.Checked)
            {
                return 1;
            }
            else
            {
                return 2;
            }
        }
    }
}