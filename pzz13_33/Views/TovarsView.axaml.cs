using Avalonia.Controls;
using Avalonia.Interactivity;
using pzz13_33.Data;
using pzz13_33.ViewModels;
using System;

namespace pzz13_33.Views
{
    public partial class TovarsView : UserControl
    {
        public TovarsView()
        {
            InitializeComponent();
            ButtonAdd.Click += ButtonAdd_Click;
            ButtonDelete.Click += ButtonDelete_Click;
            listBox.ItemsSource = MainViewModel.Instance.TovarsList;

        }

        private void ButtonDelete_Click(object? sender, RoutedEventArgs e)
        {
            Tovar tovar = listBox.SelectedItem as Tovar;
            if (tovar != null)
            {
                using (DataBase data = new DataBase())
                {
                    data.Tovars.Remove(tovar);
                    MainViewModel.Instance.TovarsList.Remove(tovar);
                    listBox.ItemsSource = MainViewModel.Instance.TovarsList;
                    data.SaveChanges();
                };
            }
        }

        private void ButtonAdd_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            using (DataBase dataBase = new DataBase())
            {
                string price = TextBoxPrice.Text;
                string name = TextBoxNameTovar.Text;
                string discription = TextBoxDiscription.Text;
                Tovar tovar = new Tovar()
                {
                    Name = name,
                    Price = price,
                    Discription = discription
                };

                dataBase.Tovars.Add(tovar);
                MainViewModel.Instance.TovarsList.Add(tovar);
                listBox.ItemsSource = MainViewModel.Instance.TovarsList;
                dataBase.SaveChanges();

                TextBoxNameTovar.Clear();
                TextBoxPrice.Clear();
                TextBoxDiscription.Clear();
            }
        }
    }
}
