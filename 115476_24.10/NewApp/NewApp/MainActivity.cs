using Android.App;
using Android.Widget;
using Android.OS;
using System;
using static Android.Resource;

namespace NewApp
{
    [Activity(Label = "NewApp", MainLauncher = true)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            Button my_button = FindViewById<Button>(Resource.Id.button1);
            my_button.Click += My_button_Click;

        }

        private void My_button_Click(object sender, EventArgs e)
        {
            TextView my_textview1 = FindViewById<TextView>(Resource.Id.textView1);
            TextView my_textview2 = FindViewById<TextView>(Resource.Id.textView2);
            TextView my_textview3 = FindViewById<TextView>(Resource.Id.textView3);
            EditText my_edittext1 = FindViewById<EditText>(Resource.Id.editText1);
            EditText my_edittext2 = FindViewById<EditText>(Resource.Id.editText2);

            /* my_textview.Text = my_edittext.Text;
             my_edittext.Text = "";

            int num;
            num = Int32.Parse(my_textview.Text);


             if (num % 2 == 0) // here can be used out and parse, inside a simple if is the if (num%2)else and 
                 //outside to be the else with the text 
             {
                 my_textview.Text = my_edittext.Text + "This is number is even";
             }
             else //if (num /2==0)
             {
                 my_textview.Text = my_edittext.Text + "This number is Odd";
             } */
            //  else
            //  {
            //      Console.WriteLine("This was not a number!!");



            Cat MyPuss = new Cat("Snowflake", "Nicki");
            Cat MyOtherPuss = new Cat();
            MyOtherPuss.Name = "Blacky";
            MyOtherPuss.Owner = "Miro";

            Cat ThirdPuss = new Cat();
            ThirdPuss.Name = my_edittext1.Text;
            ThirdPuss.Owner = my_edittext2.Text;

            my_textview1.Text = "My cat: \n" + MyPuss.Name + "\n" + "Owner:\n" + MyPuss.Owner;
            my_textview2.Text = "Other cat:\n" + MyOtherPuss.Name + "\n" + "Owner is:\n " + MyOtherPuss.Owner;

            my_textview3.Text = "Third cat:\n" + ThirdPuss.Name + "\n" + "Owner is:\n" + ThirdPuss.Owner;

        }


    }



}


