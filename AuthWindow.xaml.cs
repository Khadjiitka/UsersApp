using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace UsersApp
{
    /// <summary>
    /// Логика взаимодействия для AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        public AuthWindow()
        {
            InitializeComponent();
        }

        private void Button_Auth_Click(object sender, RoutedEventArgs e)
        {
            string login = textBoxLogin.Text.Trim(); //удаляет пробелы
            string pass = passBox.Password.Trim();

            if (login.Length < 5)
            {
                textBoxLogin.ToolTip = "The login must contain more than 5 characters.";
                textBoxLogin.Background = Brushes.DarkRed;
            }
            else if (pass.Length < 5)
            {
                passBox.ToolTip = "The password must contain more than 5 characters.";
                passBox.Background = Brushes.DarkRed;
            }
            else
            {
                textBoxLogin.ToolTip = "";
                textBoxLogin.Background = Brushes.Transparent;
                passBox.ToolTip = "";
                passBox.Background = Brushes.Transparent;

                User authUser = null;
                using (AppContext db = new AppContext())
                { 
                    //находим пользователя с подходязими данными
                    //authUser = db.Users.Where(b => b.Login == login && b.Password == pass).FirstOrDefault();
                    authUser = db.Users.FirstOrDefault(user => user.Login == login && user.Password == pass);


                    if (authUser != null)
                    {
                      //  MessageBox.Show("User successfully registered");
                        //Переход на окно 
                        UserPageWindow userPageWindow = new UserPageWindow(); 
                        userPageWindow.Show();
                        this.Hide();
                    }
                       
                    else
                        MessageBox.Show("Unknown user. Sign up or link your account first.");
                }

            }
            
            
        }

        private void Button_Click_Reg(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Hide(); //скрыть текущее окно
        }

        private void Button_Window_Auth_Click(object sender, RoutedEventArgs e)
        {
                AuthWindow authWindow = new AuthWindow();
                authWindow.Show();
                Hide(); //скрыть текущее окно

            
        }
    }
}
