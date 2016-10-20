using System;
using System.Diagnostics;
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
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(_addDataFolderPath + "\\DateConfig.xml");
                xmlDateList = doc.SelectNodes("root");
                foreach (XmlNode node in doc.DocumentElement)
                {
                    string id = node.Attributes[0].Value;
                    string status = node.Attributes[1].Value;
                    Debug.WriteLine("Date: {0}, Status: {1}", id, status);
                }

            }
            catch (Exception ex)
            {
                throw new System.IO.FileNotFoundException( "Error reading .xml config file", ex );
            }

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
            ds.RemoveAccessRuleAll( fsa );
            Directory.SetAccessControl( _addDataFolderPath, ds );
        }
    }
}
