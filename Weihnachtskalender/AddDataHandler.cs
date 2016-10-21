using System;
using System.Diagnostics;
using System.Linq;
using System.Xml;
using System.IO;
using System.Security.AccessControl;
using System.Collections.Generic;

namespace Weihnachtskalender
{
    public class AddDataHandler
    {

        private List<Tuple<string, bool>> _datesList = new List<Tuple<string, bool>>();          
        private string _addDataFolderPath;
        private string _addDataPictureFolderPath;
        private string _adminUserName; 


        public AddDataHandler()
        {
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

                foreach (XmlNode node in doc.DocumentElement)
                {
                    string id = node.Attributes[0].Value;
                    bool locked = Convert.ToBoolean(node.Attributes[1].Value);
                    _datesList.Add(new Tuple<string, bool> (id, locked));
                        
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
