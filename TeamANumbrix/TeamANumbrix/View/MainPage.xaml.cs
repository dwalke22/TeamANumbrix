using System;
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

        public MainPage()
        {
            this.InitializeComponent();
            ApplicationView.PreferredLaunchViewSize = new Size { Width = ApplicationWidth, Height = ApplicationHeight };
            ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.PreferredLaunchViewSize;
            ApplicationView.GetForCurrentView().SetPreferredMinSize(new Size(ApplicationWidth, ApplicationHeight));
        }

        private void Button_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            Puzzle puzzle = PuzzleLoader.createPuzzles();

            var summary = string.Empty;

            foreach (var currentCell in puzzle)
            {
                summary += currentCell.ToString();
                summary += Environment.NewLine;
            }

            this.textBlock.Text = summary;
        }
    }
}
