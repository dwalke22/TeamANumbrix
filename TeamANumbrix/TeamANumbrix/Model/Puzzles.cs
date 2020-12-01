using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace TeamANumbrix.Model
{
    public class Puzzles : ICollection<Puzzle>
    {
        #region Properties

        /// <summary>
        ///     Gets the puzzles.
        /// </summary>
        /// <value>
        ///     The puzzles.
        /// </value>
        private ICollection<Puzzle> puzzles { get; }

        /// <summary>
        ///     Gets the number of elements contained in the <see cref="T:System.Collections.Generic.ICollection`1"></see>.
        /// </summary>
        public int Count => this.puzzles.Count;

        /// <summary>
        ///     Gets a value indicating whether the <see cref="T:System.Collections.Generic.ICollection`1"></see> is read-only.
        /// </summary>
        public bool IsReadOnly => true;

        #endregion

        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="Puzzles" /> class.
        /// </summary>
        public Puzzles()
        {
            this.puzzles = new Collection<Puzzle>();
        }

        #endregion

        #region Methods

        /// <summary>
        ///     Gets the enumerator.
        /// </summary>
        /// <returns></returns>
        public IEnumerator<Puzzle> GetEnumerator()
        {
            return this.puzzles.GetEnumerator();
        }

        /// <summary>
        ///     Gets the enumerator.
        /// </summary>
        /// <returns></returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        /// <summary>
        ///     Adds the specified puzzle.
        /// </summary>
        /// <param name="puzzle">The puzzle.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public void Add(Puzzle puzzle)
        {
            if (puzzle == null)
            {
                throw new ArgumentNullException();
            }

            this.puzzles.Add(puzzle);
        }

        /// <summary>
        ///     Removes all items from the <see cref="T:System.Collections.Generic.ICollection`1"></see>.
        /// </summary>
        public void Clear()
        {
            this.puzzles.Clear();
        }

        /// <summary>
        ///     Determines whether this instance contains the object.
        /// </summary>
        /// <param name="puzzle">The puzzle.</param>
        /// <returns>
        ///     <c>true</c> if [contains] [the specified puzzle]; otherwise, <c>false</c>.
        /// </returns>
        /// <exception cref="NullReferenceException">Cell cannot be null</exception>
        public bool Contains(Puzzle puzzle)
        {
            var containsCell = false;
            if (puzzle == null)
            {
                throw new NullReferenceException("Cell cannot be null");
            }

            if (this.puzzles.Contains(puzzle))
            {
                containsCell = true;
            }

            return containsCell;
        }

        /// <summary>
        ///     Copies the elements of the <see cref="T:System.Collections.Generic.ICollection`1"></see> to an
        ///     <see cref="T:System.Array"></see>, starting at a particular <see cref="T:System.Array"></see> index.
        /// </summary>
        /// <param name="array">
        ///     The one-dimensional <see cref="T:System.Array"></see> that is the destination of the elements
        ///     copied from <see cref="T:System.Collections.Generic.ICollection`1"></see>. The <see cref="T:System.Array"></see>
        ///     must have zero-based indexing.
        /// </param>
        /// <param name="arrayIndex">The zero-based index in array at which copying begins.</param>
        /// <exception cref="ArgumentException">Index cannot be negative</exception>
        public void CopyTo(Puzzle[] array, int arrayIndex)
        {
            if (arrayIndex < 0)
            {
                throw new ArgumentException("Index cannot be negative");
            }

            this.puzzles.CopyTo(array, arrayIndex);
        }

        /// <summary>
        ///     Removes the specified puzzle.
        /// </summary>
        /// <param name="puzzle">The puzzle.</param>
        /// <returns></returns>
        /// <exception cref="NullReferenceException">Cell cannot be null</exception>
        public bool Remove(Puzzle puzzle)
        {
            if (puzzle == null)
            {
                throw new NullReferenceException("Cell cannot be null");
            }

            return this.puzzles.Remove(puzzle);
        }

        #endregion
    }
}