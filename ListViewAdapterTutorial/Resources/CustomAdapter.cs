using System.Collections.Generic;
using Android.App;
using Android.Views;
using Android.Widget;
using Java.Lang;

namespace ListViewAdapterTutorial.Resources
{
    public class ViewHolder : Object
    {
        public TextView TxtName { get; set; }
        public TextView TxtSurname { get; set; }
        public TextView TxtAge { get; set; }
    }
    public class CustomAdapter : BaseAdapter
    {
        private Activity activity;
        private List<Person> persons;

        public CustomAdapter(Activity activity,List<Person> persons)
        {
            this.activity = activity;
            this.persons = persons;
        }
        public override int Count => persons.Count;

        public override Object GetItem(int position)
        {
          return persons[position];
        }

        public override long GetItemId(int position)
        {
            return persons[position].Id;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView ?? activity.LayoutInflater.Inflate(Resource.Layout.activity_ListView, parent, false);

            var txtName = view.FindViewById<TextView>(Resource.Id.NameView);
            var txtSurname = view.FindViewById<TextView>(Resource.Id.SurnameView);
            var txtAge = view.FindViewById<TextView>(Resource.Id.AgeView);

            txtName.Text = persons[position].Name;
            txtSurname.Text = persons[position].Surname;
            txtAge.Text = persons[position].Age.ToString();

            return view;
        }

    }
}