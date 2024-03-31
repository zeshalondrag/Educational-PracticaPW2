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
    /// Логика взаимодействия для OrdersPageBD.xaml
    /// </summary>
    public partial class OrdersPageBD : Page
    {
        private DealershipEntities orders = new DealershipEntities();
        public OrdersPageBD()
        {
            InitializeComponent();
            BD_Orders.ItemsSource = orders.Orders.ToList();
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            Orders o = new Orders();
            o.Customer_ID = Convert.ToInt32(text1.Text);
            o.Vehicle_ID = Convert.ToInt32(text2.Text);
            o.OrderDate = Convert.ToDateTime(text3.Text);
            o.Amount = Convert.ToInt32(text4.Text);

            orders.Orders.Add(o);
            orders.SaveChanges();
            BD_Orders.ItemsSource = orders.Orders.ToList();
        }

        private void edit_Click(object sender, RoutedEventArgs e)
        {
            if (BD_Orders.SelectedItem != null)
            {
                var selected = BD_Orders.SelectedItem as Orders;

                selected.Customer_ID = Convert.ToInt32(text1.Text);
                selected.Vehicle_ID = Convert.ToInt32(text2.Text);
                selected.OrderDate = Convert.ToDateTime(text3.Text);
                selected.Amount = Convert.ToInt32(text4.Text);

                orders.SaveChanges();
                BD_Orders.ItemsSource = orders.Orders.ToList();
            }
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            var selectedOrders = BD_Orders.SelectedItem as Orders;
            if (selectedOrders != null)
            {
                orders.Orders.Remove(selectedOrders);
                orders.SaveChanges();
                BD_Orders.ItemsSource = orders.Orders.ToList();
            }
        }

        private void BD_Orders_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (BD_Orders.SelectedItem != null)
            {
                var selected = BD_Orders.SelectedItem as Orders;

                text1.Text = selected.Customer_ID.ToString();
                text2.Text = selected.Vehicle_ID.ToString();
                text3.Text = selected.OrderDate.ToString();
                text4.Text = selected.Amount.ToString();

                orders.SaveChanges();
                BD_Orders.ItemsSource = orders.Orders.ToList();
            }
        }
    }
}