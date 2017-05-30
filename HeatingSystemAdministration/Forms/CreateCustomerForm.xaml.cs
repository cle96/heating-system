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

namespace HeatingSystemAdministration.Forms
{
    /// <summary>
    /// Interaction logic for CreateCustomerForm.xaml
    /// </summary>
    public partial class CreateCustomerForm : Window
    {
        Storage.StorageContext db = new Storage.StorageContext();

        public CreateCustomerForm(Customer customer)
        {
            InitializeComponent();
            this.DataContext = customer;
        }

        private void btnNewCustomerSave_Click(object sender, RoutedEventArgs e)
        {
            Customer customer = this.DataContext as Customer;
            Console.WriteLine(customer.Id);

            if (customer.Name == "" || customer.Address == "")
                MessageBox.Show("Name or address can't be null", "Error while saving", MessageBoxButton.OK);
            else
            {
                if (customer.Id == 0)
                    createNewCustomer(customer);

                this.Close();
            }
        }

        private void createNewCustomer(Customer c)
        {
            int number = db.Customers.Max(customer => customer.Id);
            Customer newCustomer = new Customer { Id = number + 1, Name = c.Name, Address = c.Address, Meters = new List<Meter>() };
            Service.Service.AddCustomer(newCustomer);
        }
     
    }
}
