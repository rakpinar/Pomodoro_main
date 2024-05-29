using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using System;
using System.Timers;

namespace pomodoro2024
{
    [Activity(Label = "TYT Genel Deneme", Theme = "@style/AppTheme")]
    public class TytGenelDeneme : AppCompatActivity
    {
        private Button startTimerButton;
        private CountdownTimerView countdownTimerView;
        private Timer timer;
        private int remainingTimeInSeconds = 10 * 60; // 4 dakika süre

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.TytGenelDenemeMain);

            startTimerButton = FindViewById<Button>(Resource.Id.startTimerButton);
            countdownTimerView = FindViewById<CountdownTimerView>(Resource.Id.countdownTimerView);

            if (startTimerButton != null) startTimerButton.Click += StartTimerButton_Click;

            // ActionBar'a geri butonunu ekle
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            if (item.ItemId == Android.Resource.Id.Home)
            {
                OnBackPressed(); // Geri butonuna basıldığında bu aktiviteyi sonlandır ve bir önceki aktiviteye geri dön
                return true;
            }
            return base.OnOptionsItemSelected(item);
        }

        private void StartTimerButton_Click(object sender, EventArgs e)
        {
            StartTimer(4); // 4 dakika
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            RunOnUiThread(() =>
            {
                if (remainingTimeInSeconds > 0)
                {
                    remainingTimeInSeconds--;
                    countdownTimerView.SetRemainingTime(remainingTimeInSeconds);
                }
                else
                {
                    timer.Stop();
                    timer.Dispose();
                    timer = null;
                }
            });
        }

        private void StartTimer(int minutes)
        {
            // Timer'ı başlat
            if (timer == null)
            {
                remainingTimeInSeconds = minutes * 60; // Dakikaları saniyeye çevir
                timer = new Timer();
                timer.Interval = 1000; // 1 saniyede bir
                timer.Elapsed += Timer_Elapsed;
                timer.Start();

                // CountdownTimerView'i görünür hale getir ve başlangıç süresini ayarla
                countdownTimerView.Visibility = ViewStates.Visible;
                countdownTimerView.SetTotalTime(remainingTimeInSeconds); // Toplam zamanı ayarla
                countdownTimerView.SetRemainingTime(remainingTimeInSeconds); // Kalan zamanı ayarla
            }
        }
    }
}
