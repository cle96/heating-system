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

namespace HeatingSystemAdministration
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Service.Service.InitStorage();
            //Storage.DatabaseDummy.GetCustomers().ForEach(c => Console.WriteLine(c.toString()));
            //Storage.DatabaseDummy.GetMeters().ForEach(m => Console.WriteLine(m.toString()));
            //Console.Read();
            CustomersListBox.ItemsSource = Storage.DatabaseDummy.customers;
            CustomersListBox.DisplayMemberPath = "Name";
        }

        private void CustomersListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            MetersListBox.ItemsSource = Storage.DatabaseDummy.meters.FindAll(m => m.Customer == CustomersListBox.SelectedItem);
        }

        private void BtnCreateCustomer_Click(object sender, RoutedEventArgs e)
        {
            //Product product = (Product)lBoxProducts.SelectedItem;
           // if (product != null)
              //  MessageBox.Show("SelectedItem: type=" + product.GetType() + "\n" + product);
           // else
                //MessageBox.Show("SelectedItem: null");
        }

        private void BtnCreateMeter_Click(object sender, RoutedEventArgs e)
        {
            //Product product = (Product)lBoxProducts.SelectedItem;
            // if (product != null)
            //  MessageBox.Show("SelectedItem: type=" + product.GetType() + "\n" + product);
            // else
            //MessageBox.Show("SelectedItem: null");
        }
    }
}
