﻿using System;
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
        public static async void InitNetworthtrend(ScottPlot.FormsPlot plot)
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
            plot.Plot.AddScatterLines(xs,ys, lineWidth:3);
            plot.Plot.XAxis.Label("Date");
            plot.Plot.XAxis.Ticks(true);
            plot.Plot.XAxis.DateTimeFormat(true);
            plot.Plot.Render();
            plot.Refresh();
        }

        public static async void SetNetworthtrendCurrentYear(ScottPlot.FormsPlot plot,DateTimePicker dtpStart, DateTimePicker dtpEnd)
        {

            List<Networth> networthList = await Task.Run(() => Networth.CalculateOverallNetworth());
            DateTime first = Networth.GetFirstOfCurrentYear(networthList);
            DateTime today = DateTime.Now;
            dtpStart.Value = first;
            dtpEnd.Value = today;
            plot.Plot.SetAxisLimitsX(Convert.ToDouble(first.ToOADate()), Convert.ToDouble(today.ToOADate()));
            plot.Refresh();

        }
        public static void SetNetworthtrendCustom(ScottPlot.FormsPlot plot, DateTime start, DateTime end)
        {
            plot.Plot.SetAxisLimitsX(Convert.ToDouble(start.ToOADate()), Convert.ToDouble(end.ToOADate()));
            plot.Refresh();
        }
    }
}
