using Avalonia.Controls;
using ReactiveUI.Fody.Helpers;
using ReactiveUI;
using System.Reactive;
using Avalonia.Interactivity;
using MsBox.Avalonia;
using pzz13_33.Data;
using System.Linq;
using pzz13_33.ViewModels;
using System.Diagnostics;

namespace pzz13_33.Views
{
    public partial class RegistrationView : UserControl
    {
        public RegistrationView()
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
            buttonRegistr.Click += ButtonEnter_Click;
        }
        private async void ButtonEnter_Click(object? sender, RoutedEventArgs e)
        {
            if (tbLogin.Text != "" && tbPassword.Text != "" && tbName.Text != "")
            {
                using (DataBase dataBase = new DataBase())
                {

                    dataBase.Users.Add(new User()
                    {
                        Name = tbName.Text, 
                        Login = tbLogin.Text, Password = tbPassword.Text
                    });
                   dataBase.SaveChanges();
                       await MessageBoxManager.GetMessageBoxStandard(title: "Успешно", text: "Вы успешно зарегестрировались").ShowAsPopupAsync(this);
                        MainViewModel.MainWindow.Content = new AuthView();

                    
                }
            }else await MessageBoxManager.GetMessageBoxStandard(title: "Ошибка", text: "Вы не заполнили поля").ShowAsPopupAsync(this);
        }
    }
}



    

