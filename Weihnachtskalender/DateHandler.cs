using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weihnachtskalender
{
    public class DateHandler
    {
        public string systemDate { get; private set; }

        public DateHandler()
        {
            getSystemDate();
            readXML();
        }

        private void getSystemDate()
        {
            systemDate = Convert.ToString(DateTime.Today.Day) + "." + Convert.ToString(DateTime.Today.Month);
        }

        private void readXML()
        {

        }
    }
}
