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
        ///     Instantiates a new PuzzleLoader object
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

        #endregion
    }
}