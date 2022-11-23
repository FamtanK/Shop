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
using Shop.ADOApp;

namespace Shop.PageApp
{
    /// <summary>
    /// Interaction logic for BusketPage.xaml
    /// </summary>
    public partial class BusketPage : Page
    {
        public BusketPage(int IdUser)
        {
            InitializeComponent();
            lvProducts.ItemsSource = App.Connection.Product.ToList();
            var lst = App.Connection.Busket.Where(x => x.IdUser == IdUser).ToList();
            var 
            foreach(var product in lst)
            {
                lvBusket.ItemsSource.A product.Product;
            }
            this.IdUser = IdUser;
        }

        public int IdUser { get; set; }

        private void lvProducts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var product = lvProducts.SelectedItem as Product;
                if (product != null)
                {
                    App.Connection.Busket.Add(new Busket()
                    {
                        IdProduct = product.IdProduct,
                        IdUser = IdUser
                    });
                }
                App.Connection.SaveChanges();
                lvBusket.ItemsSource = App.Connection.Busket.Where(x => x.IdUser == IdUser).ToList();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
