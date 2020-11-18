using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamANumbrix.Model;

namespace TeamANumbrix.Utility
{
    public class PuzzleSolver
    {
        public Puzzle Puzzle { get; set; }

        public PuzzleSolver(Puzzle puzzle)
        {
            this.Puzzle = puzzle;
        }

        public Boolean SolvePuzzle()
        {
            var isSolved = false;
            var cells = this.Puzzle.ToList();
            var counterSize = this.Puzzle.DimensionSize * this.Puzzle.DimensionSize - 1;

            var firstPosition = this.findPositionOne(cells);

            for (var i = 0; i < counterSize; i++)
            {
                var nextPosition = this.findNextPosition(firstPosition);
                firstPosition = cells[nextPosition];

            }

            return isSolved;
        }

        private Cell findPositionOne(List<Cell> cells)
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
            var cellValue = currentCell.Value;
            var cellPosition = currentCell.Position;

            if (currentCell.HasN)
            {
                if (this.checkNorthValue(currentCell))
                {
                    nextPosition = cellPosition - this.Puzzle.DimensionSize;
                }
            }
            if (currentCell.HasS)
            {
                if (this.checkSouthValue(currentCell))
                {
                    nextPosition = cellPosition + this.Puzzle.DimensionSize;
                }
            }
            if (currentCell.HasE)
            {
                if (this.checkEastValue(currentCell))
                {
                    nextPosition = cellPosition + 1;
                }
            }
            if (currentCell.HasW)
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
            var southPositionIndex = currentPosition - this.Puzzle.DimensionSize - 1;

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
            var eastPositionIndex = currentPosition - this.Puzzle.DimensionSize - 1;

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
            var westPositionIndex = currentPosition - this.Puzzle.DimensionSize - 1;

            var westCell = this.Puzzle.IndexedCells[westPositionIndex];

            if (westCell.Value == cell.Value + 1)
            {
                isNextPositionWest = true;
            }

            return isNextPositionWest;
        }
    }
}
