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
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        private double h;
        private double w;

        public MainPage()
        {
            InitializeComponent();
            initializeWindow();
        }

        private void initializeWindow()
        {
            h = MainWindow.window.myWindow.getHeight();
            w = MainWindow.window.myWindow.getWidth();

            initializeLeftAndTopBar();
        }

        public void initializeLeftAndTopBar()
        {
            MainWindow.window.myWindow.initializeLeftBarButton(sale, "SaleButton", 0.08, 0.15, 0.22, 0.112);
            MainWindow.window.myWindow.initializeLeftBarButton(stocks, "AddStockButton", 0.08, 0.15, 0.42, 0.112);
            MainWindow.window.myWindow.initializeLeftBarButton(dados, "StatisticsButton", 0.08, 0.15, 0.62, 0.112);

            MainWindow.window.myWindow.initializeTopBar(logOut, "logOut", 0.035, 0.07, 0.1, 0.85);
            MainWindow.window.myWindow.initializeTopBar(settings, "settings", 0.035, 0.075, 0.1, 0.79);
        }
        public void initializeUserData()
        {
            lojaData.Text = MainWindow.nomeLoja;
            lojaData.Foreground = Brushes.Azure;
            funcData.Text = "Funcionário: " + MainWindow.nomeFunc;
            funcData.Foreground = Brushes.Azure;

            if (MainWindow.isManager)
            {
                manager.Content = "GERENTE";
            }
            else {
                manager.Content = "FUNCIONÁRIO";
            }
            label_nome.Content = MainWindow.nomeFunc;
            label_id.Content = MainWindow.idFunc.ToString();
            label_loja.Content = MainWindow.nomeLoja;
            label_idloja.Content = MainWindow.idLoja;


            lojaView.MinWidth = w * 0.06;
            lojaView.Height = h * 0.03;
            funcView.MinWidth = w * 0.06;
            funcView.Height = h * 0.03;
            Canvas.SetTop(lojaView, h * 0.138);
            Canvas.SetTop(funcView, h * 0.138);
            Canvas.SetLeft(lojaView, w * 0.4);
            Canvas.SetLeft(funcView, w * 0.5);
        }

        private void ButtonOnClick(object sender, RoutedEventArgs e)
        {
            var b = (Button)e.OriginalSource;
            MainWindow.window.myClick.buttonOnClickLeftBar(b.Name);
        }

       
    }
}
