using Arfolyamok.Entities;
using Arfolyamok.MnbServiceReference;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Xml;

namespace Arfolyamok
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            RefreshData();
        }
        private void RefreshData()
        {
            Rates.Clear();
            dataGridView1.DataSource = Rates;
            XMLedit(loading(comboBox1.SelectedValue.ToString(), dateTimePicker1.Value.ToString(), dateTimePicker2.Value.ToString()));
            diagramm();

        }
        private void diagramm()
        {
            ChartRateData.DataSource = Rates;

            var series = ChartRateData.Series[0];
            series.ChartType = SeriesChartType.Line;
            series.XValueMember = "Date";
            series.YValueMembers = "Value";
            

            var legend = ChartRateData.Legends[0];
            legend.Enabled = false;

            series.BorderWidth = 2;
            var chartArea = ChartRateData.ChartAreas[0];
            chartArea.AxisX.MajorGrid.Enabled = false;
            chartArea.AxisY.MajorGrid.Enabled = false;
            chartArea.AxisY.IsStartedFromZero = false;
        }

        private void XMLedit(string result)
        {
            
            var xml = new XmlDocument();
            xml.LoadXml(result);

            foreach (XmlElement element in xml.DocumentElement)
            {
                var rate = new RateData();
                Rates.Add(rate);

                
                rate.Date = DateTime.Parse(element.GetAttribute("date"));

                var childElement = (XmlElement)element.ChildNodes[0];
                rate.Currency = childElement.GetAttribute("curr");

                
                var unit = decimal.Parse(childElement.GetAttribute("unit"));
                var value = decimal.Parse(childElement.InnerText);
                if (unit != 0)
                    rate.Value = value / unit;
            }
        }

        BindingList <RateData> Rates = new BindingList<RateData> ();
        
        
        private string loading(string currency, string startdate, string enddate)
        {

            var mnbService = new MNBArfolyamServiceSoapClient();

            var request = new GetExchangeRatesRequestBody()
            {
                currencyNames = currency,
                startDate = startdate,
                endDate = enddate
            };

            var response = mnbService.GetExchangeRates(request);

           var result = response.GetExchangeRatesResult;

            return result;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshData();
        }


    }

}
