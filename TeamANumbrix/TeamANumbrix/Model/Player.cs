namespace TeamANumbrix.Model
{
    /// <summary>
    ///     The Player Class
    /// </summary>
    public class Player
    {
        #region Properties

        /// <summary>
        ///     Gets or sets the currentPuzzle puzzle.
        /// </summary>
        /// <value>
        ///     The currentPuzzle puzzle.
        /// </value>
        public Puzzle CurrentPuzzle { get; set; }

        /// <summary>
        ///     Gets or sets the high scores.
        /// </summary>
        /// <value>
        ///     The high scores.
        /// </value>
        public LeaderBoard LeaderBoard { get; set; }

        /// <summary>
        ///     Gets or sets the name of the player.
        /// </summary>
        /// <value>
        ///     The name of the player.
        /// </value>
        public string PlayerName { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="Player" /> class.
        /// </summary>
        public Player()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Player" /> class.
        /// </summary>
        /// <param name="currentPuzzle">The currentPuzzle.</param>
        public Player(Puzzle currentPuzzle)
        {
            this.CurrentPuzzle = currentPuzzle;
            this.PlayerName = "Player";
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Player" /> class.
        /// </summary>
        /// <param name="playerName">Name of the player.</param>
        /// <param name="currentPuzzle">The currentPuzzle.</param>
        public Player(string playerName, Puzzle currentPuzzle)
        {
            this.CurrentPuzzle = currentPuzzle;
            this.PlayerName = playerName;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Player" /> class.
        /// </summary>
        /// <param name="playerName">Name of the player.</param>
        /// <param name="currentPuzzle">The currentPuzzle.</param>
        /// <param name="leaderBoard">The leader board.</param>
        public Player(string playerName, Puzzle currentPuzzle, LeaderBoard leaderBoard)
        {
            this.PlayerName = playerName;
            this.CurrentPuzzle = currentPuzzle;
            this.LeaderBoard = leaderBoard;
        }

        #endregion
    }
}