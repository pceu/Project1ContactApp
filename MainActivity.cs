using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Content;
using System.Collections.Generic;

namespace Project1
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = false)]
    public class MainActivity : AppCompatActivity
    {
        //Create a list to store Contact Objects in this class
        public static List<Contact> ContactData = new List<Contact>();
        private ListView myListView;
        Button addNewContact;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            // assign buttons and listView to elements in xml file 
            myListView = FindViewById<ListView>(Resource.Id.contactsListView);
            addNewContact = FindViewById<Button>(Resource.Id.addNewContact);

            // create Contact object/s if there is no Contact object in ContactData list
            if(ContactData.Count < 1) { populateContact(); }

            //click event for addNewContact - bring user to Create New Contact page/activity
            addNewContact.Click += (sender, e) =>
            {
                Intent intent = new Intent(this, typeof(Project1.CreateNewContact));
                StartActivity(intent);

            };

            // create a list adaptor to show Contact objects in a list view
            MyListViewAdapter myAdapter = new MyListViewAdapter(this, ContactData);
            myListView.Adapter = myAdapter;

            // create onclick event for the listView
            myListView.ItemClick += MyListView_ItemClick;
        }

        // when listView is clicked, bring user to Contact Details Page
        //pass data to contact details page and display them
        private void MyListView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            // transport data to contact details using intent
            var intent = new Intent(this, typeof(Project1.ContactDetailsPage));
            intent.PutExtra("name", ContactData[e.Position].Name);
            intent.PutExtra("phoneNum", ContactData[e.Position].PhoneNum);
            intent.PutExtra("email", ContactData[e.Position].Email);
            intent.PutExtra("company", ContactData[e.Position].Company);
            intent.PutExtra("image", ContactData[e.Position].Image);
            StartActivity(intent);
        }

        // populate Contact objects programmatically
        public void populateContact()
        {
            ContactData.Add(new Contact("John Smith", "89878", "example@email.com", "DGE Co.", 1));
            ContactData.Add(new Contact("Blake Dawson", "78678", "example@email.com", "New Light Co.", 2));
            ContactData.Add(new Contact("Danny Love", "3232323", "example@email.com", "BNG Entertainment", 1));
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}