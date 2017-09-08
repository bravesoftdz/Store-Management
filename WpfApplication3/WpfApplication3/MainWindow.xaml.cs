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

namespace WpfApplication3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static MainWindow window;
        public MyWindow myWindow;
        public MyClick myClick;

        private String active;
        public double height;
        public double width;

        public Stocks stocks;
        public Dados dados;
        public Login login;
        public MainPage mainPage;
        public Settings settings;
       

        public static string nomeFunc;
        public static string nomeLoja;
        public static int idFunc;
        public static int idLoja;
        public static bool isManager;

        public MainWindow()
        {
            InitializeComponent();

            window = this;
            height = this.Height;
            width = this.Width;
            myWindow = new MyWindow(height, width);
            myClick = new MyClick();

            stocks = new Stocks();
            dados = new Dados();
            login= new Login();
            mainPage = new MainPage();
            settings = new Settings();

            framename.Navigate(login);
        }

        public String Frame { get { return active; } set { active = value; } }
    }
}
