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

namespace NewApp
{
    class Cat
    {
        string name;
        string owner;

        public Cat() { }


        public Cat(string name, string owner)
        {
            this.name = name;
            this.owner = owner;
        }

  
        public string Name
        {
            get {return name;}
            set { name = value; }

        }

        public string Owner
        {
            get { return owner; }
            set { owner = value; }
        }
    }
}