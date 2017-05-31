using System.Collections.Generic;
using System.Linq;
using System.Windows;
using HeatingSystemModel.Model;
using HeatingSystemModel.Storage;

namespace HeatingSystemAdministration.Forms
{
    /// <summary>
    /// Interaction logic for CreateCustomerForm.xaml
    /// </summary>
    public partial class CreateCustomerForm : Window
    {
        StorageContext db = new StorageContext();

        public CreateCustomerForm(Customer customer)
        {
            InitializeComponent();
            this.DataContext = customer;
        }

        private void btnNewCustomerSave_Click(object sender, RoutedEventArgs e)
        {
            Customer customer = this.DataContext as Customer;

            if (customer.Name == "" || customer.Address == "")
                MessageBox.Show("Name or address can't be null", "Error while saving", MessageBoxButton.OK);
            else
            {
                Service.Service.CreateOrUpdateCustomer(customer);

                this.Close();
            }
        }
    }
}
