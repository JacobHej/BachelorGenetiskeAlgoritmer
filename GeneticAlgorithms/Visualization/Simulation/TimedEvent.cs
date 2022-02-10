using System.Timers;

namespace Visualization
{
    public class TimedEvent
    {
        private int interval;
        private Action eventAction;
        private System.Timers.Timer timer;

        public TimedEvent(int interval, Action action)
        {
            this.interval = interval;

            this.eventAction = action;

            this.timer = new System.Timers.Timer();
            this.timer.Interval = interval;
            this.timer.AutoReset = true;
            this.timer.Elapsed += OnTimedEvent;
        }

        public void Start()
        {
            timer.Start();
        }

        private void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
        {
            eventAction.Invoke();
        }

        public void Stop()
        {
            timer.Stop();
        }
    }
}
