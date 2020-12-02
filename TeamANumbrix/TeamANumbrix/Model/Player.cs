using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamANumbrix.Model
{
    public class Player
    {
        /// <summary>
        /// Gets or sets the current puzzle.
        /// </summary>
        /// <value>
        /// The current puzzle.
        /// </value>
        public Puzzle CurrentPuzzle { get; set; }

        /// <summary>
        /// Gets or sets the high scores.
        /// </summary>
        /// <value>
        /// The high scores.
        /// </value>
        public LeaderBoard LeaderBoard { get; set; }

        public Player(Puzzle current, LeaderBoard leaderBoard)
        {
            this.CurrentPuzzle = current;
            this.LeaderBoard = leaderBoard;
        }


    }
}
