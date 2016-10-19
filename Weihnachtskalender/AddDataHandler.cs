using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;
using System.Security.AccessControl;

namespace Weihnachtskalender
{
    public class AddDataHandler
    {

        public XmlNodeList xmlDateList { get; private set; }
        private string _addDataFolderPath;
        private string _addDataPictureFolderPath;
        private string _adminUserName; 


        public AddDataHandler()
        {
            xmlDateList = null;
            _addDataFolderPath = Directory.GetCurrentDirectory() + "\\AddData";
            _addDataPictureFolderPath = _addDataFolderPath + "\\Picture";
            _adminUserName = Environment.UserName;

            readXML();
        }

        private void readXML()
        {
            XmlDocument doc = new XmlDocument();
        }

        public void lockAddData()
        {
            
            DirectorySecurity ds = Directory.GetAccessControl( _addDataFolderPath );
            FileSystemAccessRule fsa = new FileSystemAccessRule( _adminUserName, FileSystemRights.FullControl, AccessControlType.Deny );
            ds.AddAccessRule( fsa );
            Directory.SetAccessControl( _addDataFolderPath, ds );
        }

        public void unlockAddData()
        {

            DirectorySecurity ds = Directory.GetAccessControl( _addDataFolderPath );
            FileSystemAccessRule fsa = new FileSystemAccessRule( _adminUserName, FileSystemRights.FullControl, AccessControlType.Deny );
            ds.RemoveAccessRule( fsa );
            Directory.SetAccessControl( _addDataFolderPath, ds );
        }
    }
}
