using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace TeamANumbrix.Model
{
    public class PuzzleTimer
    {
        /// <summary>
        /// The dispatcher timer
        /// </summary>
        public DispatcherTimer DispatcherTimer;

        public string TimerText;

        public PuzzleTimer()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PuzzleTimer"/> class.
        /// </summary>
        public PuzzleTimer(DispatcherTimer timer)
        { 
            this.DispatcherTimer = timer;
            this.TimerText = "";
        }

        public void initializeTimer()
        {
            this.DispatcherTimer.Interval = TimeSpan.FromSeconds(1);
            this.DispatcherTimer.Tick += this.timer_Tick;
            this.DispatcherTimer.Start();
        }

        private void timer_Tick(object sender, object e)
        {
            this.TimerText = DateTime.Now.ToLongTimeString();
        }

        void timer_Tick(object sender, EventArgs e)
        {
            this.TimerText = DateTime.Now.ToLongTimeString();
        }
    }
}
