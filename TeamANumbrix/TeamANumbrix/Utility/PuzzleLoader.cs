using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Storage;
using TeamANumbrix.Model;

namespace TeamANumbrix.Utility
{
    /// <summary>
    ///  The Puzzle Loader class
    /// </summary>
    public class PuzzleLoader
    {
        #region Data members

        /// <summary>
        ///     The file name
        /// </summary>
        public const string FileName = "puzzleInput.bin";

        /// <summary>
        ///     The puzzle dimension size
        /// </summary>
        public const int PuzzleDimensionSize = 8;

        #endregion

        #region Properties

        /// <summary>
        ///     Gets or sets the AvailablePuzzles.
        /// </summary>
        /// <value>
        ///     The AvailablePuzzles.
        /// </value>
        public Dictionary<string, Puzzle> Puzzles { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        ///     Instanciates a new PuzzleLoader object
        /// </summary>
        public PuzzleLoader()
        {
            this.Puzzles = new Dictionary<string, Puzzle>();
        }

        #endregion

        #region Methods
        /// <summary>
        ///     Loads and reads the selected puzzle file
        /// </summary>
        public async void LoadAndReadFile()
        {
            var theFolder = ApplicationData.Current.LocalFolder;
            var theFile = await theFolder.GetFileAsync(FileName);
            if (theFile == null)
            {
                throw new ArgumentNullException(nameof(theFile));
            }

            this.processFile(theFile);
        }

        private async void processFile(StorageFile selectedFile)
        {
            var fileToRead = await selectedFile.OpenAsync(FileAccessMode.Read);
            if (fileToRead == null)
            {
                throw new ArgumentNullException(nameof(fileToRead));
            }

            using (var streamReader = new StreamReader(fileToRead.AsStream()))
            {
                while (!streamReader.EndOfStream)
                {
                    var line = await streamReader.ReadLineAsync();

                    try
                    {
                        //this.createFirstPuzzle(stats);
                    }
                    catch (Exception e)
                    {
                        Console.Write(e.Message);
                    }
                }
            }
        }

        /// <summary>
        ///     Creates the first puzzle of the application
        /// </summary>
        /// <returns>
        ///     Returns the first puzzle object
        /// </returns>
        public static Puzzle CreateFirstPuzzle()
        {
            var puzzle1Txt = "1|1,8|8,10|29,15|34,18|48,22|52,27|60,46|55,43|58,50|44,64|15,55|39,57|22";
            var puzzleData = puzzle1Txt.Split(',');

            var positions = GetPositions(puzzleData);

            var puzzle = new Puzzle(PuzzleDimensionSize);
            var blankPuzzle = PuzzleCreator.CreatePuzzle(puzzleData);
            var enumerable = blankPuzzle as Cell[] ?? blankPuzzle.ToArray();
            handleModifiables(enumerable, positions);

            puzzle.AddAll(enumerable.ToList());

            return puzzle;
        }

        public static Puzzle CreateSecondPuzzle()
        {
            var puzzle = new Puzzle(2, PuzzleDimensionSize);

            return puzzle;
        }

        private static void handleModifiables(IEnumerable<Cell> cells, string positions)
        {
            var modifiedPositions = positions.Split(",");

            var enumerable = cells as Cell[] ?? cells.ToArray();
            foreach (var t in modifiedPositions)
            {
                foreach (var currentCell in enumerable.ToList())
                {
                    if (currentCell.Position == int.Parse(t))
                    {
                        currentCell.IsChangeable = false;
                    }
                }
            }
        }

        /// <summary>
        ///     Gets the positions of the unmodifiable cells in the puzzle
        /// </summary>
        /// <param name="values"></param>
        /// <returns>
        ///     The positions of the unmodifiable cells in the puzzle
        /// </returns>
        public static string GetPositions(string[] values)
        {
            var positions = string.Empty;
            var listValues = values.ToList();

            for (var i = 0; i < listValues.Count; i++)
            {
                var value = listValues[i].Split("|");
                positions += value[0];
                if (i != listValues.Count - 1)
                {
                    positions += ",";
                }
            }

            return positions;
        }

        #endregion
    }
}