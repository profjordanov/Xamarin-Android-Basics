using Android.App;
using Android.Widget;
using Android.OS;

namespace Navigation
{
    [Activity(Label = "Navigation", MainLauncher = true)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            ActionBar.NavigationMode = ActionBarNavigationMode.Tabs;

            ActionBar.Tab mytab = ActionBar.NewTab();
            mytab.SetText(Resource.String.tab1_text);
            mytab.SetIcon(Resource.Drawable.images);
            mytab.TabSelected += Mytab_TabSelected;
            ActionBar.AddTab(mytab);
            
            mytab = ActionBar.NewTab();
            mytab.SetText(Resource.String.tab2_text);
            mytab.SetIcon(Resource.Drawable.download);
            mytab.TabReselected += Mytab_TabReselected;
            ActionBar.AddTab(mytab);
            
        }

        private void Mytab_TabReselected(object sender, ActionBar.TabEventArgs e)
        {
            e.FragmentTransaction.Add(Resource.Id.frameLayout1,new TabFragment());
            // throw new System.NotImplementedException();
        }

        private void Mytab_TabSelected(object sender, ActionBar.TabEventArgs e)
        {
           // throw new System.NotImplementedException();
        }
    }
}

