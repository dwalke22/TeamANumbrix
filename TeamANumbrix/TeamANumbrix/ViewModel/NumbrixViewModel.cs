using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using TeamANumbrix.Annotations;
using TeamANumbrix.Extension;
using TeamANumbrix.Model;
using TeamANumbrix.Utility;

namespace TeamANumbrix.ViewModel
{
    /// <summary>
    ///     The NumbrixViewModel class
    /// </summary>
    public class NumbrixViewModel : INotifyPropertyChanged
    {
        #region Data members

        private LeaderBoard leaderBoard;

        private Puzzle selectedPuzzle;

        private ObservableCollection<HighScore> highScores;

        #endregion

        #region Properties
        /// <summary>
        ///     Command to solve the puzzle
        /// </summary>
        public RelayCommand SolvePuzzle { get; set; }

        /// <summary>
        ///     The collection of puzzles
        /// </summary>
        public Puzzles Puzzles { get; set; }

        /// <summary>
        ///     The Selected Puzzle property
        /// </summary>
        public Puzzle SelectedPuzzle
        {
            get => this.selectedPuzzle;
            set
            {
                this.selectedPuzzle = value;
                this.OnPropertyChanged();
            }
        }

        /// <summary>
        ///     The high score property
        /// </summary>
        public ObservableCollection<HighScore> HighScores
        {
            get => this.highScores;
            set
            {
                this.highScores = value;
                this.OnPropertyChanged();
            }
        }

        #endregion

        #region Constructors

        /// <summary>
        ///     Instantiates a new View Model object
        /// </summary>
        public NumbrixViewModel()
        {
            this.Puzzles = new Puzzles();
            this.leaderBoard = new LeaderBoard();
            this.highScores = this.leaderBoard.HighScores.ToObservableCollection();
            this.SolvePuzzle = new RelayCommand(this.solvePuzzle, this.canSolvePuzzle);
        }

        #endregion

        #region Methods

        /// <summary>
        ///     The Property changed event
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        private bool canSolvePuzzle()
        {
            return true;
        }

        private void solvePuzzle()
        {
        }

        /// <summary>
        /// </summary>
        /// <param name="propertyName"></param>
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}