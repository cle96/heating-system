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
using HeatingSystemModel;
using HeatingSystemModel.Model;
using HeatingSystemModel.Storage;

namespace HeatingSystemAdministration
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Customer> customers = null;
        StorageContext db = new StorageContext();

        public MainWindow()
        {
            InitializeComponent();
            Service.Service.InitStorage();
            RefreshCustomerList();
            CustomersListBox.DisplayMemberPath = "Name";
            MetersListBox.DisplayMemberPath = "Id";
        }

        private void CustomersListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var customer = (Customer) CustomersListBox.SelectedItem;
            if (customer != null)
            {
                RefreshMetersList(customer.Id);
            }
        }

        private void MetersListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshMeterReadingsList();
        }

        private void BtnCreateCustomer_Click(object sender, RoutedEventArgs e)
        {
            Forms.CreateCustomerForm cw = new Forms.CreateCustomerForm(new Customer());
            cw.Closed += new EventHandler(RefreshCustomerListEvent);
            cw.ShowDialog();
        }


        private void BtnEditCustomer_Click(object sender, RoutedEventArgs e)
        {
            var customer = (Customer) CustomersListBox.SelectedItem;
            if (customer != null)
            {
                Forms.CreateCustomerForm cw = new Forms.CreateCustomerForm(customer);
                cw.Closed += new EventHandler(RefreshCustomerListEvent);
                cw.ShowDialog();
            }
        }

        private void BtnDeleteCustomer_Click(object sender, RoutedEventArgs e)
        {
            var customer = (Customer)CustomersListBox.SelectedItem;
            if (customer != null)
            {
                Service.Service.DeleteCustomer(customer.Id);
                RefreshCustomerList(); RefreshMetersList(customer.Id);
            }
        }

        private void BtnCreateMeter_Click(object sender, RoutedEventArgs e)
        {
            var customer = (Customer) CustomersListBox.SelectedItem;
            if (customer != null)
            {
                Service.Service.CreateMeter(customer.Id);
                RefreshMetersList(customer.Id);
            }

        }

        private void BtnEnableReadings_Click(object sender, RoutedEventArgs e)
        {
            var yearFromTextBox = YearForEnabling.Text;
            try
            {
                if (yearFromTextBox != null)
                {
                    int year = Convert.ToInt32(yearFromTextBox);
                    DateTime newYearDate = new DateTime(year, 1, 1);
                    db.Meters.Where(m => m.MeterReadings.Where(mr => mr.Year.Year == year).Count() == 0).ToList().ForEach(m =>
                    {
                        Service.Service.CreateMeterReading(m.Id,newYearDate);
                    });

                    RefreshMeterReadingsList();
                }
            }
            catch
            {
                MessageBox.Show("The field must contain a valid year!", "Error while saving", MessageBoxButton.OK);
            }

        }

        private void BtnDisplayStatistics_Click(object sender, RoutedEventArgs e)
        {
            var yearFromTextBox = YearForEnabling.Text;
            try
            {
                    int year = Convert.ToInt32(yearFromTextBox);
                    Forms.Statistics statistics = new Forms.Statistics(year);
                    statistics.ShowDialog();
            }
            catch
            {
               MessageBox.Show("The field must contain a valid year!", "Error while saving", MessageBoxButton.OK);
            }
        }

        //-----------------------------------List refreshers----------------------------
        private void RefreshCustomerListEvent(object sender, EventArgs e)
        {
            RefreshCustomerList();
        }

        private void RefreshCustomerList()
        {
            customers = db.Customers.OrderBy(c => c.Id).ToList();
            CustomersListBox.ItemsSource = customers;
        }

        private void RefreshMetersList(int customerId)
        {
            MetersListBox.ItemsSource = db.Meters.Where(m => m.Customer.Id == customerId).ToList();
        }

        private void RefreshMeterReadingsList()
        {
            var meter = (Meter)MetersListBox.SelectedItem;
            if (meter != null)
            {
                MetersReadingsListBox.ItemsSource = db.MeterReadings.Where(mr => mr.Meter.Id == meter.Id).ToList();
            }
        }
    }
}
