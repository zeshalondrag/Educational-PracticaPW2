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
    /// Логика взаимодействия для ModelsPageBD.xaml
    /// </summary>
    public partial class ModelsPageBD : Page
    {
        private DealershipEntities models = new DealershipEntities();
        public ModelsPageBD()
        {
            InitializeComponent();
            BD_Models.ItemsSource = models.Models.ToList();
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            Models m = new Models();
            m.ModelName = text1.Text;

            models.Models.Add(m);
            models.SaveChanges();
            BD_Models.ItemsSource = models.Models.ToList();
        }

        private void edit_Click(object sender, RoutedEventArgs e)
        {
            if (BD_Models.SelectedItem != null)
            {
                var selected = BD_Models.SelectedItem as Models;

                selected.ModelName = text1.Text;

                models.SaveChanges();
                BD_Models.ItemsSource = models.Models.ToList();
            }
        }

        private void delete_Click(object sender, RoutedEventArgs e)
        {
            var selectedModels = BD_Models.SelectedItem as Models;
            if(selectedModels != null)
            {
                models.Models.Remove(selectedModels);
                models.SaveChanges();
                BD_Models.ItemsSource = models.Models.ToList();
            }
        }

        private void BD_Models_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (BD_Models.SelectedItem != null)
            {
                var selected = BD_Models.SelectedItem as Models;

                text1.Text = selected.ModelName;

                models.SaveChanges();
                BD_Models.ItemsSource = models.Models.ToList();
            }
        }
    }
}