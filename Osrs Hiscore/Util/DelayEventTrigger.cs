using System;
using System.Windows;
using System.Windows.Threading;

namespace Osrs_Hiscore.Util
{
    public class DelayedEventTrigger : System.Windows.Interactivity.EventTrigger
    {
        private EventArgs _args;
        private DispatcherTimer _dispatcherTimer;

        public static readonly DependencyProperty DelayProperty = DependencyProperty.Register(
            "Delay",
            typeof(int),
            typeof(DelayedEventTrigger),
            new PropertyMetadata(1000)
        );

        private int Delay => (int) GetValue(DelayProperty);

        protected override void OnEvent(EventArgs eventArgs)
        {
            _dispatcherTimer?.Stop();
            _args = eventArgs;
            _dispatcherTimer = new DispatcherTimer {Interval = TimeSpan.FromMilliseconds(Delay)};
            _dispatcherTimer.Tick += OnDispatcherTimerTick;
            _dispatcherTimer.Start();
        }

        protected override void OnDetaching()
        {
            if (_dispatcherTimer != null)
            {
                _dispatcherTimer.Stop();
                _dispatcherTimer = null;
            }

            base.OnDetaching();
        }

        private void OnDispatcherTimerTick(object sender, EventArgs e)
        {
            _dispatcherTimer.Stop();
            InvokeActions(_args);
        }
    }
}