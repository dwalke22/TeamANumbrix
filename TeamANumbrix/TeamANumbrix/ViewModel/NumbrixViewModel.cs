using System.ComponentModel;
using System.Runtime.CompilerServices;
using TeamANumbrix.Annotations;
using TeamANumbrix.Model;

namespace TeamANumbrix.ViewModel
{
    /// <summary>
    ///     The NumbrixViewModel class
    /// </summary>
    public class NumbrixViewModel : INotifyPropertyChanged
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

        private Puzzle selectedPuzzle;

        public Puzzle SelectedPuzzle
        {
            get { return selectedPuzzle; }
            set
            {
                selectedPuzzle = value; 
                this.OnPropertyChanged();
            }
        }


        /// <summary>
        ///     Instantiates a new View Model object
        /// </summary>
        public NumbrixViewModel()
        {
            this.puzzles = new Puzzles();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}