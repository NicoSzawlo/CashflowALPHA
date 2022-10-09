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
        public static async void CalcNetworth(ScottPlot.FormsPlot plot)
        {
            List<Networth> networthList = await Task.Run(() => Networth.CalculateOverallNetworth());
            DateTime[] dates = new DateTime[networthList.Count-1];
            decimal[] capital = new decimal[networthList.Count - 1];
            for (int i = 0; i < networthList.Count; i++)
            {
                capital[i] = networthList[i].Capital;
                dates[i] = (DateTime)networthList[i].Date;
            }
            double[] xs = dates.Select(x => x.ToOADate()).ToArray();
            double[] ys = capital.Select(x => Convert.ToDouble(x)).ToArray();
            plot.Plot.AddScatter(xs, ys);
        }
    }
}
