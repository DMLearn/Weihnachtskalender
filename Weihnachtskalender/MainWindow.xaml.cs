﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Weihnachtskalender
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Controller controller = new Controller();

        //Konstruktor
        public MainWindow()
        {
            InitializeComponent();


            //Creates Bindings between code behind and xaml
            buttonCanvas.DataContext = controller.addDataHandler.datesList;
            currentDateCanvas.Text = "        Hallo mein Schatz, heute ist der " + controller.currentDate.ToString() + ". Dezember.";
            backroundImage.Source = new BitmapImage(new Uri(controller.addDataHandler.addDataBackroundPicture, UriKind.Absolute));


        }

        //Button pressed
        private void btn_Clicked (object sender, RoutedEventArgs e)
        {
            int tag = Convert.ToInt16(((Button)sender).Tag);
            controller.start(tag);
        }

    }
}
