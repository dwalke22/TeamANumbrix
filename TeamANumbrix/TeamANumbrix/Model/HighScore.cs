using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TeamANumbrix.Model
{
    public class HighScore
    {
        public string PlayerName { get; set; }

        public Timer TimeRecord { get; set; }

        public int PuzzleNumber { get; set; }

        public HighScore(string playerName, Timer timeRecord, int puzzleNumber)
        {
            this.PlayerName = playerName;
            this.TimeRecord = timeRecord;
            this.PuzzleNumber = puzzleNumber;
        }
    }
}
