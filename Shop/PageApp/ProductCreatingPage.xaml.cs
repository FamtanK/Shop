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
using System.IO;
using Microsoft.Win32;
using Shop.ADOApp;

namespace Shop.PageApp
{
    /// <summary>
    /// Interaction logic for ProductCreatingPage.xaml
    /// </summary>
    public partial class ProductCreatingPage : Page
    {
        public byte[] Data;

        public ProductCreatingPage()
        {
            InitializeComponent();
        }

        private void btnSelect_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                if (ofd.ShowDialog() != null)
                {
                    Data = File.ReadAllBytes(ofd.FileName);
                }

                btnSelect.Background = Brushes.Green;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Только фото");
            }
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            App.Connection.Product.Add(new Product()
            {
                Name = tbName.Text,
                Cost = int.Parse(tbCost.Text),
                Image = Data
            });

            App.Connection.SaveChanges();
        }
    }
}
