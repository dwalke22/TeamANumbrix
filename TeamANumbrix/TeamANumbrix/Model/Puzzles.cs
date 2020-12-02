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
        }

        private Puzzle generatePuzzle1()
        {
            const string staticCells = "1|1,8|8,10|29,15|34,18|48,22|52,27|60,46|55,43|58,50|44,64|15,55|39,57|22";
            var puzzleData = staticCells.Split(Comma);

            var staticCellPositions = this.GetStaticCellPositions(puzzleData);

            var puzzle = new Puzzle(staticCells, PuzzleDimensionSize);
            var blankPuzzle = PuzzleCreator.CreatePuzzle(puzzleData);
            var enumerable = blankPuzzle as Cell[] ?? blankPuzzle.ToArray();
            this.handleStaticValueCells(enumerable, staticCellPositions);

            puzzle.AddAll(enumerable.ToList());

            return puzzle;
        }

        private Puzzle generatePuzzle2()
        {
            const string staticCells = "1|1,41|6,58|9,10|15,6|20,14|25,20|30,24|34,27|40,40|46,43|52,55|57";
            var puzzleData = staticCells.Split(Comma);

            var positions = this.GetStaticCellPositions(puzzleData);

            var puzzle = new Puzzle(staticCells, PuzzleDimensionSize);
            var blankPuzzle = PuzzleCreator.CreatePuzzle(puzzleData);
            var enumerable = blankPuzzle as Cell[] ?? blankPuzzle.ToArray();
            this.handleStaticValueCells(enumerable, positions);

            puzzle.AddAll(enumerable.ToList());

            return puzzle;
        }

        private Puzzle generatePuzzle3()
        {
            const string staticCells =
                "1|21,7|41,10|23,14|57,17|19,18|24,19|47,20|54,21|63,22|64,23|59,24|38,64|5,46|1,54|8,50|28,42|27,63|6,59|12,33|17,53|31,37|33,40|36";
            var puzzleData = staticCells.Split(Comma);

            var positions = this.GetStaticCellPositions(puzzleData);

            var puzzle = new Puzzle(staticCells, PuzzleDimensionSize);
            var blankPuzzle = PuzzleCreator.CreatePuzzle(puzzleData);
            var enumerable = blankPuzzle as Cell[] ?? blankPuzzle.ToArray();
            this.handleStaticValueCells(enumerable, positions);

            puzzle.AddAll(enumerable.ToList());

            return puzzle;
        }

        private Puzzle generatePuzzle4()
        {
            const string staticCells = "28|1,29|2,36|4,19|7,1|11,41|20,45|24,53|25,49|29,61|34,20|64";
            var puzzleData = staticCells.Split(Comma);

            var positions = this.GetStaticCellPositions(puzzleData);

            var puzzle = new Puzzle(staticCells, PuzzleDimensionSize);
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

        #endregion
    }
}