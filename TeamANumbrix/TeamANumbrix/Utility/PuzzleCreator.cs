﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testPuzzle.Model;

namespace TeamANumbrix.Utility
{
    public class PuzzleCreator
    {
        /// <summary>
        /// The size of the puzzle
        /// </summary>
        public const int PuzzleDimensionSize = 8;


        public static IEnumerable<Cell> CreatePuzzle(IReadOnlyList<string> stats)
        {
            var puzzleData = new List<Cell>();

            foreach (var unmodifiableCell in stats)
            {
                var cellData = unmodifiableCell.Split(':');

                var position = int.Parse(cellData[0]);
                var value = int.Parse(cellData[1]);

                //var cell = new Cell();
            }

            return puzzleData;
        }

        /// <summary>
        /// Creates the blank puzzle based on the PuzzleDimensionSize public constant;
        /// </summary>
        /// <returns>
        /// A blank puzzle
        /// </returns>
        public static Puzzle CreateBlankPuzzle()
        {
            var puzzle = new Puzzle();

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

            return puzzle;
        }

        private static IEnumerable<Cell> createCornerCells()
        {
            var cornerCells = new List<Cell>();

            var topLeftPosition = 1;
            var topRightPosition = PuzzleDimensionSize;
            var bottomLeftPosition = PuzzleDimensionSize * PuzzleDimensionSize;
            var bottomRightPosition = bottomLeftPosition - PuzzleDimensionSize;

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
                var cell = new Cell(i, 0, false, true, true, true);
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

    }
}