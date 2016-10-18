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

namespace Weihnachtskalender
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public DateHandler dateHandler = new DateHandler();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void getSystemDate_OnClick(object sender, RoutedEventArgs e)
        {
            textBoxSystemDate.FontSize = 20;
            textBoxSystemDate.Text = dateHandler.systemDate;

        }
    }
}
