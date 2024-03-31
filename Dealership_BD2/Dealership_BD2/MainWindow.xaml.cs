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

namespace Dealership_BD2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void page1_Click(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = new CustomersPageBD();
        }

        private void page2_Click(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = new VehiclesPageBD();
        }

        private void page3_Click(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = new ModelsPageBD();
        }

        private void page4_Click(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = new BrandsPageBD();
        }

        private void page5_Click(object sender, RoutedEventArgs e)
        {
            PageFrame.Content = new OrdersPageBD();
        }
    }
}