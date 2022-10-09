using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelperLibrary;
using HelperLibrary.DataLayer;
using ScottPlot;

namespace CashflowALPHA.Viewmodels
{
    public class OverviewViewModel
    {
        public static async void LoadNetworthtrend(ScottPlot.FormsPlot plot)
        {
            List<Networth> networthList = await Task.Run(() => Networth.CalculateOverallNetworth());
            DateTime[] dates = new DateTime[networthList.Count];
            decimal[] capital = new decimal[networthList.Count];
            for (int i = 0; i < networthList.Count; i++)
            {
                capital[i] = networthList[i].Capital;
                dates[i] = (DateTime)networthList[i].Date;
            }
            double[] xs = dates.Select(x => x.ToOADate()).ToArray();
            double[] ys = capital.Select(x => Convert.ToDouble(x)).ToArray();
            plot.Plot.AddScatterLines(xs,ys);
            plot.Plot.XAxis.Label("Date");
            plot.Plot.XAxis.Ticks(true);
            plot.Plot.XAxis.DateTimeFormat(true);
            plot.Refresh();
            plot.Plot.Render();
        }

        public static void SetNetworthtrendLimits(ScottPlot.FormsPlot plot)
        {
            
        }
    }
}
