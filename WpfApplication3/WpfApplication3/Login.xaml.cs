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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Data;

namespace WpfApplication3
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        private double h;
        private double w;
        private TextBox userName;
        private PasswordBox password;
        private Viewbox userNameV;
        private Viewbox passwordV;

        public Login()
        {
            InitializeComponent();
            initializeWindow();
        }

        private void initializeWindow()
        {
            h = MainWindow.window.myWindow.getHeight();
            w = MainWindow.window.myWindow.getWidth();

            initializeButton(logIn, "LogInButton", 0.08, 0.05, 0.60, 0.70);
            initializeButton(UserNameB, "username", 0.15, 0.05, 0.52, 0.40);
            initializeButton(PasswordB, "Password", 0.15, 0.05, 0.52, 0.58);

            userName = new TextBox();
            userNameV = new Viewbox();
            userName.VerticalContentAlignment = VerticalAlignment.Center;
            initializeTextBox(userNameV, userName, 0.15, 0.05, 0.52, 0.40);

            password = new PasswordBox();

            passwordV = new Viewbox();
            password.VerticalContentAlignment = VerticalAlignment.Center;

            passwordV.Child = password;
            password.FontSize = 20;
            passwordV.Width = w * 0.15;
            passwordV.Height = h * 0.05;
            password.Width = w * 0.15;
            password.Height = h * 0.05;
            LogInCanvas.Children.Add(passwordV);
            Canvas.SetTop(passwordV, h * 0.52);
            Canvas.SetLeft(passwordV, w * 0.58);
            password.IsEnabled = false;
            password.Visibility = Visibility.Hidden;
        }

        private void reset()
        {
            UserNameB.Visibility = Visibility.Visible;
            UserNameB.IsEnabled = true;
            userName.IsEnabled = false;
            userName.Visibility = Visibility.Hidden;
            userName.Text = "";

            PasswordB.Visibility = Visibility.Visible;
            PasswordB.IsEnabled = true;
            password.IsEnabled = false;
            password.Visibility = Visibility.Hidden;
            password.Password = "";


        }

        private void initializeTextBox(Viewbox viewBox, TextBox textBox, double tbW, double tbH, double top, double left)
        {
            viewBox.Child = textBox;
            textBox.TextWrapping = TextWrapping.Wrap;
            textBox.FontSize = 20;
            viewBox.Width = w * tbW;
            viewBox.Height = h * tbH;
            textBox.Width = w * tbW;
            textBox.Height = h * tbH;
            LogInCanvas.Children.Add(viewBox);
            Canvas.SetTop(viewBox, h * top);
            Canvas.SetLeft(viewBox, w * left);
            textBox.IsEnabled = false;
            textBox.Visibility = Visibility.Hidden;
        }

        private void initializeButton(Button button, string name, double buttonW, double buttonH, double top, double left)
        {
            BitmapImage bitmap = new BitmapImage();
            Image img = new Image();
            bitmap.BeginInit();
            bitmap.UriSource = new Uri("/WpfApplication3;component/Images/Buttons/LogIn/" + name + ".png", UriKind.Relative);
            bitmap.EndInit();
            img.Stretch = Stretch.Fill;
            img.Source = bitmap;
            button.Content = img;
            button.Background = new ImageBrush(bitmap);
            button.Width = w * buttonW;
            button.Height = h * buttonH;

            Canvas.SetTop(button, h * top);
            Canvas.SetLeft(button, w * left);
        }

        private void ButtonOnClick(object sender, RoutedEventArgs e)
        {
            var b = (Button)e.OriginalSource;

            switch (b.Name)
            {
                case "logIn":
                    {
                        if (userName.Text.Equals("") || password.Password.Equals(""))
                        {
                            MessageBox.Show("Dados Inválidos");
                            break;
                        }
                        checkLogin(userName.Text, password.Password);
                        reset();
                        break;
                    }
                case "UserNameB":
                    {
                        UserNameB.Visibility = Visibility.Hidden;
                        UserNameB.IsEnabled = false;
                        userName.IsEnabled = true;
                        userName.Visibility = Visibility.Visible;
                        userName.Focus();
                        break;
                    }
                case "PasswordB":
                    {
                        PasswordB.Visibility = Visibility.Hidden;
                        PasswordB.IsEnabled = false;
                        password.IsEnabled = true;
                        password.Visibility = Visibility.Visible;
                        password.Focus();
                        break;
                    }
            }
        }

        private void checkLogin(string user, string pwd)
        {
            int id;
            id=GetId(user);
            Connection.Conn.Open();
            SqlCommand cmd = new SqlCommand("Games.VerifyLogin", Connection.Conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@pass", pwd);

            var res = cmd.Parameters.Add("@res", SqlDbType.Bit);
            res.Direction = ParameterDirection.Output;
            var nome = cmd.Parameters.Add("@nome", SqlDbType.VarChar);
            nome.Direction = ParameterDirection.Output;
            nome.Size = 15;
            var idloja = cmd.Parameters.Add("@idloja", SqlDbType.Int);
            idloja.Direction = ParameterDirection.Output;
            var nomeloja = cmd.Parameters.Add("@nome_loja", SqlDbType.VarChar);
            nomeloja.Direction = ParameterDirection.Output;
            nomeloja.Size = 30;
            var mngbit = cmd.Parameters.Add("@manager", SqlDbType.Bit);
            mngbit.Direction = ParameterDirection.Output;


            cmd.ExecuteNonQuery();
            if (Convert.ToBoolean(res.Value))
            {
                MessageBox.Show("LogIn efectuado com sucesso!\nBem vindo: " + nome.Value);
                MainWindow.idFunc = id;
                MainWindow.nomeFunc = nome.Value.ToString();
                MainWindow.idLoja = (int)idloja.Value;
                MainWindow.nomeLoja = nomeloja.Value.ToString();
                MainWindow.isManager = (bool)mngbit.Value;
                MainWindow.window.framename.Navigate(MainWindow.window.mainPage);
                MainWindow.window.mainPage.initializeUserData();
                MainWindow.window.stocks.initializeUserData();
                MainWindow.window.dados.initializeUserData();
                MainWindow.window.settings.initializeUserData();
            }
            else
            {
                MessageBox.Show("LogIn falhou, por favor verifique os dados submetidos" + nome.Value);
            }
            Connection.Conn.Close();
        }
        private int GetId(string user) {

            Connection.Conn.Open();
            SqlCommand cmd = new SqlCommand("Games.GetID", Connection.Conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@email", SqlDbType.VarChar));
            cmd.Parameters["@email"].Value = user;

            var id_func = cmd.Parameters.Add("@id", SqlDbType.Int);
            id_func.Direction = ParameterDirection.Output;

            cmd.ExecuteNonQuery();
            Connection.Conn.Close();

                return (int)id_func.Value;
        }


        private void Page_PreviewKeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                checkLogin(userName.Text, password.Password);

        }

    }
}
