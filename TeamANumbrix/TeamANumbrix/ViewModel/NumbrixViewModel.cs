using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using TeamANumbrix.Annotations;
using TeamANumbrix.Model;
using TeamANumbrix.Utility;

namespace TeamANumbrix.ViewModel
{
    /// <summary>
    ///     The NumbrixViewModel class
    /// </summary>
    public class NumbrixViewModel : INotifyPropertyChanged
    {
        private LeaderBoard leaderBoard;

        private Puzzles puzzles;

        public RelayCommand SolvePuzzle { get; set; }

        /// <summary>
        ///     The collection of puzzles
        /// </summary>
        public Puzzles Puzzles
        {
            get { return puzzles; }
            set { puzzles = value; }
        }

        private Puzzle selectedPuzzle;

        /// <summary>
        ///     The Selected Puzzle property
        /// </summary>
        public Puzzle SelectedPuzzle
        {
            get { return selectedPuzzle; }
            set
            {
                selectedPuzzle = value; 
                this.OnPropertyChanged();
            }
        }

        private ObservableCollection<HighScore> highScores;

        /// <summary>
        ///     The high score property
        /// </summary>
        public ObservableCollection<HighScore> HighScores
        {
            get { return this.highScores; }
            set
            {
                this.highScores = value;
                this.OnPropertyChanged();
            }
        }


        /// <summary>
        ///     Instantiates a new View Model object
        /// </summary>
        public NumbrixViewModel()
        {
            this.puzzles = new Puzzles();
            this.leaderBoard = new LeaderBoard();
            this.SolvePuzzle = new RelayCommand(solvePuzzle, canSolvePuzzle);
        }

        private bool canSolvePuzzle()
        {
            return true;
        }

        private void solvePuzzle()
        {

        }

        /// <summary>
        ///     The Property changed event
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="propertyName"></param>
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}