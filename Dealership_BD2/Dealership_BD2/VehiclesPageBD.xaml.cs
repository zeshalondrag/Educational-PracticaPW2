using System;
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
using System.Globalization;

namespace Dealership_BD2
{
    /// <summary>
    /// Логика взаимодействия для VehiclesPageBD.xaml
    /// </summary>
    public partial class VehiclesPageBD : Page
    {
        private DealershipEntities vehicles = new DealershipEntities();
        public VehiclesPageBD()
        {
            InitializeComponent();
            BD_Vehicles.ItemsSource = vehicles.Vehicles.ToList();
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            CultureInfo culture = CultureInfo.InvariantCulture;

            Vehicles v = new Vehicles();
            v.Brand_ID = Convert.ToInt32(text1.Text);
            v.Model_ID = Convert.ToInt32(text2.Text);
            v.Years = text3.Text;

            decimal price;
            try
            {
                if (Decimal.TryParse(text4.Text, NumberStyles.AllowDecimalPoint, culture, out price))
                {
                    v.Price = price;

                    vehicles.Vehicles.Add(v);
                    vehicles.SaveChanges();
                    BD_Vehicles.ItemsSource = vehicles.Vehicles.ToList();
                }
                else
                {
                    MessageBox.Show("Неверный формат цены. Пожалуйста, введите корректное число", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch
            {
                MessageBox.Show("Не существует машина с таким брендом и моделью!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void edit_Click(object sender, RoutedEventArgs e)
        {
            if (BD_Vehicles.SelectedItem != null)
            {
                var selected = BD_Vehicles.SelectedItem as Vehicles;

                if (selected != null)
                {
                    selected.Brand_ID = Convert.ToInt32(text1.Text);
                    selected.Model_ID = Convert.ToInt32(text2.Text);
                    selected.Years = text3.Text;
                    selected.Price = Convert.ToDecimal(text4.Text);

                    vehicles.SaveChanges();
                    BD_Vehicles.ItemsSource = vehicles.Vehicles.ToList();
                }
            }
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            var selectedVehicles = BD_Vehicles.SelectedItem as Vehicles;
            if (selectedVehicles != null)
            {
                vehicles.Vehicles.Remove(selectedVehicles);
                vehicles.SaveChanges();
                BD_Vehicles.ItemsSource = vehicles.Vehicles.ToList();
            }
        }

        private void BD_Vehicles_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (BD_Vehicles.SelectedItem != null)
                {
                    var selected = BD_Vehicles.SelectedItem as Vehicles;

                    if (selected != null)
                    {
                        text1.Text = selected.Brand_ID.ToString(); 
                        text2.Text = selected.Model_ID.ToString(); 
                        text3.Text = selected.Years;
                        text4.Text = selected.Price.ToString(); 

                        vehicles.SaveChanges();
                        BD_Vehicles.ItemsSource = vehicles.Vehicles.ToList();
                    }
                }
            }
            catch { }
        }
    }
}