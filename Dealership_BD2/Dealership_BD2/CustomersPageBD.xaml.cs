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

namespace Dealership_BD2
{
    /// <summary>
    /// Логика взаимодействия для CustomersPageBD.xaml
    /// </summary>
    public partial class CustomersPageBD : Page
    {
        private DealershipEntities customers = new DealershipEntities();
        public CustomersPageBD()
        {
            InitializeComponent();
            BD_Customers.ItemsSource = customers.Customers.ToList();
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            Customers c = new Customers();
            c.CustomerSurname = text1.Text;
            c.CustomerName = text2.Text;
            c.CustomerMiddleName = text3.Text;
            c.PhoneNumber = text4.Text;
            c.Email = text5.Text;

            customers.Customers.Add(c);
            customers.SaveChanges();
            BD_Customers.ItemsSource = customers.Customers.ToList();
        }

        private void edit_Click(object sender, RoutedEventArgs e)
        {
            if (BD_Customers.SelectedItem != null)
            {
                var selected = BD_Customers.SelectedItem as Customers;

                selected.CustomerSurname = text1.Text;
                selected.CustomerName = text2.Text;
                selected.CustomerMiddleName = text3.Text;
                selected.PhoneNumber = text4.Text;
                selected.Email = text5.Text;

                customers.SaveChanges();
                BD_Customers.ItemsSource = customers.Customers.ToList();
            }
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var selectedCustomer = BD_Customers.SelectedItem as Customers;
                if (selectedCustomer != null)
                {
                    customers.Customers.Remove(selectedCustomer);
                    customers.SaveChanges();
                    BD_Customers.ItemsSource = customers.Customers.ToList();
                }

            }
            catch
            {
                MessageBox.Show("Невозможно удалить клиента, так как с ним связаны другие таблицы!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BD_Customers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (BD_Customers.SelectedItem != null)
            {
                var selected = BD_Customers.SelectedItem as Customers;

                text1.Text = selected.CustomerSurname;
                text2.Text = selected.CustomerName;
                text3.Text = selected.CustomerMiddleName;
                text4.Text = selected.PhoneNumber;
                text5.Text = selected.Email;

                customers.SaveChanges();
                BD_Customers.ItemsSource = customers.Customers.ToList();
            }
        }
    }
}