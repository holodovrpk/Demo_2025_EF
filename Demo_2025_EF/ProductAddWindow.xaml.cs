using Demo_2025_EF.Models;
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
using System.Windows.Shapes;

namespace Demo_2025_EF
{
    /// <summary>
    /// Логика взаимодействия для ProductAddWindow.xaml
    /// </summary>
    public partial class ProductAddWindow : Window
    {
        DemoContext db = new DemoContext();

        public ProductAddWindow()
        {
            InitializeComponent();
            
            ListType.ItemsSource = db.ProductTypes.ToList();

        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
    }
}
