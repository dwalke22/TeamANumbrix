using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.Storage;
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
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
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
            var puzzle1txt =
                "1|1,2|16,3|17,4|32,5|33,6|48,7|49,8|64,9|2,10|15,11|18,12|31,13|34,14|47,15|50,16|63,17|3,18|14,19|19,20|30,21|35,22|46,23|51,24|62,25|4,26|13,27|20,28|29,29|36,30|45,31|52,32|61,33|5,34|12,35|21,36|28,37|37,38|44,39|53,40|60,41|6,42|11,43|22,44|27,45|38,46|43,47|54,48|59,49|7,50|10,51|23,52|26,53|39,54|42,55|55,56|58,57|8,58|9,59|24,60|25,61|40,62|41,63|56,64|57";
            var cellsformod =
                "1:1,2:2,3:3,4:4,5:5,6:6,7:7,8:8,9:28,10:29,11:30,12:31,13:32,14:33,15:34,16:9,17:27,18:48,19:49,20:50,21:51,22:52,23:35,24:10,25:26,26:47,27:60,28:61,29:62,30:53,31:36,32:11,33:25,34:46,35:59,36:64,37:63,38:54,39:37,40:12,41:24,42:45,43:58,44:57,45:56,46:55,47:38,48:13,49:23,50:44,51:43,52:42,53:41,54:40,55:39,56:14,57:22,58:21,59:20,60:19,61:18,62:17,63:16,64:15";
            var puzzleData = puzzle1txt.Split(',');
            var puzzle = new Puzzle(PuzzleDimensionSize);
            var blankPuzzle = PuzzleCreator.CreatePuzzle(puzzleData);
            puzzle.AddAll(blankPuzzle.ToList());

            return puzzle;
        }
    }
}
