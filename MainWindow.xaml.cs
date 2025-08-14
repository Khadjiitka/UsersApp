using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Media.Animation;

namespace UsersApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        AppContext db;
        public MainWindow()
        {
            InitializeComponent();

            db = new AppContext();
            
            DoubleAnimation btnAnimation = new DoubleAnimation(); // обьект для создания анимации using System.Windows.Media.Animation;
            btnAnimation.From = 0; //первичное состояние
            btnAnimation.To = 450; // куда движется
            btnAnimation.Duration = TimeSpan.FromSeconds(2); // время на анимацию
            
            regButton.BeginAnimation(Button.WidthProperty, btnAnimation); //(какое свойство меняем, анимация) 

            /*        List<User> users = db.Users.ToList();// вытянуть все записи и преобраз в список
                    string str = "";
                    //записьіваем в строку все из бд
                    foreach (User user in users)
                    {
                        str += "Login: " + user.login + " | ";
                    }
                    exampleText.Text = str; //вывод в строку
           */
        }
        //Переход на окно 
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string login = textBoxLogin.Text.Trim(); //удаляет пробелы
            string pass = passBox.Password.Trim();
            string pass_2 = passBox_2.Password.Trim();
            string email = textBoxEmail.Text.Trim().ToLower(); //в нижний регистр

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
            else if (pass != pass_2)
            {
                passBox_2.ToolTip = "Incorrect input.";
                passBox_2.Background = Brushes.DarkRed;
            }
            else if (email.Length < 5 || !email.Contains("@") || !email.Contains("."))
            {
                textBoxEmail.ToolTip = "Incorrect input.";
                textBoxEmail.Background = Brushes.DarkRed;
            }
            else
            {
                textBoxLogin.ToolTip = "";
                textBoxLogin.Background = Brushes.Transparent;
                passBox.ToolTip = "";
                passBox.Background = Brushes.Transparent;
                passBox_2.ToolTip = "";
                passBox_2.Background = Brushes.Transparent;
                textBoxEmail.ToolTip = "";
                textBoxEmail.Background = Brushes.Transparent;

                MessageBox.Show("User successfully registered");

                User user = new User(login, pass, email);
                db.Users.Add(user);
                db.SaveChanges();

                AuthWindow authWindow = new AuthWindow();
                authWindow.Show();
                this.Hide();
            }

        }



        private void Button_Wind_Auth_Click(object sender, RoutedEventArgs e)
        {
            AuthWindow authWindow = new AuthWindow();
            authWindow.Show();
            Hide(); //скрыть текущее окно

        }
    }
}