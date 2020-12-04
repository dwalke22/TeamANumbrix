using System;
using Windows.UI.Xaml;

namespace TeamANumbrix.Model
{
    /// <summary>
    ///     The puzzle timer class
    /// </summary>
    public class PuzzleTimer
    {
        #region Data members

        /// <summary>
        ///     The dispatcher timer
        /// </summary>
        public DispatcherTimer DispatcherTimer;

        /// <summary>
        ///     The string representation of the time elapsed
        /// </summary>
        public string TimerText;

        #endregion

        #region Constructors

        /// <summary>
        ///     Instantiates a new pule timer
        /// </summary>
        public PuzzleTimer()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="PuzzleTimer" /> class.
        /// </summary>
        public PuzzleTimer(DispatcherTimer timer)
        {
            this.DispatcherTimer = timer;
            this.TimerText = "";
        }

        #endregion

        #region Methods

        /// <summary>
        ///     Initializes Timer
        /// </summary>
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

        /// <summary>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer_Tick(object sender, EventArgs e)
        {
            this.TimerText = DateTime.Now.ToLongTimeString();
        }

        #endregion
    }
}