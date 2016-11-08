using System;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weihnachtskalender
{
    class Controller

    {
        AddDataHandler addDataHandler = new AddDataHandler();
        
        private int _currentDate;


        //Konstruktor
        public Controller()
        {
            getSystemDate();
            addDataHandler.readXML();
        }

        public void start(int btn)
        {
            if (checkDateValidity(btn) == true)
            {
                //Do something
            }
            else
            {
                MessageBox.Show("You did select the wrong day.", "Oh oh...");
            }
            
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
