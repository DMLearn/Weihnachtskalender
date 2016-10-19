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
        public AddDataHandler addDataHandler = new AddDataHandler();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void lockAddData_OnClick( object sender, RoutedEventArgs e )
        {
            addDataHandler.lockAddData();
        }

        private void unlockAddData_OnClick( object sender, RoutedEventArgs e )
        {
            addDataHandler.unlockAddData();

        }
    }
}
