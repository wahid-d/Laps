using System;
using System.Diagnostics;
using System.Windows.Input;
using MvvmHelpers;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Laps.ViewModels
{
    public class TimerPageViewModel : BaseViewModel
    {
        Stopwatch stopwatch = new Stopwatch();

        public TimerPageViewModel()
        {
            TimerGridTappedCommand = new Command(execute: StartTimer);
        }

        private void StartTimer(object obj)
        {

            if (stopwatch.IsRunning)
            {
                stopwatch.Stop();
                return;
            }

            stopwatch = new Stopwatch();

            stopwatch.Start();

            try
            {
                // Perform click feedback
                HapticFeedback.Perform(HapticFeedbackType.Click);
            }
            catch (FeatureNotSupportedException ex)
            {
                // Feature not supported on device
            }
            catch (Exception ex)
            {
                // Other error has occurred.
            }

            Device.StartTimer(TimeSpan.FromMilliseconds(1), UpdateUI);

        }

        private bool UpdateUI()
        {

            HoursLapsed = string.Format($"{stopwatch.Elapsed.Hours:D2}");
            MinutesLapsed = string.Format($"{(stopwatch.Elapsed.Minutes % 60):D2}");
            SecondsLapsed = string.Format($"{(stopwatch.Elapsed.Seconds % 60):D2}");
            MilliSecondsLapsed = string.Format($"{(stopwatch.ElapsedMilliseconds % 1000):D3}");

            return stopwatch.IsRunning;
        }

        public ICommand TimerGridTappedCommand { get; set; }

        private string _milliSecondsLapsed;
        public string MilliSecondsLapsed
        {
            get => _milliSecondsLapsed;
            set => SetProperty(ref _milliSecondsLapsed, value);
        }

        private string _minutesLapsed;
        public string MinutesLapsed
        {
            get => _minutesLapsed;
            set => SetProperty(ref _minutesLapsed, value);
        }

        private string _hoursLapsed;
        public string HoursLapsed
        {
            get => _hoursLapsed;
            set => SetProperty(ref _hoursLapsed, value);
        }

        private string _secondsLapsed;
        public string SecondsLapsed
        {
            get => _secondsLapsed;
            set => SetProperty(ref _secondsLapsed, value);
        }
    }
}
