using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Windows.Storage;
using Windows.Storage.Pickers;
using testPuzzle.Model;

namespace TeamANumbrix.Utility
{
    public class PuzzleLoader
    {
        /// <summary>
        /// Gets or sets the puzzles.
        /// </summary>
        /// <value>
        /// The puzzles.
        /// </value>
        public Dictionary<string, Puzzle> Puzzles { get; set; }

        public PuzzleLoader()
        {
            this.Puzzles = new Dictionary<string, Puzzle>();
        }

        public void LoadAndReadFile()
        {
            var fileOpenPicker = this.setFileOpenPicker();
            this.openFile(fileOpenPicker);
        }

        private FileOpenPicker setFileOpenPicker()
        {
            var fileOpener = new FileOpenPicker
            {
                ViewMode = PickerViewMode.Thumbnail,
                SuggestedStartLocation = PickerLocationId.DocumentsLibrary
            };

            fileOpener.FileTypeFilter.Add(".csv");
            fileOpener.FileTypeFilter.Add(".txt");

            return fileOpener;
        }

        private async void openFile(FileOpenPicker picker)
        {
            var selectedFile = await picker.PickSingleFileAsync();
            this.processFile(selectedFile);
        }

        private async void processFile(StorageFile selectedFile)
        {
            var fileToRead = await selectedFile.OpenAsync(Windows.Storage.FileAccessMode.Read);
            var file = new FileInfo(selectedFile.Path);

            using (var streamReader = new StreamReader(fileToRead.AsStream()))
            {
                var counter = 0;
                while (!streamReader.EndOfStream)
                {
                    var line = await streamReader.ReadLineAsync();
                    var stats = line.Split(',');

                    counter++;
                    try
                    {
                        this.createPuzzle(stats);
                    }
                    catch (FormatException e)
                    {
                    }
                    catch (Exception)
                    {
                    }
                }
            }
        }

        private Puzzle createPuzzle(IReadOnlyList<string> stats)
        {
            Puzzle grid = new Puzzle();

            return grid;
        }
    }
}
