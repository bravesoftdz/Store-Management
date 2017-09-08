using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication3
{
   public class MyClick
    {
        public void buttonOnClickLeftBar(string p)
        {
            switch (p)
            {
                case "sale":
                    MainWindow.window.framename.Navigate(MainWindow.window.mainPage);
                    break;
                case "stocks":
                    MainWindow.window.framename.Navigate(MainWindow.window.stocks);
                    break;
                case "dados":
                    MainWindow.window.framename.Navigate(MainWindow.window.dados);
                    break;
                case "logOut":
                    MainWindow.window.framename.Navigate(MainWindow.window.login);
                    break;
                case "settings":
                    MainWindow.window.framename.Navigate(MainWindow.window.settings);
                    break;
            }
        }
    }
}
