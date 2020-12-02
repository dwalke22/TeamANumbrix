namespace TeamANumbrix.Model
{
    /// <summary>
    ///     The Player Class
    /// </summary>
    public class Player
    {
        #region Properties

        /// <summary>
        ///     Gets or sets the current puzzle.
        /// </summary>
        /// <value>
        ///     The current puzzle.
        /// </value>
        public Puzzle CurrentPuzzle { get; set; }

        /// <summary>
        ///     Gets or sets the high scores.
        /// </summary>
        /// <value>
        ///     The high scores.
        /// </value>
        public LeaderBoard LeaderBoard { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="Player" /> class.
        /// </summary>
        /// <param name="current">The current.</param>
        /// <param name="leaderBoard">The leader board.</param>
        public Player(Puzzle current, LeaderBoard leaderBoard)
        {
            this.CurrentPuzzle = current;
            this.LeaderBoard = leaderBoard;
        }

        #endregion
    }
}