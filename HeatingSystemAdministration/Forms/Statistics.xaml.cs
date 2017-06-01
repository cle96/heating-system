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
using HeatingSystemModel.Storage;
using HeatingSystemModel.Service;
namespace HeatingSystemAdministration.Forms
{
    /// <summary>
    /// Interaction logic for Statistics.xaml
    /// </summary>
    public partial class Statistics : Window
    {
        StorageContext db = new StorageContext();

        public Statistics(int year)
        {
            InitializeComponent();
            setTotalConsumptionForYear(year);
            setMoneySpentForYear(year);
            setPercentageForCooling(year);
        }
        public void setTotalConsumptionForYear(int year)
        {
            var meterReadings = Service.GetMeterReadingsForYear(year);
            double totalConsumption = meterReadings.Sum(mr => mr.kWh);
            lblTotalConsumption.Content = "Total consumption for year " + year + " is: " + totalConsumption +"kWh";
        }
        public void setMoneySpentForYear(int year)
        {
            var meterReadings = Service.GetMeterReadingsForYear(year);
            double moneySpent = meterReadings.Sum(mr => mr.calculatePrice());
            lblMoneySpent.Content = "Money spent for year " + year + " is: " + moneySpent + "kr.";
        }

        public void setPercentageForCooling(int year)
        {
            int coolingSufficientMetersCount = Service.GetMeterReadingsForYear(year).Where(mr => mr.CoolingIsSufficient()).Select(mr=> mr.Id).Distinct().ToList().Count();
            int allMetersCount = Service.GetMeterReadingsForYear(year).Select(mr => mr.Id).Distinct().ToList().Count();
            var percentage = ((double)coolingSufficientMetersCount / allMetersCount) * 100;

            lblPercentage.Content = Convert.ToInt32(Math.Round(percentage, 0)) + "% have sufficient cooling ";
        }
    }
}
