using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

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
            }
            else
            {
                MessageBox.Show("You did select the wrong day.", "Oh oh...");
            }
            #endregion

            addDataHandler.writeXML();
            
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

    }
}
