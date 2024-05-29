using Android.Content;
using Android.Graphics;
using Android.Runtime;
using Android.Util;
using Android.Views;
using System;

namespace pomodoro2024
{
    [Register("pomodoro2024.CountdownTimerView")]
    public class CountdownTimerView : View
    {
        private int totalTimeInSeconds;
        private int remainingTimeInSeconds;
        private Paint paint;
        private float strokeWidth;
        private float textSize;
        private RectF circleBounds;
        private Bitmap bitmap;

        public CountdownTimerView(Context context) : base(context)
        {
            Initialize();
        }

        public CountdownTimerView(Context context, IAttributeSet attrs) : base(context, attrs)
        {
            Initialize();
        }

        public CountdownTimerView(Context context, IAttributeSet attrs, int defStyle) : base(context, attrs, defStyle)
        {
            Initialize();
        }

        protected CountdownTimerView(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
            Initialize();
        }

        private void Initialize()
        {
            paint = new Paint
            {
                AntiAlias = true,
                Color = Color.Aquamarine,
                StrokeWidth = 8f,
                StrokeCap = Paint.Cap.Round
            };
            paint.SetStyle(Paint.Style.Stroke);

            strokeWidth = 10f; // Varsayılan çizgi kalınlığı
            textSize = 175f; // Varsayılan metin boyutu
            circleBounds = new RectF();
            bitmap = BitmapFactory.DecodeResource(Resources, Resource.Drawable.test5);
        }

        protected override void OnDraw(Canvas canvas)
        {
            base.OnDraw(canvas);

            if (totalTimeInSeconds != 0)
            {
                float centerX = Width / 2f;
                float centerY = Height / 2f;
                float radius = Math.Min(centerX, centerY) - strokeWidth / 2f;
                circleBounds.Set(centerX - radius, centerY - radius, centerX + radius, centerY + radius);

                // Draw the circular progress bar
                paint.Color = Color.Aqua;
                paint.StrokeWidth = strokeWidth;
                float sweepAngle = 360 * remainingTimeInSeconds / (float)totalTimeInSeconds;
                canvas.DrawArc(circleBounds, -90, sweepAngle, false, paint);

                // Draw the resized bitmap at the center
                if (bitmap != null)
                {
                    // Resize the bitmap to fit within the circle
                    float diameter = 2 * radius;
                    Bitmap scaledBitmap = Bitmap.CreateScaledBitmap(bitmap, (int)diameter, (int)diameter, true);
                    float left = centerX - scaledBitmap.Width / 2f;
                    float top = centerY - scaledBitmap.Height / 2f;
                    canvas.DrawBitmap(scaledBitmap, left, top, paint);
                }

                // Draw the remaining time text
                string remainingTime = TimeSpan.FromSeconds(remainingTimeInSeconds).ToString(@"mm\:ss");

                // Change the text color to red if less than 3 minutes remaining
                if (remainingTimeInSeconds <= 180)
                {
                    paint.Color = Color.Red;
                }
                else
                {
                    paint.Color = Color.Black;
                }

                paint.TextAlign = Paint.Align.Center;
                paint.TextSize = textSize; // Metin boyutunu ayarla
                float textY = centerY - ((paint.Descent() + paint.Ascent()) / 2);
                canvas.DrawText(remainingTime, centerX, textY, paint);
            }
        }

        public void SetTotalTime(int totalTimeInSeconds)
        {
            this.totalTimeInSeconds = totalTimeInSeconds;
        }

        public void SetRemainingTime(int remainingTimeInSeconds)
        {
            this.remainingTimeInSeconds = remainingTimeInSeconds;
            Invalidate(); // Redraw the view
        }

        public void SetStrokeWidth(float strokeWidth)
        {
            this.strokeWidth = strokeWidth;
            Invalidate(); // Redraw the view to apply the new stroke width
        }

        public void SetTextSize(float textSize)
        {
            this.textSize = textSize;
            Invalidate(); // Redraw the view to apply the new text size
        }

        public void SetTextStrokeWidth(float textStrokeWidth)
        {
            paint.StrokeWidth = textStrokeWidth;
            Invalidate(); // Redraw the view to apply the new text stroke width
        }
    }
}
