using System.Windows;

namespace Project2;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    bool running = false;

    public MainWindow()
    {
        InitializeComponent();
    }

    private void BtnToggleRun_Click(object sender, RoutedEventArgs e)
    {
        running = !running;
        tbStatus.Text = running ? "Running" : "Stopped";
        btnToggleRun.Content = running ? "Stop" : "Run";
    }
}