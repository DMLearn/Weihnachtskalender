using System;
using System.Diagnostics;
using System.Linq;
using System.Xml;
using System.IO;
using System.Security.AccessControl;
using System.Collections.Generic;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace Weihnachtskalender
{
    public class AddDataHandler : INotifyPropertyChanged

    {
        //TODO datesList in Property umwandlen, damit das Binding funktioniert.
        //public ObservableCollection<Tuple<string, string>> datesList = new ObservableCollection<Tuple<string, string>>();

        private ObservableCollection<Tuple<string, string>> _datesList = new ObservableCollection<Tuple<string, string>>();
        public ObservableCollection<Tuple<string, string>> datesList
        {
            get { return _datesList ; }
            set
            {
                _datesList = value;
                RaisePropertyChanged("datesList");
            }
        }

        public string _lowOpacity = "0.2"; 

        //Implementation of INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }


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

        public void updateDatesList(int btn)
        {
            //_datesList[btn-1].Item2.Replace("1.0", "0.2");
            var updatedOpacity = Tuple.Create(Convert.ToString(btn), _lowOpacity);
            _datesList.Insert(btn - 1, updatedOpacity);
            _datesList.RemoveAt(btn);    
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
                    string opacity = node.Attributes[1].Value;
                    _datesList.Add(new Tuple<string, string> (id, opacity));                 
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

                foreach (Tuple<string, string> tuple in _datesList)
                {
                    string id = tuple.Item1;
                    string nodePath = "/dates/date[@id='" + id + "']";
                    XmlNode node = doc.SelectSingleNode(nodePath);
                    node.Attributes["opacity"].Value = tuple.Item2;
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
