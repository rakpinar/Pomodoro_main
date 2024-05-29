using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace pomodoro2024
{
    [Activity(Label = "Pomodoro ", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            Button button1 = FindViewById<Button>(Resource.Id.button1);
            Button button2 = FindViewById<Button>(Resource.Id.button2);
            Button button3 = FindViewById<Button>(Resource.Id.button3);
            Button button4 = FindViewById<Button>(Resource.Id.button4);
            Button button5 = FindViewById<Button>(Resource.Id.button5);
            Button button6 = FindViewById<Button>(Resource.Id.button6);
            Button button7 = FindViewById<Button>(Resource.Id.button7);
            Button button20 = FindViewById<Button>(Resource.Id.button20);

            if (button1 != null)
                button1.Click += (sender, e) =>
                {
                    var intent = new Intent(this, typeof(TwoMain));
                    StartActivity(intent);
                };

            if (button2 != null)
                button2.Click += (sender, e) =>
                {
                    var intent = new Intent(this, typeof(ThreeMain));
                    StartActivity(intent);
                };
            

            if (button3 != null)
                button3.Click += (sender, e) =>
                {
                    var intent = new Intent(this, typeof(KpssMain));
                    StartActivity(intent);
                };

            if (button4 != null)
                button4.Click += (sender, e) =>
                {
                    var intent = new Intent(this, typeof(Ales_Main));
                    StartActivity(intent);
                };

            if (button5 != null)
                button5.Click += (sender, e) =>
                {
                    var intent = new Intent(this, typeof(DgsMain));
                    StartActivity(intent);
                };
            if (button6 != null)
                button6.Click += (sender, e) =>
                {
                    var intent = new Intent(this, typeof(MsuMain));
                    StartActivity(intent);
                };
            if (button7 != null)
                button7.Click += (sender, e) =>
            {
                var intent = new Intent(this, typeof(TytGenelDeneme));
                StartActivity(intent);
            };
            if (button20 != null)
                button20.Click += (sender, e) =>
                {
                    var intent = new Intent(this, typeof(AytGenelDeneme));
                    StartActivity(intent);
                };
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            if (item.ItemId == Android.Resource.Id.Home)
            {
                Finish(); // MainActivity'den geri butona basıldığında uygulamadan çıkmak için bu satırı kullanın
                return true;
            }
            return base.OnOptionsItemSelected(item);
        }
    }
}

