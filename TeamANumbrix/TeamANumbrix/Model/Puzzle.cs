using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testPuzzle.Model;

namespace TeamANumbrix.Model
{
    /// <summary>
    /// The grid class
    /// </summary>
    /// <seealso cref="Cell" />
    public class Puzzle : ICollection<Cell>
    {
        /// <summary>
        /// Gets the cells.
        /// </summary>
        /// <value>
        /// The cells.
        /// </value>
        private IList<Cell> Cells { get; }

        /// <summary>
        /// Gets the number of elements contained in the <see cref="T:System.Collections.Generic.ICollection`1"></see>.
        /// </summary>
        public int Count => this.Cells.Count;

        /// <summary>
        /// Gets a value indicating whether the <see cref="T:System.Collections.Generic.ICollection`1"></see> is read-only.
        /// </summary>
        public bool IsReadOnly => true;

        public Puzzle()
        {
            this.Cells = new Collection<Cell>();
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>
        /// An enumerator that can be used to iterate through the collection.
        /// </returns>
        public IEnumerator<Cell> GetEnumerator()
        {
            return this.Cells.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        /// <summary>
        /// Adds the specified cell.
        /// </summary>
        /// <param name="cell">The cell.</param>
        /// <exception cref="NullReferenceException">Cell cannot be null</exception>
        public void Add(Cell cell)
        {
            if (cell == null)
            {
                throw new NullReferenceException("Cell cannot be null");
            }
        }

        /// <summary>
        /// Removes all items from the <see cref="T:System.Collections.Generic.ICollection`1"></see>.
        /// </summary>
        public void Clear()
        {
            this.Cells.Clear();
        }

        /// <summary>
        /// Determines whether this instance contains the object.
        /// </summary>
        /// <param name="cell">The cell.</param>
        /// <returns>
        ///   <c>true</c> if [contains] [the specified cell]; otherwise, <c>false</c>.
        /// </returns>
        /// <exception cref="NullReferenceException">Item cannot be null</exception>
        public bool Contains(Cell cell)
        {
            var containsCell = false;
            if (cell == null)
            {
                throw new NullReferenceException("Cell cannot be null");
            }

            if (this.Cells.Contains(cell))
            {
                containsCell = true;
            }

            return containsCell;
        }

        /// <summary>
        /// Copies the elements of the <see cref="T:System.Collections.Generic.ICollection`1"></see> to an <see cref="T:System.Array"></see>, starting at a particular <see cref="T:System.Array"></see> index.
        /// </summary>
        /// <param name="array">The one-dimensional <see cref="T:System.Array"></see> that is the destination of the elements copied from <see cref="T:System.Collections.Generic.ICollection`1"></see>. The <see cref="T:System.Array"></see> must have zero-based indexing.</param>
        /// <param name="arrayIndex">The zero-based index in array at which copying begins.</param>
        /// <exception cref="ArgumentException">Index cannot be negative</exception>
        public void CopyTo(Cell[] array, int arrayIndex)
        {
            if (arrayIndex < 0)
            {
                throw new ArgumentException("Index cannot be negative");
            }

            this.Cells.CopyTo(array, arrayIndex);
        }

        /// <summary>
        /// Removes the specified cell.
        /// </summary>
        /// <param name="cell">The cell.</param>
        /// <returns></returns>
        /// <exception cref="NullReferenceException">Statistic cannot be null</exception>
        public bool Remove(Cell cell)
        {
            if (cell == null)
            {
                throw new NullReferenceException("Cell cannot be null");
            }

            return this.Cells.Remove(cell);
        }

        /// <summary>
        /// Adds all.
        /// </summary>
        /// <param name="cells">The cells.</param>
        /// <exception cref="NullReferenceException">Cells cannot be null</exception>
        public void AddAll(IEnumerable<Cell> cells)
        {
            if (cells == null)
            {
                throw new NullReferenceException("Cells cannot be null");
            }

            foreach (var currentCell in cells)
            {
                this.Cells.Add(currentCell);
            }
        }

        /// <summary>
        /// Removes all.
        /// </summary>
        /// <param name="cells">The cells.</param>
        /// <exception cref="NullReferenceException">Cells cannot be null</exception>
        public void RemoveAll(IEnumerable<Cell> cells)
        {
            if (cells == null)
            {
                throw new NullReferenceException("Cells cannot be null");
            }

            foreach (var currentCell in cells)
            {
                this.Cells.Remove(currentCell);
            }
        }

    }
}