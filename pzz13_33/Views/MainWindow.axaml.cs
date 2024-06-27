using Avalonia.Controls;
using pzz13_33.ViewModels;

namespace pzz13_33.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        DataContext = new MainViewModel();
        MainViewModel.MainWindow = this;
    }
}
