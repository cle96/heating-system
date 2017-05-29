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
        List<Customer> customers = null;
        Storage.StorageContext db = new Storage.StorageContext();

        public MainWindow()
        {
            InitializeComponent();

            Service.Service.InitStorage();
            //Service.Service.GetCustomers().ForEach(c => Console.WriteLine(c));
            Console.WriteLine(db.Customers.Count());

            customers = db.Customers.OrderBy(c => c.Id).ToList();

            CustomersListBox.ItemsSource = customers;
            CustomersListBox.DisplayMemberPath = "Name";
        }

        private void CustomersListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var customer = (Customer) CustomersListBox.SelectedItem;
            if (customer != null)
            {
                List<Meter> meters = db.Meters.Where(m => m.Customer.Id == customer.Id).ToList();

                MetersListBox.ItemsSource = meters;
                MetersListBox.DisplayMemberPath = "Id";
            }
        }

        private void MetersListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var meter = (Meter) MetersListBox.SelectedItem;
            if (meter != null)
            {
                List<MeterReading> metersReadings = db.MeterReadings.Where(mr => mr.Meter.Id == meter.Id).ToList();
                MetersReadingsListBox.ItemsSource = metersReadings;
            }
        }

        private void BtnCreateCustomer_Click(object sender, RoutedEventArgs e)
        {
            Forms.CreateCustomerForm cw = new Forms.CreateCustomerForm(new Customer());
            cw.Closing += new System.ComponentModel.CancelEventHandler(RefreshList);
            cw.Show();
        }


        private void BtnEditCustomer_Click(object sender, RoutedEventArgs e)
        {
            var customer = (Customer) CustomersListBox.SelectedItem;
            if (customer != null)
            {
                Forms.CreateCustomerForm cw = new Forms.CreateCustomerForm(customer);
                cw.Closing += new System.ComponentModel.CancelEventHandler(RefreshList);
                cw.Show();
            }
        }

        private void BtnDeleteCustomer_Click(object sender, RoutedEventArgs e)
        {
            var customer = (Customer)CustomersListBox.SelectedItem;
            if (customer != null)
            {
                CustomersListBox.ItemsSource = Service.Service.DeleteCustomer(customer.Id).OrderBy(c => c.Id).ToList(); 
            }
        }

        private void BtnCreateMeter_Click(object sender, RoutedEventArgs e)
        {
            var customer = (Customer)CustomersListBox.SelectedItem;
            if (customer != null)
            {
                int id = db.Meters.Max(m => m.Id);
                Meter newMeter = new Meter() { Id = id + 1, Customer = customer, MeterReadings = new List<MeterReading>() };
                db.Meters.Add(newMeter);
                db.SaveChanges();

                MetersListBox.ItemsSource = db.Meters.Where(m => m.Customer.Id == customer.Id).ToList();
            }

        }

        private void RefreshList(object sender, EventArgs e)
        {
            //Storage.DatabaseDummy.customers.ForEach(c => Console.WriteLine(c));
            customers = db.Customers.OrderBy(c => c.Id).ToList();
            CustomersListBox.ItemsSource = customers;

        }
    }
}
