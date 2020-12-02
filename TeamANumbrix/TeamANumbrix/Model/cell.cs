using System;

namespace TeamANumbrix.Model
{
    /// <summary>
    ///     The Cell class for the puzzle
    /// </summary>
    public class Cell : IComparable<Cell>
    {
        #region Properties

        /// <summary>
        ///     Gets or sets the position.
        /// </summary>
        /// <value>
        ///     The position.
        /// </value>
        public int Position { get; set; }

        /// <summary>
        ///     Gets or sets the value.
        /// </summary>
        /// <value>
        ///     The value.
        /// </value>
        public int Value { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether this instance has n.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance has n; otherwise, <c>false</c>.
        /// </value>
        public bool HasCellToNorth { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether this instance has s.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance has s; otherwise, <c>false</c>.
        /// </value>
        public bool HasCellToSouth { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether this instance has e.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance has e; otherwise, <c>false</c>.
        /// </value>
        public bool HasCellToEast { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether this instance has w.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance has w; otherwise, <c>false</c>.
        /// </value>
        public bool HasCellToWest { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether this instance is changeable.
        /// </summary>
        /// <value>
        ///     <c>true</c> if this instance is changeable; otherwise, <c>false</c>.
        /// </value>
        public bool IsValueStatic { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="Cell" /> class.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="value">The value.</param>
        /// <param name="hasCellToNorth">if set to <c>true</c> [has n].</param>
        /// <param name="hasCellToSouth">if set to <c>true</c> [has s].</param>
        /// <param name="hasCellToEast">if set to <c>true</c> [has e].</param>
        /// <param name="hasCellToWest">if set to <c>true</c> [has w].</param>
        /// <exception cref="ArgumentException">
        ///     position cannot be less than 0
        ///     or
        ///     value cannot be less than 0
        /// </exception>
        public Cell(int position, int value, bool hasCellToNorth, bool hasCellToSouth, bool hasCellToEast, bool hasCellToWest)
        {
            if (position < 0)
            {
                throw new ArgumentException("position cannot be less than 0");
            }

            if (value < 0)
            {
                throw new ArgumentException("value cannot be less than 0");
            }

            this.Position = position;
            this.Value = value;
            this.HasCellToNorth = hasCellToNorth;
            this.HasCellToSouth = hasCellToSouth;
            this.HasCellToEast = hasCellToEast;
            this.HasCellToWest = hasCellToWest;
            this.IsValueStatic = true;
        }

        #endregion

        #region Methods

        /// <summary>
        ///     Compares to by position.
        /// </summary>
        /// <param name="otherCell">The other cell.</param>
        /// <returns>
        ///     int = 0 if equal, 1 or -1 otherwise
        /// </returns>
        public int CompareTo(Cell otherCell)
        {
            return this.Position.CompareTo(otherCell.Position);
        }

        /// <summary>
        ///     Converts to string.
        /// </summary>
        /// <returns>
        ///     A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return
                $"Cell :: {this.Position} has value : {this.Value} N: {this.HasCellToNorth} S: {this.HasCellToSouth} E: {this.HasCellToEast} W: {this.HasCellToWest} IsValueStatic: {this.IsValueStatic}";
        }

        #endregion
    }
}