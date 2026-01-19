using Demo_2025_EF.Models;
using Microsoft.EntityFrameworkCore;
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
    /// Логика взаимодействия для CalcWindow.xaml
    /// </summary>
    public partial class CalcWindow : Window
    {
        DemoContext db = new DemoContext();
        public CalcWindow()
        {
            InitializeComponent();

            ListProduct.ItemsSource = db.Products.ToList();
            ListMaterial.ItemsSource = db.Materials.ToList();

        }

        private void ListProduct_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var p = db.
                Products.
                Include(t => t.ProductType).
                FirstOrDefault
                (p => p.ProductId == Convert.ToInt32(ListProduct.SelectedValue));
            txtSize.Text = p.Size.ToString();

            txtKoef.Text = p.ProductType.TypeCoefficient.ToString();
        }
    }
}
