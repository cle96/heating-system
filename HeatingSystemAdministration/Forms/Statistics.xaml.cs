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
    /// Interaction logic for Statistics.xaml
    /// </summary>
    public partial class Statistics : Window
    {
        Storage.StorageContext db = new Storage.StorageContext();

        public Statistics(int year)
        {
            InitializeComponent();
            setTotalConsumptionForYear(year);
            setMoneySpentForYear(year);
            setPercentageForCooling(year);
        }
        public void setTotalConsumptionForYear(int year)
        {
            var meterReadings = Service.Service.GetMeterReadings().Where(mr => mr.Year.Year == year);
            double totalConsumption = meterReadings.Sum(mr => mr.kWh);
            lblTotalConsumption.Content = "Total consumption for year " + year + " is: " + totalConsumption +"kWh";
        }
        public void setMoneySpentForYear(int year)
        {
            var meterReadings = Service.Service.GetMeterReadings().Where(mr => mr.Year.Year == year);
            double moneySpent = meterReadings.Sum(mr => mr.calculatePrice());
            lblMoneySpent.Content = "Money spent for year " + year + " is: " + moneySpent + "kr.";
        }

        public void setPercentageForCooling(int year)
        {
            var coolingSufficientMetersCount = Service.Service.GetMeterReadings().Where(mr => mr.Year.Year == year && !mr.CoolingIsSufficient()).Select(mr=> mr.Id).Distinct().ToList().Count();
            var allMetersCount = Service.Service.GetMeterReadings().Where(mr => mr.Year.Year == year).Select(mr => mr.Id).Distinct().ToList().Count();
            var percentage = coolingSufficientMetersCount == 0?0:(coolingSufficientMetersCount / allMetersCount) * 100;

            lblPercentage.Content = percentage + "% have insufficient cooling ";
        }
    }
}
