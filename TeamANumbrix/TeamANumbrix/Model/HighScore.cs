using System.Threading;

namespace TeamANumbrix.Model
{
    /// <summary>
    /// The HighScore Class
    /// </summary>
    public class HighScore
    {
        #region Properties

        /// <summary>
        ///     Gets or sets the name of the player.
        /// </summary>
        /// <value>
        ///     The name of the player.
        /// </value>
        public string PlayerName { get; set; }

        /// <summary>
        ///     Gets or sets the time record.
        /// </summary>
        /// <value>
        ///     The time record.
        /// </value>
        public string TimeRecord { get; set; }

        /// <summary>
        ///     Gets or sets the puzzle number.
        /// </summary>
        /// <value>
        ///     The puzzle number.
        /// </value>
        public int PuzzleNumber { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="HighScore"/> class.
        /// </summary>
        public HighScore()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="HighScore" /> class.
        /// </summary>
        /// <param name="playerName">Name of the player.</param>
        /// <param name="timeRecord">The time record.</param>
        /// <param name="puzzleNumber">The puzzle number.</param>
        public HighScore(string playerName, string timeRecord, int puzzleNumber)
        {
            this.PlayerName = playerName;
            this.TimeRecord = timeRecord;
            this.PuzzleNumber = puzzleNumber;
        }

        #endregion
    }
}