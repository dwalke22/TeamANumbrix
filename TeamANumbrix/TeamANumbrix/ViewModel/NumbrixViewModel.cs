using TeamANumbrix.Model;

namespace TeamANumbrix.ViewModel
{
    /// <summary>
    ///     The NumbrixViewModel class
    /// </summary>
    public class NumbrixViewModel
    {
        private Puzzles puzzles;

        /// <summary>
        ///     The collection of puzzles
        /// </summary>
        public Puzzles Puzzles
        {
            get { return puzzles; }
            set { puzzles = value; }
        }

        /// <summary>
        ///     Instantiates a new View Model object
        /// </summary>
        public NumbrixViewModel()
        {
            this.puzzles = new Puzzles();
        }
    }
}