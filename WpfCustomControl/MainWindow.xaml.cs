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

namespace WpfCustomControl
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MyCustomControl_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("It is the custom routed event of your custom control");
            e.Handled = true;
        }

        private void StackPanel_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Bubbled to Stackpanel");
        }
    }
}
