using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weihnachtskalender
{
    class Controller
    {
        private int _currentDate;

        //Konstruktor
        public Controller()
        {
            getSystemDate();
        }

        public void start(int btn)
        {

        }

        private void getSystemDate()
        {
            _currentDate = Convert.ToInt16(DateTime.Now.Day);
        }

    }
}
