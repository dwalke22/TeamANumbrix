﻿using System.Collections.Generic;
using System.Linq;
using TeamANumbrix.Model;

namespace TeamANumbrix.Utility
{
    /// <summary>
    ///     The Puzzle solver class
    /// </summary>
    public class PuzzleSolver
    {
        #region Properties

        /// <summary>
        ///     The Puzzle
        /// </summary>
        public Puzzle Puzzle { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        ///     Instantiates a new Puzzle solver object
        /// </summary>
        /// <param name="puzzle"></param>
        public PuzzleSolver(Puzzle puzzle)
        {
            this.Puzzle = puzzle;
        }

        #endregion

        #region Methods

        /// <summary>
        ///     Determines if the puzzle has been solved
        /// </summary>
        /// <returns>
        ///     Returns true if solved, false otherwise
        /// </returns>
        public bool SolvePuzzle()
        {
            var isSolved = true;
            var cells = this.Puzzle.ToList();
            var counterSize = this.Puzzle.DimensionSize * this.Puzzle.DimensionSize;
            var checkWinCounter = 0;

            var firstPosition = this.findPositionOne(cells);

            for (var i = 0; i < counterSize; i++)
            {
                var nextPosition = this.findNextPosition(firstPosition);
                if (nextPosition == 0)
                {
                    return false;
                }

                firstPosition = cells[nextPosition - 1];
                checkWinCounter++;
                if (checkWinCounter == counterSize - 1)
                {
                    return true;
                }
            }

            return isSolved;
        }

        private Cell findPositionOne(IEnumerable<Cell> cells)
        {
            Cell positionOne = null;
            foreach (var currentCell in cells)
            {
                if (currentCell.Value == 1)
                {
                    positionOne = currentCell;
                }
            }

            return positionOne;
        }

        private int findNextPosition(Cell currentCell)
        {
            var nextPosition = 0;
            var cellPosition = currentCell.Position;

            if (currentCell.HasCellToNorth)
            {
                if (this.checkNorthValue(currentCell))
                {
                    nextPosition = cellPosition - this.Puzzle.DimensionSize;
                }
            }

            if (currentCell.HasCellToSouth)
            {
                if (this.checkSouthValue(currentCell))
                {
                    nextPosition = cellPosition + this.Puzzle.DimensionSize;
                }
            }

            if (currentCell.HasCellToEast)
            {
                if (this.checkEastValue(currentCell))
                {
                    nextPosition = cellPosition + 1;
                }
            }

            if (currentCell.HasCellToWest)
            {
                if (this.checkWestValue(currentCell))
                {
                    nextPosition = cellPosition - 1;
                }
            }

            return nextPosition;
        }

        private bool checkNorthValue(Cell cell)
        {
            var isNextPositionNorth = false;

            var currentPosition = cell.Position;
            var northPositionIndex = currentPosition - this.Puzzle.DimensionSize - 1;

            var northCell = this.Puzzle.IndexedCells[northPositionIndex];

            if (northCell.Value == cell.Value + 1)
            {
                isNextPositionNorth = true;
            }

            return isNextPositionNorth;
        }

        private bool checkSouthValue(Cell cell)
        {
            var isNextPositionSouth = false;

            var currentPosition = cell.Position;
            var southPositionIndex = currentPosition + this.Puzzle.DimensionSize - 1;

            var southCell = this.Puzzle.IndexedCells[southPositionIndex];

            if (southCell.Value == cell.Value + 1)
            {
                isNextPositionSouth = true;
            }

            return isNextPositionSouth;
        }

        private bool checkEastValue(Cell cell)
        {
            var isNextPositionEast = false;

            var currentPosition = cell.Position;
            var eastPositionIndex = currentPosition;

            var eastCell = this.Puzzle.IndexedCells[eastPositionIndex];

            if (eastCell.Value == cell.Value + 1)
            {
                isNextPositionEast = true;
            }

            return isNextPositionEast;
        }

        private bool checkWestValue(Cell cell)
        {
            var isNextPositionWest = false;

            var currentPosition = cell.Position;
            var westPositionIndex = currentPosition - 1;

            var westCell = this.Puzzle.IndexedCells[westPositionIndex - 1];

            if (westCell.Value == cell.Value + 1)
            {
                isNextPositionWest = true;
            }

            return isNextPositionWest;
        }

        #endregion
    }
}