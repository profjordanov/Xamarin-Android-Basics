using Android.App;
using Android.Widget;
using Android.OS;
using System.Net.Http;
using System.Threading.Tasks;
using News.Client.Models;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace News.Client
{
    [Activity(Label = "News.Client", MainLauncher = true)]
    public class MainActivity : Activity
    {
        static HttpClient httpClient = new HttpClient();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            Button getBtn = FindViewById<Button>(Resource.Id.button1);
            TextView text = FindViewById<TextView>(Resource.Id.textView1);
            getBtn.Click += (sender, e) =>
            {
                var list = new List<NewsUxModel>();
                var uri = "http://10.0.2.2:56624/api/News";
                try
                {
                    var result = httpClient.GetStringAsync(uri).GetAwaiter().GetResult();
                    try
                    {
                        var news = JsonConvert.DeserializeObject<List<NewsUxModel>>(result);
                        list.AddRange(news);
                    }
                    catch (System.Exception ex)
                    {
                        throw;
                    }
                }
                catch (System.Exception exp)
                {
                    var msg = exp.InnerException.Message;
                    throw;
                }

                var arr = list.ToArray();
                text.Text = arr[0].Title;
            };
        }
    }
}

