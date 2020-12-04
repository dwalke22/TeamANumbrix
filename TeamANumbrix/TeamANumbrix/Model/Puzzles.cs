using System.Collections.Generic;
using System.Linq;
using TeamANumbrix.Utility;

namespace TeamANumbrix.Model
{
    /// <summary>
    ///     The Puzzle Class
    /// </summary>
    public class Puzzles
    {
        #region Data members

        /// <summary>
        ///     The size of the puzzle
        /// </summary>
        public const int PuzzleDimensionSize = 8;

        /// <summary>
        ///     The comma
        /// </summary>
        public const string Comma = ",";

        /// <summary>
        ///     The delimiter
        /// </summary>
        public const string Delimiter = "|";

        #endregion

        #region Properties

        /// <summary>
        ///     Gets the AvailablePuzzles.
        /// </summary>
        /// <value>
        ///     The AvailablePuzzles.
        /// </value>
        public IDictionary<string, Puzzle> AvailablePuzzles { get; }

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

        #endregion

        #region Methods

        private void generatePuzzles()
        {
            this.AvailablePuzzles.Add("1", this.generatePuzzle1());
            this.AvailablePuzzles.Add("2", this.generatePuzzle2());
            this.AvailablePuzzles.Add("3", this.generatePuzzle3());
            this.AvailablePuzzles.Add("4", this.generatePuzzle4());
            this.AvailablePuzzles.Add("5", this.generatePuzzle5());
            this.AvailablePuzzles.Add("6", this.generatePuzzle6());
            this.AvailablePuzzles.Add("7", this.generatePuzzle7());
            this.AvailablePuzzles.Add("8", this.generatePuzzle8());
        }

        private Puzzle generatePuzzle1()
        {
            const string staticCells =
                "2|50,3|49,5|47,7|45,8|44,9|52,11|60,13|62,15|64,20|10,22|8,23|1,24|42,26|55,27|56,28|11,29|6,33|15,35|13,39|3,40|40,42|17,44|31,47|34,49|21,51|19,53|29,56|38,61|26,64|37";

            var puzzleData = staticCells.Split(Comma);

            var staticCellPositions = this.GetStaticCellPositions(puzzleData);
            var PuzzleTimer = "1:00";

            var puzzle = new Puzzle("Puzzle 1", staticCells, PuzzleDimensionSize, PuzzleTimer);
            var blankPuzzle = PuzzleCreator.CreatePuzzle(puzzleData);
            var enumerable = blankPuzzle as Cell[] ?? blankPuzzle.ToArray();
            this.handleStaticValueCells(enumerable, staticCellPositions);

            puzzle.AddAll(enumerable.ToList());

            return puzzle;
        }

        private Puzzle generatePuzzle2()
        {
            const string staticCells =
                "2|19,3|18,5|16,6|15,7|14,8|13,9|21,11|27,12|28,13|29,15|31,18|25,19|36,21|34,22|33,23|32,24|11,25|23,30|40,31|1,32|10,33|46,34|45,35|44,36|43,37|42,40|9,41|47,43|61,46|56,48|8,49|48,50|63,52|59,53|58,58|50,60|52,61|53,62|54";

            var puzzleData = staticCells.Split(Comma);
            var PuzzleTimer = "1:00";

            var positions = this.GetStaticCellPositions(puzzleData);

            var puzzle = new Puzzle("Puzzle 2", staticCells, PuzzleDimensionSize, PuzzleTimer);
            var blankPuzzle = PuzzleCreator.CreatePuzzle(puzzleData);
            var enumerable = blankPuzzle as Cell[] ?? blankPuzzle.ToArray();
            this.handleStaticValueCells(enumerable, positions);

            puzzle.AddAll(enumerable.ToList());

            return puzzle;
        }

        private Puzzle generatePuzzle3()
        {
            const string staticCells =
                "1|19,3|21,4|22,5|64,9|18,12|23,18|26,19|29,20|30,26|27,28|31,33|15,35|13,37|33,39|47,41|4,42|5,43|12,45|34,46|39,47|40,49|3,51|7,52|10,53|35,54|38,57|2,58|1,59|8,61|36,62|37";

            var puzzleData = staticCells.Split(Comma);
            var PuzzleTimer = "1:00";

            var positions = this.GetStaticCellPositions(puzzleData);

            var puzzle = new Puzzle("Puzzle 3", staticCells, PuzzleDimensionSize, PuzzleTimer);
            var blankPuzzle = PuzzleCreator.CreatePuzzle(puzzleData);
            var enumerable = blankPuzzle as Cell[] ?? blankPuzzle.ToArray();
            this.handleStaticValueCells(enumerable, positions);

            puzzle.AddAll(enumerable.ToList());

            return puzzle;
        }

        private Puzzle generatePuzzle4()
        {
            const string staticCells =
                "10|1,42|5,1|11,24|20,11|26,59|36,60|37,61|38,62|39,63|40,64|41,56|42,55|43,54|44,53|45,52|46,51|31,50|32,49|33,44|47,28|49,46|53,20|64";

            var puzzleData = staticCells.Split(Comma);
            var PuzzleTimer = "1:00";

            var positions = this.GetStaticCellPositions(puzzleData);

            var puzzle = new Puzzle("Puzzle 4", staticCells, PuzzleDimensionSize, PuzzleTimer);
            var blankPuzzle = PuzzleCreator.CreatePuzzle(puzzleData);
            var enumerable = blankPuzzle as Cell[] ?? blankPuzzle.ToArray();
            this.handleStaticValueCells(enumerable, positions);

            puzzle.AddAll(enumerable.ToList());

            return puzzle;
        }

        private Puzzle generatePuzzle5()
        {
            const string staticCells = "28|1,29|2,36|4,19|7,1|11,41|20,45|24,53|25,49|29,61|34,20|64";

            var puzzleData = staticCells.Split(Comma);
            var PuzzleTimer = "1:00";

            var positions = this.GetStaticCellPositions(puzzleData);

            var puzzle = new Puzzle("Puzzle 5", staticCells, PuzzleDimensionSize, PuzzleTimer);
            var blankPuzzle = PuzzleCreator.CreatePuzzle(puzzleData);
            var enumerable = blankPuzzle as Cell[] ?? blankPuzzle.ToArray();
            this.handleStaticValueCells(enumerable, positions);

            puzzle.AddAll(enumerable.ToList());

            return puzzle;
        }

        private Puzzle generatePuzzle6()
        {
            const string staticCells =
                "1|21,7|41,10|23,14|57,17|19,18|24,19|47,20|54,21|63,22|64,23|59,24|38,64|5,46|1,54|8,50|28,42|27,63|6,59|12,33|17,53|31,37|33,40|36";
            var puzzleData = staticCells.Split(Comma);
            var PuzzleTimer = "1:00";

            var positions = this.GetStaticCellPositions(puzzleData);

            var puzzle = new Puzzle("Puzzle 6", staticCells, PuzzleDimensionSize, PuzzleTimer);
            var blankPuzzle = PuzzleCreator.CreatePuzzle(puzzleData);
            var enumerable = blankPuzzle as Cell[] ?? blankPuzzle.ToArray();
            this.handleStaticValueCells(enumerable, positions);

            puzzle.AddAll(enumerable.ToList());

            return puzzle;
        }

        private Puzzle generatePuzzle7()
        {
            const string staticCells = "1|1,41|6,58|9,10|15,6|20,14|25,20|30,24|34,27|40,40|46,43|52,55|57";

            var puzzleData = staticCells.Split(Comma);
            var PuzzleTimer = "1:00";

            var positions = this.GetStaticCellPositions(puzzleData);

            var puzzle = new Puzzle("Puzzle 7", staticCells, PuzzleDimensionSize, PuzzleTimer);
            var blankPuzzle = PuzzleCreator.CreatePuzzle(puzzleData);
            var enumerable = blankPuzzle as Cell[] ?? blankPuzzle.ToArray();
            this.handleStaticValueCells(enumerable, positions);

            puzzle.AddAll(enumerable.ToList());

            return puzzle;
        }

        private Puzzle generatePuzzle8()
        {
            const string staticCells = "1|1,8|8,10|29,15|34,18|48,22|52,27|60,46|55,43|58,50|44,64|15,55|39,57|22";
            var puzzleData = staticCells.Split(Comma);
            var PuzzleTimer = "1:00";

            var positions = this.GetStaticCellPositions(puzzleData);

            var puzzle = new Puzzle("Puzzle 8", staticCells, PuzzleDimensionSize, PuzzleTimer);
            var blankPuzzle = PuzzleCreator.CreatePuzzle(puzzleData);
            var enumerable = blankPuzzle as Cell[] ?? blankPuzzle.ToArray();
            this.handleStaticValueCells(enumerable, positions);

            puzzle.AddAll(enumerable.ToList());

            return puzzle;
        }

        private void handleStaticValueCells(IEnumerable<Cell> cells, string positions)
        {
            var modifiedPositions = positions.Split(Comma);

            var enumerable = cells as Cell[] ?? cells.ToArray();
            foreach (var t in modifiedPositions)
            {
                foreach (var currentCell in enumerable.ToList())
                {
                    if (currentCell.Position == int.Parse(t))
                    {
                        currentCell.IsValueStatic = false;
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
        public string GetStaticCellPositions(string[] values)
        {
            var positions = string.Empty;
            var listValues = values.ToList();

            for (var i = 0; i < listValues.Count; i++)
            {
                var value = listValues[i].Split(Delimiter);
                positions += value[0];
                if (i != listValues.Count - 1)
                {
                    positions += Comma;
                }
            }

            return positions;
        }

        /// <summary>
        ///     Finds the name of the puzzle by.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>
        ///     Puzzle the puzzle to be found
        /// </returns>
        public Puzzle FindPuzzleByName(string name)
        {
            Puzzle puzzle = null;

            var puzzles = this.AvailablePuzzles.Values.ToList();

            foreach (var currentPuzzle in puzzles.Where(currentPuzzle => currentPuzzle.PuzzleName.Equals(name)))
            {
                puzzle = currentPuzzle;
            }

            return puzzle;
        }

        #endregion
    }
}