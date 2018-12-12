using Android.App;
using Android.Widget;
using Android.OS;
using System.IO;
using SQLite;
using YordanYordanov.Models;
using Android.Content;

namespace YordanYordanov
{
    [Activity(Label = "Kontrolna Rabota", MainLauncher = true)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            
            var btn1 = FindViewById<Button>(Resource.Id.button1);
            var btn2 = FindViewById<Button>(Resource.Id.button2);
            btn1.Click += RenderSecActivity;
        }

        private void RenderSecActivity(object sender, System.EventArgs e)
        {
            var intent = new Intent(this, typeof(SecActivity));
            StartActivity(intent);
        }       
    }
}

