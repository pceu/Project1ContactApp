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
    public class MyListViewAdapter : BaseAdapter<Contact>
    {
        private List<Contact> myItems;
        private Context myContext;

        public MyListViewAdapter(Context context, List<Contact> items)
        {
            this.myItems = items;
            this.myContext = context;
        }

        public override int Count
        {
            // return how many objects in myItems list
            get { return myItems.Count; }
        }

        // return the Contact object at the position(parameter) index
        public override Contact this[int position] => myItems[position];

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View row = convertView;

            // if row is null inflate a layout (contact_list) for the row.
            if (row == null)
            {
                row = LayoutInflater.From(myContext).Inflate(Resource.Layout.contact_list, null, false);
            }

            // set the image of Contact to the row (contact_list layout) image
            ImageView image = row.FindViewById<ImageView>(Resource.Id.person_icon);
            if(myItems[position].Image == 1)
            {
                int resImage = (int)typeof(Resource.Drawable).GetField("person1").GetValue(null);
                image.SetImageResource(resImage);
            } else
            {
                int resImage = (int)typeof(Resource.Drawable).GetField("person2").GetValue(null);
                image.SetImageResource(resImage);
            }

            // set the person name
            TextView personName = row.FindViewById<TextView>(Resource.Id.personNameText);
            personName.Text = myItems[position].Name;

            // set company
            TextView personCompany = row.FindViewById<TextView>(Resource.Id.personCompanyText);
            personCompany.Text = myItems[position].Company;

            // return the row which has image, name and company
            return row;
        }
    }
}