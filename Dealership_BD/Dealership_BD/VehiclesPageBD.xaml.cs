﻿using System;
using System.Collections.Generic;
using System.Data;
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
using Dealership_BD.DealershipDataSetTableAdapters;

namespace Dealership_BD
{
    /// <summary>
    /// Логика взаимодействия для VehiclesPageBD.xaml
    /// </summary>
    public partial class VehiclesPageBD : Page
    {
        VehiclesTableAdapter vehicles = new VehiclesTableAdapter();
        public VehiclesPageBD()
        {
            InitializeComponent();
            BD_Vehicles.ItemsSource = vehicles.GetData();
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                vehicles.InsertQuery(Convert.ToInt32(text1.Text), Convert.ToInt32(text2.Text), text3.Text, Convert.ToDecimal(text4.Text));
                BD_Vehicles.ItemsSource = vehicles.GetData();
            }
            catch 
            {
                MessageBox.Show("Не существует машины с таким брендом и моделью!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void edit_Click(object sender, RoutedEventArgs e)
        {
            object id = (BD_Vehicles.SelectedItem as DataRowView).Row[0];
            vehicles.UpdateQuery(Convert.ToInt32(text1.Text), Convert.ToInt32(text2.Text), text3.Text, Convert.ToDecimal(text4.Text), Convert.ToInt32(id));
            BD_Vehicles.ItemsSource = vehicles.GetData();
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            object id = (BD_Vehicles.SelectedItem as DataRowView).Row[0];
            vehicles.DeleteQuery(Convert.ToInt32(id));
            BD_Vehicles.ItemsSource = vehicles.GetData();
        }

        private void BD_Vehicles_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (BD_Vehicles.SelectedItem != null)
            {
                DataRowView row = BD_Vehicles.SelectedItem as DataRowView;
                if (row != null)
                {
                    text1.Text = row.Row["Brand_ID"].ToString();
                    text2.Text = row.Row["Model_ID"].ToString();
                    text3.Text = row.Row["Years"].ToString();
                    text4.Text = row.Row["Price"].ToString();
                }
            }
        }
    }
}