using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using System;
using System.Timers;

namespace pomodoro2024
{
    [Activity(Label = "AYT Denemeleri", Theme = "@style/AppTheme")]
    public class TwoMain : AppCompatActivity
    {
        private Button startTimerButton;
        private CountdownTimerView countdownTimerView;
        private Timer timer;
        private int remainingTimeInSeconds = 10 * 60;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_two_main);

            startTimerButton = FindViewById<Button>(Resource.Id.startTimerButton);
            countdownTimerView = FindViewById<CountdownTimerView>(Resource.Id.countdownTimerView);

            if (startTimerButton != null) startTimerButton.Click += StartTimerButton_Click;

            SupportActionBar.SetDisplayHomeAsUpEnabled(true);

            Button button40 = FindViewById<Button>(Resource.Id.button40);
            if (button40 != null) button40.Click += (sender, e) => StartTimerAndHideOtherButtons(button40);

            Button button41 = FindViewById<Button>(Resource.Id.button41);
            if (button41 != null) button41.Click += (sender, e) => StartTimerAndHideOtherButtons(button41);

            Button button42 = FindViewById<Button>(Resource.Id.button42);
            if (button42 != null) button42.Click += (sender, e) => StartTimerAndHideOtherButtons(button42);

            Button button43 = FindViewById<Button>(Resource.Id.button43);
            if (button43 != null) button43.Click += (sender, e) => StartTimerAndHideOtherButtons(button43);

            Button button44 = FindViewById<Button>(Resource.Id.button44);
            if (button44 != null) button44.Click += (sender, e) => StartTimerAndHideOtherButtons(button44);

            Button button45 = FindViewById<Button>(Resource.Id.button45);
            if (button45 != null) button45.Click += (sender, e) => StartTimerAndHideOtherButtons(button45);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            if (item.ItemId == Android.Resource.Id.Home)
            {
                OnBackPressed();
                return true;
            }
            return base.OnOptionsItemSelected(item);
        }

        private void StartTimerButton_Click(object sender, EventArgs e)
        {
            // Butona tıkladığında diğer butonların görünürlüğünü gizle
            HideOtherButtons(null);

            StartTimer();
        }

        private void StartTimerAndHideOtherButtons(Button clickedButton)
        {
            // Diğer butonları gizle ve sayacı başlat
            HideOtherButtons(clickedButton);
            StartTimer();
        }

        private void StartTimer()
        {
            if (timer == null)
            {
                timer = new Timer();
                timer.Interval = 1000;
                timer.Elapsed += Timer_Elapsed;
                timer.Start();

                countdownTimerView.Visibility = ViewStates.Visible;
                countdownTimerView.SetTotalTime(remainingTimeInSeconds);
                countdownTimerView.SetRemainingTime(remainingTimeInSeconds);
            }
        }

        private void HideOtherButtons(Button clickedButton)
        {
            // Diğer butonların ID'lerini al ve tıklanan buton dışındaki butonları gizle
            int[] buttonIds = { Resource.Id.button40, Resource.Id.button41, Resource.Id.button42, Resource.Id.button43, Resource.Id.button44, Resource.Id.button45, Resource.Id.startTimerButton };
            foreach (int id in buttonIds)
            {
                Button button = FindViewById<Button>(id);
                if (button != null && button != clickedButton)
                {
                    button.Visibility = ViewStates.Gone;
                }
            }
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
    }
}
