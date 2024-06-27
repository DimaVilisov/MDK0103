using Avalonia.Controls;
using DynamicData;
using pzz13_33.Data;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace pzz13_33.ViewModels;

public class MainViewModel : ViewModelBase
{
    public static Window MainWindow { get; set; }
    private static MainViewModel _instance;
    public static MainViewModel Instance
    {
        get
        {
            if (_instance == null)
                _instance = new MainViewModel();
            return _instance;
        }
    }
    private ObservableCollection<Tovar> _tovarsList;
    public ObservableCollection<Tovar> TovarsList 
    {
        get => _tovarsList;
        set
        {
            _tovarsList = value;
            OnPropertyChanged(nameof(TovarsList));
        }
    }
    public MainViewModel()
    {
        using DataBase dataBase = new DataBase();
        TovarsList = new ObservableCollection<Tovar>();
        TovarsList.AddRange(dataBase.Tovars.ToList());
    }

    public event PropertyChangedEventHandler PropertyChanged;
    public void OnPropertyChanged([CallerMemberName] string prop = "")
    {
        if (PropertyChanged != null)
            PropertyChanged(this, new PropertyChangedEventArgs(prop));
    }

}
