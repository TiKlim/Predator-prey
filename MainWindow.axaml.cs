using Avalonia.Controls;

namespace PredatorPrey2
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            getStarted.Click += GetStarted_Click;
        }

        private void GetStarted_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            mainBorder.IsVisible = false;
        } 
    }
}