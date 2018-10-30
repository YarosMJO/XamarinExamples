using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Widget;
using System.Collections.Generic;
using ListViewAdapterTutorial.Resources;
using System;
using Android.Views;
using Java.Lang;
using Android.Content;

namespace ListViewAdapterTutorial
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : Activity
    {
        private Button btnShow;
        private ListView lstData;

        public List<Person> listPersons;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            try
            {
                SetContentView(Resource.Layout.activity_main);
                lstData = FindViewById<ListView>(Resource.Id.listView1);
                listPersons = new List<Person>();
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
            
            btnShow = FindViewById<Button>(Resource.Id.ShowButton);
        }

        private void ButtonClick(object s, EventArgs args)
        {

            for (int i = 0; i < 20; i++)
            {
                Person person = new Person();
                person.Id = i;
                person.Name = "Subject" + i;
                person.Surname = "Derived";
                person.Age = 20 + i;
                listPersons.Add(person);
            }

            var adapter = new CustomAdapter(this, listPersons);

            //ListAdapter = new ArrayAdapter<Person>(this, Android.Resource.Layout.SimpleListItem1, listPersons);
            //ListAdapter.
            //lstData.Adapter = ListAdapter;
            lstData.Adapter = adapter;
        }

        protected override void OnResume()
        {
            base.OnResume();

            btnShow.Click += ButtonClick;
            //lstData.ItemClick += OnListItemClick;
            //Object.assignHandler((sender) => evHandler(sender, someData));
            lstData.ItemClick += OnListItemClick;

        }

        protected override void OnPause()
        {
            base.OnPause();

            btnShow.Click -= ButtonClick;
            lstData.ItemClick -= OnListItemClick;
        }
        
        private void OnListItemClick(object sender, AdapterView.ItemClickEventArgs args)
        {
            var t = listPersons[args.Position].ToString();
            Toast.MakeText(this, t,ToastLength.Short).Show();
        }
    }
}