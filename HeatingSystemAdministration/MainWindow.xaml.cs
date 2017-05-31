using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using HeatingSystemModel.Model;
using HeatingSystemModel.Storage;
using System.Drawing;

namespace HeatingSystemAdministration
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Customer> customers = null;

        public MainWindow()
        {
            InitializeComponent();
            //Service.Service.InitStorage();
            RefreshCustomerList();
            CustomersListBox.DisplayMemberPath = "Name";
            MetersListBox.DisplayMemberPath = "Id";
        }

        private void CustomersListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var customer = (Customer)CustomersListBox.SelectedItem;
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
            var customer = (Customer)CustomersListBox.SelectedItem;
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
            var customer = (Customer)CustomersListBox.SelectedItem;
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
                    Service.Service.EnableReadingsForYear(Convert.ToInt32(yearFromTextBox));
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
            using (var db = new StorageContext())
            {
                customers = db.Customers.OrderBy(c => c.Id).ToList();
                CustomersListBox.ItemsSource = customers;
            }
        }

        private void RefreshMetersList(int customerId)
        {
            using (var db = new StorageContext())
            {
                MetersListBox.ItemsSource = db.Meters.Where(m => m.Customer.Id == customerId).ToList();
            }
        }

        private void RefreshMeterReadingsList()
        {
            var meter = (Meter)MetersListBox.SelectedItem;
            if (meter != null)
            {
                using (var db = new StorageContext())
                {
                    MetersReadingsListBox.Items.Clear();
                    List<MeterReading> meterReadings = db.MeterReadings.Where(mr => mr.Meter.Id == meter.Id).OrderByDescending(m => m.Year).ToList();
                    meterReadings.ForEach(mr =>{ MetersReadingsListBox.Items.Add(new ListBoxItem() {Content=mr,Background = mr.isEnabled? new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.LightGreen): new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.LightSalmon) }); });
                }
            }
        }
    }
}
