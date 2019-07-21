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
            get { return myItems.Count; }
        }

        public override Contact this[int position] => myItems[position];

        public override long GetItemId(int position)
        {
            throw new NotImplementedException();
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            View row = convertView;

            if (row != null)
            {
                row = LayoutInflater.From(myContext).Inflate(Resource.Layout.contact_list, null, false);
            }
            ImageView image = row.FindViewById<ImageView>(Resource.Id.person_icon);

            TextView personName = row.FindViewById<TextView>(Resource.Id.personNameText);
            personName.Text = myItems[position].getName();

            TextView personCompany = row.FindViewById<TextView>(Resource.Id.personCompanyText);
            personCompany.Text = myItems[position].getCompany();

            throw new NotImplementedException();
        }
    }
}