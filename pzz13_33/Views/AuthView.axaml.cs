using Avalonia.Controls;
using Avalonia.Interactivity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using pzz13_33.Data;
using pzz13_33.ViewModels;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Linq;
using System.Reactive;
using MsBox.Avalonia;

namespace pzz13_33.Views;
public partial class AuthView : UserControl
{
    public AuthView()
    {
        InitializeComponent();

        checkBox.IsCheckedChanged += delegate
        {
            tbPassword.PasswordChar = checkBox.IsChecked switch
            {
                false => '\0',
                true => '*'
            };
        };
        buttonEnter.Click += ButtonEnter_Click;
        buttonRegistr.Click += ButtonRegistr_Click;

    }

    private void ButtonRegistr_Click(object? sender, RoutedEventArgs e)
    {
        MainViewModel.MainWindow.Content = new RegistrationView();

    }

    private async void ButtonEnter_Click(object? sender, RoutedEventArgs e)
    {
        if (tbLogin.Text != "" && tbPassword.Text != "")
        {
            using (DataBase dataBase = new DataBase())
            {
                User user = dataBase.Users.Where(x => x.Login == tbLogin.Text && x.Password == tbPassword.Text).FirstOrDefault();
                if (user != null)
                {
                    await MessageBoxManager.GetMessageBoxStandard(title: "Успешно", text: "Вы успешно авторизировались").ShowAsPopupAsync(this);
                    MainViewModel.MainWindow.Content = new TovarsView();
                }
                else
                {
                   await MessageBoxManager.GetMessageBoxStandard(title: "Ошибка", text: "Вы неправильно ввели пароль или логин!").ShowAsPopupAsync(this);

                }
            }
        }
    }
}
