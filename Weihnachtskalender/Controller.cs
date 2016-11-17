using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Data;
using System.Windows.Media.Imaging;
using System.Windows.Controls;

namespace Weihnachtskalender
{
    class Controller 

    {

        public AddDataHandler addDataHandler = new AddDataHandler();

        private int _currentDate;
        public int currentDate
        {
            get { return _currentDate; }
            set { _currentDate = value; }
        }

        //Konstruktor
        public Controller()
        {
            getSystemDate();
            addDataHandler.readXML();
        }

        public void start(int btn)
        {
            #region Check if select date ist valid and then process data
            if (checkDateValidity(btn) == true)
            {
                addDataHandler.updateDatesList(btn);
                addDataHandler.writeXML();
                displayPicture(btn);
            }
            else
            {
                MessageBox.Show("Da ist aber jemand neugierig :-)\nDas ausgewählte Datum darf nicht in der Zukunft liegen!", "Oh oh...", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            #endregion
 
        }

        private void getSystemDate()
        {
            _currentDate = Convert.ToInt16(DateTime.Now.Day);
        }

        private bool checkDateValidity(int btnTag)
        {
            if ( _currentDate >= btnTag )
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        private void displayPicture(int btn)
        {
            PictureWindow newWindow = new PictureWindow();
            Binding b = new Binding();
            b.Mode = BindingMode.OneWay;

            string imagePath = addDataHandler.addDataPictureFolderPath + "\\" + btn + ".jpg";
            b.Source = new BitmapImage(new Uri(imagePath, UriKind.Absolute));
            newWindow.dateImage.SetBinding(Image.SourceProperty, b);
            newWindow.Show();
        }

    }
}
