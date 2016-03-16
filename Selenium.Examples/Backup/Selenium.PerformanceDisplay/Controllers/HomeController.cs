using System;
using System.IO;
using System.Text;
using System.Web.Mvc;
using System.Xml;
using Selenium.PerformanceDisplay.Models;

namespace Selenium.PerformanceDisplay.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            StringBuilder chartData = new StringBuilder("t:");

            StringBuilder chartLabels = new StringBuilder("0:|");

            double largestValue = 0;

            // Get the chart data
            string fileName = @"C:\Performance\";
            DirectoryInfo directoryInfo = new DirectoryInfo(fileName);
            FileInfo[] fileInfos = directoryInfo.GetFiles("*.xml");
            foreach (FileInfo fileInfo in fileInfos)
            {
                // Load the xml document
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(fileInfo.FullName);

                XmlNode pageFullyLoadedTimeNode = xmlDocument.SelectSingleNode("//Performance/PageFullyLoadedTime");
                string pageFullyLoadedTime = pageFullyLoadedTimeNode != null ? pageFullyLoadedTimeNode.InnerText : string.Empty;

                // Append the records to the chart datat
                var scaling = Convert.ToInt64(pageFullyLoadedTime);

                if (scaling > largestValue)
                {
                    largestValue = scaling + 20;
                }

                chartData.Append(scaling);
                chartData.Append(",");

                // Build the chart label
                DateTime filedate = new DateTime(Convert.ToInt64(Path.GetFileNameWithoutExtension(fileInfo.FullName)));

                chartLabels.Append(filedate.ToShortDateString());
                chartLabels.Append("|");
            }

            Performance performance = new Performance { LargestValue = largestValue.ToString() };

            if (chartData.ToString().Length > 0)
            {
                performance.FullyLoadedTimeData = chartData.Remove(chartData.ToString().Length - 1, 1).ToString();
                performance.ChartLabels = chartLabels.ToString();
            }

            return View(performance);
        }
    }
}
