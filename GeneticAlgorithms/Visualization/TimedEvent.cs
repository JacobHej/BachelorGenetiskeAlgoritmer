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
        }

        public void Start()
        {
            timer = new System.Timers.Timer();

            timer.Interval = interval;
            timer.AutoReset = true;
            timer.Elapsed += OnTimedEvent;
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
