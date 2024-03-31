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
    /// Логика взаимодействия для BrandsPageBD.xaml
    /// </summary>
    public partial class BrandsPageBD : Page
    {
        private DealershipEntities brands = new DealershipEntities();
        public BrandsPageBD()
        {
            InitializeComponent();
            BD_Brands.ItemsSource = brands.Brands.ToList();
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            Brands b = new Brands();
            b.BrandName = text1.Text;

            brands.Brands.Add(b);
            brands.SaveChanges();
            BD_Brands.ItemsSource = brands.Brands.ToList();
        }

        private void edit_Click(object sender, RoutedEventArgs e)
        {
            if (BD_Brands.SelectedItem != null)
            {
                var selected = BD_Brands.SelectedItem as Brands;

                selected.BrandName = text1.Text;

                brands.SaveChanges();
                BD_Brands.ItemsSource = brands.Brands.ToList();
            }
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            var selectedBrands = BD_Brands.SelectedItem as Brands;
            if (selectedBrands != null)
            {
                brands.Brands.Remove(selectedBrands);
                brands.SaveChanges();
                BD_Brands.ItemsSource = brands.Brands.ToList();
            }
        }

        private void BD_Brands_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ( BD_Brands.SelectedItem != null)
            {
                var selected = BD_Brands.SelectedItem as Brands;
                
                text1.Text = selected.BrandName;

                brands.SaveChanges();
                BD_Brands.ItemsSource = brands.Brands.ToList();
            }
        }
    }
}