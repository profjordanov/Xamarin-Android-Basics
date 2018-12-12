using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SQLite;
using YordanYordanov.Models;

namespace YordanYordanov
{
    [Activity(Label = "SecActivity")]
    public class SecActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.SecScreen);

            InitDb();

            InitSpinner();

            var btn1 = FindViewById<Button>(Resource.Id.button1);
            var btn2 = FindViewById<Button>(Resource.Id.button2);
            btn1.Click += SetStudentInfoFromDb;
            btn2.Click += OpenDialog;
        }

        private void InitSpinner()
        {
            var spinner = FindViewById<Spinner>(Resource.Id.spinner1);
            var adapter = ArrayAdapter.CreateFromResource(
                    this, Resource.Array.num_array, Android.Resource.Layout.SimpleSpinnerItem);

            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            spinner.Adapter = adapter;
        }

        private void OpenDialog(object sender, System.EventArgs e)
        {
            AlertDialog.Builder builder = new AlertDialog.Builder(this);
            AlertDialog dialog = builder.Create();
            dialog.SetTitle("Question?");
            TextView tx = (TextView)sender;
            dialog.SetMessage("Da startiram li kontaktite na tela?");
            dialog.SetButton("OK", (c, ev) =>
            {
                var uri = Android.Net.Uri.Parse("content://contacts/people/");
                var intent = new Intent(Intent.ActionView, uri);
                StartActivity(intent);

            });

            dialog.SetButton2("Cancel", (c, ev) =>
            {

            });

            dialog.Show();
        }

        private void SetStudentInfoFromDb(object sender, System.EventArgs e)
        {
            var text = FindViewById<TextView>(Resource.Id.textView1);
            var dbPath =
                Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "uni.db3");
            var uni = new SQLiteConnection(dbPath);
            var table = uni.Table<Student>();
            var student = table.FirstOrDefault();
            if (student != null)
            {
                text.Text = $"{student.FacultyNumber}-{student.FullName}";
            }
        }

        private void InitDb()
        {
            var dbPath =
                Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "uni.db3");

            var uni = new SQLiteConnection(dbPath);
            uni.CreateTable<Student>();

            if (uni.Table<Student>().Count() == 0)
            {
                var student = new Student
                {
                    FacultyNumber = "114452",
                    FullName = "Yordan Yordanov"
                };

                uni.Insert(student);
            }
        }
    }
}