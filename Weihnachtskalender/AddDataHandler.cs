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

        public List<Tuple<string, bool>> datesList = new List<Tuple<string, bool>>();          
        private string _addDataFolderPath;
        private string _addDataPictureFolderPath;
        private string _addDataDateConfigXMLPath;
        private string _adminUserName; 


        //Konstrutur
        public AddDataHandler()
        {
            _addDataFolderPath = Directory.GetCurrentDirectory() + "\\AddData";
            _addDataPictureFolderPath = _addDataFolderPath + "\\Picture";
            _addDataDateConfigXMLPath = _addDataFolderPath + "\\DateConfig.xml";
            _adminUserName = Environment.UserName;
        }

        public void readXML()
        {    
            #region try open xml and catch error
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(_addDataDateConfigXMLPath);

                foreach (XmlNode node in doc.DocumentElement)
                {
                    string id = node.Attributes[0].Value;
                    bool locked = Convert.ToBoolean(node.Attributes[1].Value);
                    datesList.Add(new Tuple<string, bool> (id, locked));                 
                }

            }
            catch (Exception ex)
            {
                throw new System.IO.FileNotFoundException( "Error reading .xml config file", ex );
            }
            #endregion
        }

        public  void writeXML()
        {
            # region try writing to xml and catch error
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(_addDataDateConfigXMLPath);

                foreach (Tuple<string, bool> tuple in datesList)
                {
                    string id = tuple.Item1;
                    string nodePath = "/dates/date[@id='" + id + "']";
                    XmlNode node = doc.SelectSingleNode(nodePath);
                    node.Attributes["locked"].Value = tuple.Item2.ToString();
                }
                doc.Save(_addDataDateConfigXMLPath);
            }
            catch (Exception ex)
            {
                throw new System.IO.FileNotFoundException("Error reading .xml config file", ex); ;
            }
            #endregion
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
