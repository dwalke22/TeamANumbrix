using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using TeamANumbrix.Utility;

namespace TeamANumbrix.Model
{
    public class Puzzles
    {
        #region Properties

        /// <summary>
        ///     Gets the AvailablePuzzles.
        /// </summary>
        /// <value>
        ///     The AvailablePuzzles.
        /// </value>
        public IDictionary<string, Puzzle> AvailablePuzzles { get; }

        /// <summary>
        /// The size of the puzzle
        /// </summary>
        public const int PuzzleDimensionSize = 8;

        #endregion

        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="Puzzles" /> class.
        /// </summary>
        public Puzzles()
        {
            this.AvailablePuzzles = new Dictionary<string, Puzzle>();
            this.generatePuzzles();
        }

        private void generatePuzzles()
        {
            this.AvailablePuzzles.Add("1", this.generatePuzzle1());
        }

        private Puzzle generatePuzzle1()
        {
            var puzzle1Txt = "1|1,8|8,10|29,15|34,18|48,22|52,27|60,46|55,43|58,50|44,64|15,55|39,57|22";
            var puzzleData = puzzle1Txt.Split(',');

            var positions = GetPositions(puzzleData);

            var puzzle = new Puzzle(PuzzleDimensionSize);
            var blankPuzzle = PuzzleCreator.CreatePuzzle(puzzleData);
            var enumerable = blankPuzzle as Cell[] ?? blankPuzzle.ToArray();
            handleModifiables(enumerable, positions);

            puzzle.AddAll(enumerable.ToList());

            return puzzle;
        }

        private static void handleModifiables(IEnumerable<Cell> cells, string positions)
        {
            var modifiedPositions = positions.Split(",");

            var enumerable = cells as Cell[] ?? cells.ToArray();
            foreach (var t in modifiedPositions)
            {
                foreach (var currentCell in enumerable.ToList())
                {
                    if (currentCell.Position == int.Parse(t))
                    {
                        currentCell.IsChangeable = false;
                    }
                }
            }
        }

        /// <summary>
        ///     Gets the positions of the unmodifiable cells in the puzzle
        /// </summary>
        /// <param name="values"></param>
        /// <returns>
        ///     The positions of the unmodifiable cells in the puzzle
        /// </returns>
        public static string GetPositions(string[] values)
        {
            var positions = string.Empty;
            var listValues = values.ToList();

            for (var i = 0; i < listValues.Count; i++)
            {
                var value = listValues[i].Split("|");
                positions += value[0];
                if (i != listValues.Count - 1)
                {
                    positions += ",";
                }
            }

            return positions;
        }

        #endregion
    }

}