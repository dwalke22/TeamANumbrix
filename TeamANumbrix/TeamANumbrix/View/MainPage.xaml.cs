using System;
using System.Collections.Generic;
using System.Linq;
using Windows.Foundation;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml.Controls;
using TeamANumbrix.Model;
using TeamANumbrix.Utility;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace TeamANumbrix.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage
    {
        public const int ApplicationHeight = 750;

        public const int ApplicationWidth = 600;

        public const string Comma = ",";

        public const int PuzzleDimensionSize = 8;

        /// <summary>
        /// Gets or sets the puzzle.
        /// </summary>
        /// <value>
        /// The puzzle.
        /// </value>
        public Puzzle Puzzle { get; set; }

        public MainPage()
        {
            this.Puzzle = new Puzzle(PuzzleDimensionSize);
            this.handlePuzzleSetup();
            this.InitializeComponent();
            ApplicationView.PreferredLaunchViewSize = new Size { Width = ApplicationWidth, Height = ApplicationHeight };
            ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.PreferredLaunchViewSize;
            ApplicationView.GetForCurrentView().SetPreferredMinSize(new Size(ApplicationWidth, ApplicationHeight));
        }

        private void handlePuzzleSetup()
        {
            var puzzle1 = PuzzleLoader.createFirstPuzzle();
            this.Puzzle = puzzle1;
        }

        private void handleChangeableTextBoxes()
        {
            List<TextBox> textboxes = new List<TextBox>();
            textboxes.Add(this.cell0);
        }

        private void Button_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            Puzzle puzzle = PuzzleLoader.createFirstPuzzle();

            var summary = string.Empty;

            var checkWin = new PuzzleSolver(puzzle);
            var isWon = checkWin.SolvePuzzle();
            summary += isWon;
            summary += Environment.NewLine;

            foreach (var currentCell in puzzle)
            {
                summary += currentCell.ToString();
                summary += Environment.NewLine;
            }

            this.textBlock.Text = summary;
        }

        private bool handleSolvePuzzle()
        {
            var cellValueData = this.gatherCellData().Split(",");

            var cells = this.updateCellValues(cellValueData);

            var puzzle = new Puzzle(PuzzleDimensionSize);
            puzzle.AddAll(cells);

            var sortedPuzzle = PuzzleCreator.orderPuzzle(puzzle);
            var solver = new PuzzleSolver(sortedPuzzle);
            var isSolved = solver.SolvePuzzle();

            return isSolved;

        }

        private IEnumerable<Cell> updateCellValues(IReadOnlyList<string> values)
        {
            var maxRange = PuzzleDimensionSize * PuzzleDimensionSize;

            var puzzle = PuzzleCreator.CreateBlankPuzzle();
            var sortedPuzzle = PuzzleCreator.orderPuzzle(puzzle);
            var cells = sortedPuzzle.ToList();

            for (var i = 0; i < maxRange; i++)
            {
                cells[i].Value = int.Parse(values[i]);
            }

            return cells;
        }

        private void handleModifiableCells()
        {

        }

        public string getPositions(string[] values)
        {
            var positions = string.Empty;

            foreach (var currentValue in values)
            {
                positions += currentValue[0];
                positions += ",";

            }

            return positions;
        }


        private string gatherCellData()
        {
            var cellSummary = string.Empty;

            cellSummary += this.cell0.Text;
            cellSummary += Comma;
            cellSummary += this.cell1.Text;
            cellSummary += Comma;
            cellSummary += this.cell2.Text;
            cellSummary += Comma;
            cellSummary += this.cell3.Text;
            cellSummary += Comma;
            cellSummary += this.cell4.Text;
            cellSummary += Comma;
            cellSummary += this.cell5.Text;
            cellSummary += Comma;
            cellSummary += this.cell6.Text;
            cellSummary += Comma;
            cellSummary += this.cell7.Text;
            cellSummary += Comma;
            cellSummary += this.cell8.Text;
            cellSummary += Comma;
            cellSummary += this.cell9.Text;
            cellSummary += Comma;
            cellSummary += this.cell10.Text;
            cellSummary += Comma;
            cellSummary += this.cell11.Text;
            cellSummary += Comma;
            cellSummary += this.cell12.Text;
            cellSummary += Comma;
            cellSummary += this.cell13.Text;
            cellSummary += Comma;
            cellSummary += this.cell14.Text;
            cellSummary += Comma;
            cellSummary += this.cell15.Text;
            cellSummary += Comma;
            cellSummary += this.cell16.Text;
            cellSummary += Comma;
            cellSummary += this.cell17.Text;
            cellSummary += Comma;
            cellSummary += this.cell18.Text;
            cellSummary += Comma;
            cellSummary += this.cell19.Text;
            cellSummary += Comma;
            cellSummary += this.cell20.Text;
            cellSummary += Comma;
            cellSummary += this.cell21.Text;
            cellSummary += Comma;
            cellSummary += this.cell22.Text;
            cellSummary += Comma;
            cellSummary += this.cell23.Text;
            cellSummary += Comma;
            cellSummary += this.cell24.Text;
            cellSummary += Comma;
            cellSummary += this.cell25.Text;
            cellSummary += Comma;
            cellSummary += this.cell26.Text;
            cellSummary += Comma;
            cellSummary += this.cell27.Text;
            cellSummary += Comma;
            cellSummary += this.cell28.Text;
            cellSummary += Comma;
            cellSummary += this.cell29.Text;
            cellSummary += Comma;
            cellSummary += this.cell30.Text;
            cellSummary += Comma;
            cellSummary += this.cell31.Text;
            cellSummary += Comma;
            cellSummary += this.cell32.Text;
            cellSummary += Comma;
            cellSummary += this.cell33.Text;
            cellSummary += Comma;
            cellSummary += this.cell34.Text;
            cellSummary += Comma;
            cellSummary += this.cell35.Text;
            cellSummary += Comma;
            cellSummary += this.cell36.Text;
            cellSummary += Comma;
            cellSummary += this.cell37.Text;
            cellSummary += Comma;
            cellSummary += this.cell38.Text;
            cellSummary += Comma;
            cellSummary += this.cell39.Text;
            cellSummary += Comma;
            cellSummary += this.cell40.Text;
            cellSummary += Comma;
            cellSummary += this.cell41.Text;
            cellSummary += Comma;
            cellSummary += this.cell42.Text;
            cellSummary += Comma;
            cellSummary += this.cell43.Text;
            cellSummary += Comma;
            cellSummary += this.cell44.Text;
            cellSummary += Comma;
            cellSummary += this.cell45.Text;
            cellSummary += Comma;
            cellSummary += this.cell46.Text;
            cellSummary += Comma;
            cellSummary += this.cell47.Text;
            cellSummary += Comma;
            cellSummary += this.cell48.Text;
            cellSummary += Comma;
            cellSummary += this.cell49.Text;
            cellSummary += Comma;
            cellSummary += this.cell50.Text;
            cellSummary += Comma;
            cellSummary += this.cell51.Text;
            cellSummary += Comma;
            cellSummary += this.cell52.Text;
            cellSummary += Comma;
            cellSummary += this.cell53.Text;
            cellSummary += Comma;
            cellSummary += this.cell54.Text;
            cellSummary += Comma;
            cellSummary += this.cell55.Text;
            cellSummary += Comma;
            cellSummary += this.cell56.Text;
            cellSummary += Comma;
            cellSummary += this.cell57.Text;
            cellSummary += Comma;
            cellSummary += this.cell58.Text;
            cellSummary += Comma;
            cellSummary += this.cell59.Text;
            cellSummary += Comma;
            cellSummary += this.cell60.Text;
            cellSummary += Comma;
            cellSummary += this.cell61.Text;
            cellSummary += Comma;
            cellSummary += this.cell62.Text;
            cellSummary += Comma;
            cellSummary += this.cell63.Text;
            
            return cellSummary;
        }

        private void SolvePuzzleButton_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            this.checkResultsTextBox.Text = this.handleSolvePuzzle().ToString();
        }
    }
}
