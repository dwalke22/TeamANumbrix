using System.Collections.Generic;
using System.Linq;
using TeamANumbrix.Model;

namespace TeamANumbrix.Utility
{
    /// <summary>
    ///     The Puzzle Creator class
    /// </summary>
    public class PuzzleCreator
    {
        #region Data members

        /// <summary>
        ///     The size of the puzzle
        /// </summary>
        public const int PuzzleDimensionSize = 8;

        #endregion

        #region Methods

        /// <summary>
        ///     Creates a puzzle
        /// </summary>
        /// <param name="stats"></param>
        /// <returns></returns>
        public static IEnumerable<Cell> CreatePuzzle(IReadOnlyList<string> stats)
        {
            var puzzle = CreateBlankPuzzle();
            var sortedPuzzle = OrderPuzzle(puzzle);
            var sortedList = sortedPuzzle.ToList();

            var modifiedPuzzle = setUnmodifiableCells(stats, sortedList);

            return modifiedPuzzle;
        }

        private static Puzzle setUnmodifiableCells(IEnumerable<string> stats, IList<Cell> cells)
        {
            foreach (var unmodifiableCell in stats)
            {
                var cellData = unmodifiableCell.Split('|');

                var position = int.Parse(cellData[0]);
                var value = int.Parse(cellData[1]);

                cells[position - 1].Value = value;
            }

            var puzzle = new Puzzle(PuzzleDimensionSize);
            puzzle.AddAll(cells);
            var orderedPuzzle = OrderPuzzle(puzzle);

            return orderedPuzzle;
        }

        /// <summary>
        ///     Creates the blank puzzle based on the PuzzleDimensionSize public constant;
        /// </summary>
        /// <returns>
        ///     A blank puzzle
        /// </returns>
        public static Puzzle CreateBlankPuzzle()
        {
            var puzzle = new Puzzle(PuzzleDimensionSize);

            var cornerCells = createCornerCells();
            var northEdgeCells = createNorthEdgeCells();
            var southEdgeCells = createSouthEdgeCells();
            var eastEdgeCells = createEastEdgeCells();
            var westEdgeCells = createWestEdgeCells();
            var middleCells = createMiddleCells();

            puzzle.AddAll(cornerCells);
            puzzle.AddAll(northEdgeCells);
            puzzle.AddAll(southEdgeCells);
            puzzle.AddAll(eastEdgeCells);
            puzzle.AddAll(westEdgeCells);
            puzzle.AddAll(middleCells);

            OrderPuzzle(puzzle);

            return puzzle;
        }

        /// <summary>
        ///     Orders the puzzle
        /// </summary>
        /// <param name="puzzle"></param>
        /// <returns>
        ///     Returns the created puzzle
        /// </returns>
        public static Puzzle OrderPuzzle(Puzzle puzzle)
        {
            var sortedPuzzle = new Puzzle(PuzzleDimensionSize);

            var puzzleList = puzzle.ToList();
            var comparer = new LambdaComparer<Cell>((x, y) => x.Position - y.Position);
            puzzleList.Sort(comparer);

            sortedPuzzle.AddAll(puzzleList);

            return sortedPuzzle;
        }

        private static IEnumerable<Cell> createCornerCells()
        {
            var cornerCells = new List<Cell>();

            const int topLeftPosition = 1;
            const int topRightPosition = PuzzleDimensionSize;
            const int bottomRightPosition = PuzzleDimensionSize * PuzzleDimensionSize;
            const int bottomLeftPosition = bottomRightPosition - PuzzleDimensionSize + 1;

            var topLeftCell = new Cell(topLeftPosition, 0, false, true, true, false);
            var topRightCell = new Cell(topRightPosition, 0, false, true, false, true);
            var bottomLeftCell = new Cell(bottomLeftPosition, 0, true, false, true, false);
            var bottomRightCell = new Cell(bottomRightPosition, 0, true, false, false, true);

            cornerCells.Add(topLeftCell);
            cornerCells.Add(topRightCell);
            cornerCells.Add(bottomRightCell);
            cornerCells.Add(bottomLeftCell);

            return cornerCells;
        }

        private static IEnumerable<Cell> createNorthEdgeCells()
        {
            var northCells = new List<Cell>();

            const int maxRange = PuzzleDimensionSize - 1;
            const int startingPosition = 2;

            for (var i = startingPosition; i <= maxRange; i++)
            {
                var cell = new Cell(i, 0, false, true, true, true);
                northCells.Add(cell);
            }

            return northCells;
        }

        private static IEnumerable<Cell> createSouthEdgeCells()
        {
            var southCells = new List<Cell>();

            var maxRange = PuzzleDimensionSize * PuzzleDimensionSize - 1;
            var startingPosition = maxRange - (PuzzleDimensionSize - 3);

            for (var i = startingPosition; i <= maxRange; i++)
            {
                var cell = new Cell(i, 0, true, false, true, true);
                southCells.Add(cell);
            }

            return southCells;
        }

        private static IEnumerable<Cell> createEastEdgeCells()
        {
            var eastCells = new List<Cell>();

            const int cellRowSize = PuzzleDimensionSize - 1;
            const int startingMultiplicity = 2;

            for (var i = startingMultiplicity; i <= cellRowSize; i++)
            {
                var currentPosition = PuzzleDimensionSize * i;
                var cell = new Cell(currentPosition, 0, true, true, false, true);
                eastCells.Add(cell);
            }

            return eastCells;
        }

        private static IEnumerable<Cell> createWestEdgeCells()
        {
            var westCells = new List<Cell>();

            const int cellRowSize = PuzzleDimensionSize - 2;
            const int startingMultiplicity = 1;

            for (var i = startingMultiplicity; i <= cellRowSize; i++)
            {
                var currentPosition = PuzzleDimensionSize * i + 1;
                var cell = new Cell(currentPosition, 0, true, true, true, false);
                westCells.Add(cell);
            }

            return westCells;
        }

        private static IEnumerable<Cell> createMiddleCells()
        {
            var middleCells = new List<Cell>();

            const int cellRowSize = PuzzleDimensionSize - 2;

            for (var i = 1; i <= cellRowSize; i++)
            {
                var currentPosition = i * PuzzleDimensionSize + 2;
                var currentMaxRange = currentPosition + cellRowSize;

                for (var j = currentPosition; j < currentMaxRange; j++)
                {
                    var cell = new Cell(currentPosition, 0, true, true, true, true);
                    middleCells.Add(cell);
                    currentPosition++;
                }
            }

            return middleCells;
        }

        #endregion
    }
}