using Android.App;
using Android.Widget;
using Android.OS;
using System;

namespace _07_11xamarin
{
    [Activity(Label = "_07_11xamarin", MainLauncher = true)]
    public class MainActivity : Activity
    {


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            RadioButton radioButton1= FindViewById<RadioButton>(Resource.Id.radioButton1);
            RadioButton radionButton2=FindViewById<RadioButton>(Resource.Id.radioButton2);
          //  RadioButton radioButton4 = FindViewById<RadioButton>(Resource.Id.radioButton4);
          //  RadioButton radionButton5 = FindViewById<RadioButton>(Resource.Id.radioButton5);


            radioButton1.Click += rButton_Click;
            radionButton2.Click += rButton_Click;

            TextView txt = FindViewById<TextView>(Resource.Id.textView1);
            txt.Click += Txt_Click;
           // radioButton4.Click += rButton_Click;
           // radionButton5.Click += rButton_Click;



        }

        private void Txt_Click(object sender, EventArgs e)
        {
          AlertDialog.Builder builder = new AlertDialog.Builder(this);
            AlertDialog dialog = builder.Create();
            dialog.SetTitle("Question?");
            TextView tx = (TextView)sender;
            dialog.SetMessage("Do you like " + tx.Text+"?");
            dialog.SetIcon(Resource.Drawable.download);

            dialog.SetButton("Yes", (c, ev) =>
            {
                Toast.MakeText(this, "You like " + tx.Text, ToastLength.Long).Show();
            });

            dialog.SetButton2("No", (c, ev) =>
            {
                Toast.MakeText(this, "You dislike " + tx.Text, ToastLength.Long).Show();
            });

            dialog.Show();


            //throw new NotImplementedException();
        }

        private void rButton_Click(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            TextView textView1 = FindViewById<TextView>(Resource.Id.textView1);
            textView1.Text = rb.Text;

           // throw new NotImplementedException();
        }

        
    }
}

