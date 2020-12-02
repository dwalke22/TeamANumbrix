using System.Collections.ObjectModel;
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
        private LeaderBoard leaderBoard;

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

        private ObservableCollection<HighScore> highScores;

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
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}