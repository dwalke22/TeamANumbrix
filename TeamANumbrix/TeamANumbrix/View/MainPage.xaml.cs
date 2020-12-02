﻿using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Windows.Foundation;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using TeamANumbrix.Model;
using TeamANumbrix.Utility;
using TeamANumbrix.ViewModel;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace TeamANumbrix.View
{
    /// <summary>
    ///     An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage
    {
        #region Data members
        /// <summary>
        ///  The default application height
        /// </summary>
        public const int ApplicationHeight = 800;

        /// <summary>
        ///     The default application width
        /// </summary>
        public const int ApplicationWidth = 1000;

        /// <summary>
        ///     The default dimension size for the puzzle
        /// </summary>
        public const int PuzzleDimensionSize = 8;

        #endregion

        #region Properties

        /// <summary>
        ///     Gets or sets the puzzle.
        /// </summary>
        /// <value>
        ///     The puzzle.
        /// </value>
        public Puzzle Puzzle { get; set; }

        /// <summary>
        /// Gets or sets the selected puzzle.
        /// </summary>
        /// <value>
        /// The selected puzzle.
        /// </value>
        public Puzzle SelectedPuzzle { get; set; }

        /// <summary>
        /// Gets or sets the puzzles.
        /// </summary>
        /// <value>
        /// The puzzles.
        /// </value>
        public Puzzles Puzzles { get; set; }

        /// <summary>
        ///     The timer to be used for the stopwatch
        /// </summary>
        public Stopwatch Timer { get; }

        /// <summary>
        ///     The View Model object
        /// </summary>
        public NumbrixViewModel ViewModel { get; set; }

        #endregion

        #region Constructors
        /// <summary>
        ///     Instantiates a new Main Page object
        /// </summary>
        public MainPage()
        {
            this.Puzzle = new Puzzle(PuzzleDimensionSize);
            this.Puzzles = new Puzzles();
            this.Timer = new Stopwatch();
            this.InitializeComponent();
            this.ViewModel = new NumbrixViewModel();
            ApplicationView.PreferredLaunchViewSize = new Size {Width = ApplicationWidth, Height = ApplicationHeight};
            ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.PreferredLaunchViewSize;
            ApplicationView.GetForCurrentView().SetPreferredMinSize(new Size(ApplicationWidth, ApplicationHeight));
            this.loadPuzzle();
        }

        #endregion

        #region Methods

        private void loadPuzzle()
        {
            this.handleModifiableCells();
        }

        private string getTextBoxData()
        {
            var data = string.Empty;

            foreach (var textBox in findVisualChildren<TextBox>(Parent))
            {
                data += textBox.Text;
                if (textBox != this.cell63)
                {
                    data += ",";
                }
            }

            return data;
        }

        private bool handleSolvePuzzle()
        {
            var cellValueData = this.getTextBoxData().Split(",");

            var cells = this.updateCellValues(cellValueData);

            var puzzle = new Puzzle(PuzzleDimensionSize);
            puzzle.AddAll(cells);

            var sortedPuzzle = PuzzleCreator.OrderPuzzle(puzzle);
            var solver = new PuzzleSolver(sortedPuzzle);
            var isSolved = solver.SolvePuzzle();

            return isSolved;
        }

        private IEnumerable<Cell> updateCellValues(IReadOnlyList<string> values)
        {
            var maxRange = PuzzleDimensionSize * PuzzleDimensionSize;
            var checkedValues = values.ToList();

            for (var i = 0; i < checkedValues.Count; i++)
            {
                if (checkedValues[i].Equals(string.Empty))
                {
                    checkedValues[i] = "0";
                }
            }

            var puzzle = PuzzleCreator.CreateBlankPuzzle();
            var sortedPuzzle = PuzzleCreator.OrderPuzzle(puzzle);
            var cells = sortedPuzzle.ToList();

            for (var i = 0; i < maxRange; i++)
            {
                cells[i].Value = int.Parse(checkedValues[i]);
            }

            return cells;
        }

        private void handleModifiableCells()
        {
            foreach (var currentCell in this.Puzzle)
            {
                if (currentCell.IsValueStatic)
                {
                    continue;
                }

                foreach (var textBox in findVisualChildren<TextBox>(Parent))
                {
                    if (textBox.Name.Contains("cell"))
                    {
                        var textBoxPosition = textBox.Name;
                        var cellValue = textBoxPosition.Split("cell");

                        if (int.Parse(cellValue[1]) + 1 != currentCell.Position)
                        {
                            continue;
                        }

                        textBox.Text = currentCell.Value.ToString();
                        textBox.IsReadOnly = true;
                    }
                }
            }
        }

        private void SolvePuzzleButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.handleSolvePuzzle())
            {
                this.checkPuzzleTextBlock.Visibility = Visibility.Visible;
                this.checkPuzzleTextBlock.Text = "Solved!!";
                this.Timer.Stop();
                this.timerTextBlock.Text = this.Timer.Elapsed.ToString();
                this.Timer.Reset();
            }
            else
            {
                this.checkPuzzleTextBlock.Visibility = Visibility.Visible;
                this.checkPuzzleTextBlock.Text = "Incorrect!!";
            }
        }

        private void LoadPuzzleButton_Click(object sender, RoutedEventArgs e)
        {
            var puzzle = (Puzzle) this.puzzlePickerComboBox.SelectionBoxItem;
            this.Puzzle = puzzle;
            this.loadPuzzle();
            this.Timer.Start();
            this.checkPuzzleTextBlock.Visibility = Visibility.Collapsed;
            this.resetDisplayToSelectedPuzzle();
        }

        #endregion

        private void resetButton_Click(object sender, RoutedEventArgs e)
        {
            this.resetDisplayToSelectedPuzzle();
        }

        private static IEnumerable<T> findVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj != null)
            {
                for (var i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    var child = VisualTreeHelper.GetChild(depObj, i);
                    if (child != null && child is T)
                    {
                        yield return (T)child;
                    }

                    foreach (var childOfChild in findVisualChildren<T>(child))
                    {
                        yield return childOfChild;
                    }
                }
            }
        }

        private void resetDisplayToSelectedPuzzle()
        {
            var puzzle = (Puzzle)this.puzzlePickerComboBox.SelectionBoxItem;
            this.Puzzle = puzzle;

            foreach (var currentCell in this.Puzzle)
            {
                foreach (var textBox in findVisualChildren<TextBox>(Parent))
                {
                    if (textBox.Name.Contains("cell"))
                    {
                        var textBoxPosition = textBox.Name;
                        var cellValue = textBoxPosition.Split("cell");

                        if (int.Parse(cellValue[1]) + 1 != currentCell.Position)
                        {
                            continue;
                        }

                        textBox.Text = currentCell.Value.ToString();

                        if (textBox.Text.Equals("0"))
                        {
                            textBox.Text = "";
                        }
                    }
                }
            }
        }
    }
}