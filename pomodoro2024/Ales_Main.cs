using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using System;
using System.Timers;

namespace pomodoro2024
{
    [Activity(Label = "Ales Denemeleri", Theme = "@style/AppTheme")]
    public class Ales_Main : AppCompatActivity
    {
        private Button startTimerButton;
        private CountdownTimerView countdownTimerView; // CountdownTimerView ekledik
        private Timer timer;
        private int remainingTimeInSeconds = 5 * 60;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Ales_Main);

            startTimerButton = FindViewById<Button>(Resource.Id.startTimerButton);
            countdownTimerView = FindViewById<CountdownTimerView>(Resource.Id.countdownTimerView); // CountdownTimerView'ı tanımladık

            if (startTimerButton != null) startTimerButton.Click += StartTimerButton_Click;

            // ActionBar'a geri butonunu ekle
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);

            // Diğer butonları tanımla ve tıklama olaylarını ayarla
            Button button50 = FindViewById<Button>(Resource.Id.button50);
            if (button50 != null) button50.Click += (sender, e) => StartTimer(6); // 10 dakika

            Button button51 = FindViewById<Button>(Resource.Id.button51);
            if (button51 != null) button51.Click += (sender, e) => StartTimer(6); // 10 dakika


        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            if (item.ItemId == Android.Resource.Id.Home)
            {
                OnBackPressed(); // Geri butona basıldığında bu aktiviteyi sonlandır ve bir önceki aktiviteye geri dön
                return true;
            }
            return base.OnOptionsItemSelected(item);
        }

        private void StartTimerButton_Click(object sender, EventArgs e)
        {
            // Timer'ı başlat
            if (timer == null)
            {
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

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            RunOnUiThread(() =>
            {
                if (remainingTimeInSeconds > 0)
                {
                    remainingTimeInSeconds--;
                    // CountdownTimerView'i güncelle
                    countdownTimerView.SetRemainingTime(remainingTimeInSeconds);
                }
                else
                {
                    // Zaman dolduğunda yapılacak işlemler
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
