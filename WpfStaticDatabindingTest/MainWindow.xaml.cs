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

namespace WpfStaticDatabindingTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            StaticHelper.Instance.StaticString = "Old string";
            SecondWindow second = new SecondWindow();
            second.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e) //Flicker between two strings
        {
            if (StaticHelper.Instance.StaticString == "Old string")
            {
                StaticHelper.Instance.StaticString = "New string";
            }
            else
            {
                StaticHelper.Instance.StaticString = "Old string";
            }
            
        }
    }
}
