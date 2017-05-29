using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        ObservableCollection<Customer> customers = null;

        public MainWindow()
        {
            InitializeComponent();

            Service.Service.InitStorage();
            customers = new ObservableCollection<Customer>(Storage.DatabaseDummy.customers);
            CustomersListBox.ItemsSource = customers;
            CustomersListBox.DisplayMemberPath = "Name";
        }

        private void CustomersListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<Model.MeterReading> metersReadings = Storage.DatabaseDummy.metersReadings.FindAll(mr => mr.Meter.Customer == CustomersListBox.SelectedItem);
            MetersListBox.ItemsSource = metersReadings;

        }

        private void BtnCreateCustomer_Click(object sender, RoutedEventArgs e)
        {
            Forms.CreateCustomerForm cw = new Forms.CreateCustomerForm();
            cw.Closing += new System.ComponentModel.CancelEventHandler(RefreshList);
            cw.Show();
        }

        private void BtnCreateMeter_Click(object sender, RoutedEventArgs e)
        {
  
        }

        private void RefreshList(object sender, EventArgs e)
        {
            //Storage.DatabaseDummy.customers.ForEach(c => Console.WriteLine(c));
            customers = new ObservableCollection<Customer>(Storage.DatabaseDummy.customers);
            CustomersListBox.ItemsSource = customers;
        
        }
    }
}
