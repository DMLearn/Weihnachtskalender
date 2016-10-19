using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;


namespace Weihnachtskalender
{
    public class DateHandler
    {
        public string systemDate { get; private set; }
        public XmlNodeList xmlDateList { get; private set; } 

        public DateHandler()
        {
            systemDate = "1.12";
            xmlDateList = null;

            getSystemDate();
            readXML();
        }

        private void getSystemDate()
        {
            systemDate = Convert.ToString(DateTime.Today.Day) + "." + Convert.ToString(DateTime.Today.Month);
        }

        public void readXML()
        {
            XmlDocument doc = new XmlDocument();
            string currentOSPAth = Directory.GetCurrentDirectory();
            Console.WriteLine(currentOSPAth);

        }

        /*
         *string folderPath = txtFilePath.Text;
          string adminUserName = Environment.UserName;// getting your adminUserName
          DirectorySecurity ds = Directory.GetAccessControl(folderPath);
          FileSystemAccessRule fsa = new FileSystemAccessRule(adminUserName, FileSystemRights.FullControl, AccessControlType.Deny);
          
          ***lock folder***
          ds.AddAccessRule(fsa);
          Directory.SetAccessControl(folderPath, ds); 

          ***unlock folder***
          ds.RemoveAccessRule(fsa);
          Directory.SetAccessControl(folderPath, ds);
         */
    }
}
