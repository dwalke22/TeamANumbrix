using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamANumbrix.Model
{
    public class Cell : IComparable<Cell>
    {
        /// <summary>
        /// Gets or sets the position.
        /// </summary>
        /// <value>
        /// The position.
        /// </value>
        public int Position { get; set; }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        public int Value { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance has n.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance has n; otherwise, <c>false</c>.
        /// </value>
        public bool HasN { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance has s.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance has s; otherwise, <c>false</c>.
        /// </value>
        public bool HasS { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance has e.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance has e; otherwise, <c>false</c>.
        /// </value>
        public bool HasE { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance has w.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance has w; otherwise, <c>false</c>.
        /// </value>
        public bool HasW { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is changeable.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is changeable; otherwise, <c>false</c>.
        /// </value>
        public bool IsChangeable { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Cell"/> class.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <param name="value">The value.</param>
        /// <param name="hasN">if set to <c>true</c> [has n].</param>
        /// <param name="hasS">if set to <c>true</c> [has s].</param>
        /// <param name="hasE">if set to <c>true</c> [has e].</param>
        /// <param name="hasW">if set to <c>true</c> [has w].</param>
        /// <exception cref="ArgumentException">
        /// position cannot be less than 0
        /// or
        /// value cannot be less than 0
        /// </exception>
        public Cell(int position, int value, bool hasN, bool hasS, bool hasE, bool hasW)
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
            this.HasN = hasN;
            this.HasS = hasS;
            this.HasE = hasE;
            this.HasW = hasW;
            this.IsChangeable = true;
        }

        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return $"Cell :: {this.Position} has value : {this.Value} N: {this.HasN} S: {this.HasS} E: {this.HasE} W: {this.HasW} IsChangeable: {this.isChangeable}";
        }

        /// <summary>
        /// Compares to.
        /// </summary>
        /// <param name="otherCell">The other cell.</param>
        /// <returns></returns>
        public int CompareTo(Cell otherCell)
        {
            return this.Position.CompareTo(otherCell.Position);
        }
    }
}