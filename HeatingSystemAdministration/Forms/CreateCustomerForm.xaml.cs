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
        public CreateCustomerForm()
        {
            InitializeComponent();
        }

        private void btnNewCustomerSave_Click(object sender, RoutedEventArgs e)
        {
            String name = newCustomerName.Text;
            String address = newCustomerAddress.Text;
            int number = Storage.DatabaseDummy.customers.Max(c => c.Id);

            Customer newCustomer = new Customer { Id = number+1, Name = name, Address = address, Meters = new List<Model.Meter>() };
            Service.Service.AddCustomer(newCustomer);
            this.Close();
        }

     
    }
}
