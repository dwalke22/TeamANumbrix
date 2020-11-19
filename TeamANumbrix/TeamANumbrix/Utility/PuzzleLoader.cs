using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Windows.Storage;
using Windows.Storage.Pickers;
using TeamANumbrix.Model;

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

        /// <summary>
        /// The file name
        /// </summary>
        public const string FileName = "puzzleInput.bin";

        /// <summary>
        /// The puzzle dimension size
        /// </summary>
        public const int PuzzleDimensionSize = 8;

        public PuzzleLoader()
        {
            this.Puzzles = new Dictionary<string, Puzzle>();
        }

        public async void LoadAndReadFile()
        {
            var theFolder = ApplicationData.Current.LocalFolder;
            var theFile = await theFolder.GetFileAsync(FileName);
            var inStream = await theFile.OpenStreamForReadAsync();

            this.processFile(theFile);
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

        public Puzzle createPuzzle(IReadOnlyList<string> stats)
        {
            var cellsformod =
                "1:2,2:2,3:3,4:4,5:5,6:6,7:7,8:8,9:28,10:29,11:30,12:31,13:32,14:33,15:34,16:9,17:27,18:48,19:49,20:50,21:51,22:52,23:35,24:10,25:26,26:47,27:60,28:61,29:62,30:53,31:36,32:11,33:25,34:46,35:59,36:64,37:63,38:54,39:37,40:12,41:24,42:45,43:58,44:57,45:56,46:55,47:38,48:13,49:23,50:44,51:43,52:42,53:41,54:40,55:39,56:14,57:22,58:21,59:20,60:19,61:18,62:17,63:16,64:15";
            var lmeo = cellsformod.Split(',');
            var puzzle = new Puzzle(PuzzleDimensionSize);
            var blankPuzzle = PuzzleCreator.CreatePuzzle(lmeo);
            puzzle.AddAll(blankPuzzle.ToList());

            return puzzle;
        }

        public static Puzzle createPuzzles()
        {
            var cellsformod =
                "1:1,2:2,3:3,4:4,5:5,6:6,7:7,8:8,9:28,10:29,11:30,12:31,13:32,14:33,15:34,16:9,17:27,18:48,19:49,20:50,21:51,22:52,23:35,24:10,25:26,26:47,27:60,28:61,29:62,30:53,31:36,32:11,33:25,34:46,35:59,36:64,37:63,38:54,39:37,40:12,41:24,42:45,43:58,44:57,45:56,46:55,47:38,48:13,49:23,50:44,51:43,52:42,53:41,54:40,55:39,56:14,57:22,58:21,59:20,60:19,61:18,62:17,63:16,64:15";
            var lmeo = cellsformod.Split(',');
            var puzzle = new Puzzle(PuzzleDimensionSize);
            var blankPuzzle = PuzzleCreator.CreatePuzzle(lmeo);
            puzzle.AddAll(blankPuzzle.ToList());

            return puzzle;
        }
    }
}
