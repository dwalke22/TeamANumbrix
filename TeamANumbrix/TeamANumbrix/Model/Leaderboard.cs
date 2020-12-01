using System;
using System.Collections;
using System.Collections.Generic;

namespace TeamANumbrix.Model
{
    /// <summary>
    /// The LeaderBoard Class
    /// </summary>
    /// <seealso cref="System.Collections.Generic.IList{TeamANumbrix.Model.HighScore}" />
    public class LeaderBoard : IList<HighScore>
    {
        #region Properties

        /// <summary>
        ///     Gets the highscores.
        /// </summary>
        /// <value>
        ///     The highscores.
        /// </value>
        private IList<HighScore> highscores { get; }

        /// <summary>
        ///     Gets the number of elements contained in the <see cref="T:System.Collections.Generic.ICollection`1"></see>.
        /// </summary>
        public int Count => this.highscores.Count;

        /// <summary>
        ///     Gets a value indicating whether the <see cref="T:System.Collections.Generic.ICollection`1"></see> is read-only.
        /// </summary>
        public bool IsReadOnly => false;

        /// <summary>
        ///     Gets or sets the <see cref="HighScore" /> at the specified index.
        /// </summary>
        /// <value>
        ///     The <see cref="HighScore" />.
        /// </value>
        /// <param name="index">The index.</param>
        /// <returns></returns>
        public HighScore this[int index]
        {
            get => this.highscores[index];
            set => this.highscores[index] = value;
        }

        #endregion

        #region Methods

        /// <summary>
        ///     Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>
        ///     An enumerator that can be used to iterate through the collection.
        /// </returns>
        public IEnumerator<HighScore> GetEnumerator()
        {
            return this.highscores.GetEnumerator();
        }

        /// <summary>
        ///     Returns an enumerator that iterates through a collection.
        /// </summary>
        /// <returns>
        ///     An <see cref="T:System.Collections.IEnumerator"></see> object that can be used to iterate through the collection.
        /// </returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        /// <summary>
        ///     Adds the specified high score.
        /// </summary>
        /// <param name="highScore">The high score.</param>
        /// <exception cref="NullReferenceException"></exception>
        public void Add(HighScore highScore)
        {
            if (highScore == null)
            {
                throw new NullReferenceException();
            }

            this.highscores.Add(highScore);
        }

        /// <summary>
        ///     Removes all items from the <see cref="T:System.Collections.Generic.ICollection`1"></see>.
        /// </summary>
        public void Clear()
        {
            this.highscores.Clear();
        }

        /// <summary>
        ///     Determines whether this instance contains the object.
        /// </summary>
        /// <param name="highScore">The object to locate in the <see cref="T:System.Collections.Generic.ICollection`1"></see>.</param>
        /// <returns>
        ///     true if highScore is found in the <see cref="T:System.Collections.Generic.ICollection`1"></see>; otherwise, false.
        /// </returns>
        /// <exception cref="NullReferenceException"></exception>
        public bool Contains(HighScore highScore)
        {
            if (highScore == null)
            {
                throw new NullReferenceException();
            }

            return this.highscores.Contains(highScore);
        }

        public void CopyTo(HighScore[] array, int arrayIndex)
        {
            for (var i = 0; i < this.Count; i++)
            {
                array.SetValue(this.highscores[i], arrayIndex++);
            }
        }

        /// <summary>
        ///     Removes the first occurrence of a specific object from the
        ///     <see cref="T:System.Collections.Generic.ICollection`1"></see>.
        /// </summary>
        /// <param name="highScore">The object to remove from the <see cref="T:System.Collections.Generic.ICollection`1"></see>.</param>
        /// <returns>
        ///     true if highScore was successfully removed from the <see cref="T:System.Collections.Generic.ICollection`1"></see>;
        ///     otherwise, false. This method also returns false if highScore is not found in the original
        ///     <see cref="T:System.Collections.Generic.ICollection`1"></see>.
        /// </returns>
        /// <exception cref="NullReferenceException"></exception>
        public bool Remove(HighScore highScore)
        {
            if (highScore == null)
            {
                throw new NullReferenceException();
            }

            return this.highscores.Contains(highScore) && this.highscores.Remove(highScore);
        }

        /// <summary>
        ///     Inserts the specified index.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <param name="highScore">The high score.</param>
        public void Insert(int index, HighScore highScore)
        {
            if (index >= this.Count || index < 0)
            {
                return;
            }

            for (var i = this.Count - 1; i > index; i--)
            {
                this.highscores[i] = this.highscores[i - 1];
            }

            this.highscores[index] = highScore;
        }

        /// <summary>
        ///     Removes the <see cref="T:System.Collections.Generic.IList`1"></see> highScore at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index of the highScore to remove.</param>
        public void RemoveAt(int index)
        {
            if (index < 0 || index >= this.Count)
            {
                return;
            }

            for (var i = index; i < this.Count - 1; i++)
            {
                this.highscores[i] = this.highscores[i + 1];
            }
        }

        /// <summary>
        ///     Indexes the of.
        /// </summary>
        /// <param name="highScore">The high score.</param>
        /// <returns></returns>
        public int IndexOf(HighScore highScore)
        {
            for (var i = 0; i < this.Count; i++)
            {
                if (this.highscores[i] == highScore)
                {
                    return i;
                }
            }

            return -1;
        }

        public void sortByHighScore()
        {

        }

        #endregion
    }
}