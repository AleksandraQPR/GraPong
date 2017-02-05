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

namespace ProjektGrupowy
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ekranO ekran;
        Options opcje;

        public MainWindow()
        {
            ekran = new ekranO();
            opcje = new Options();
            ekran.Op = opcje;

            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Opcje_Click(object sender, RoutedEventArgs e)
        {
            ekranO ekran = new ekranO();
            ekran.ShowDialog();
        }

        private void O_autorach_Click(object sender, RoutedEventArgs e)
        {
            AboutA ekran = new AboutA();
            ekran.ShowDialog();
        }

        private void Pomoc_Click(object sender, RoutedEventArgs e)
        {
            Sterowanie ekran = new Sterowanie();
            ekran.ShowDialog();
        }
    }
}
