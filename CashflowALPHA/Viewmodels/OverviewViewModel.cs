using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;
using HelperLibrary;
using HelperLibrary.DataLayer;
using ScottPlot;

namespace CashflowALPHA.Viewmodels
{
    //Dedicated viewmodel to the overview panel
    public class OverviewViewModel
    {
        //NETWORTH TREND
        //##############################################################

        //Initialize networthtrend
        public static async void InitNetworthtrend(ScottPlot.FormsPlot plot)
        {

            //Load instance of the networthtrend list
            List<Networth> networthList = await Task.Run(() => Networth.CalculateOverallNetworth());

            //Check if list empty
            if(networthList.Count > 0)
            {
                //Init arrays for Scottplot
                DateTime[] dates = new DateTime[networthList.Count];
                decimal[] capital = new decimal[networthList.Count];
                
                //Fill arrays with list content
                for (int i = 0; i < networthList.Count; i++)
                {
                    capital[i] = networthList[i].Capital;
                    dates[i] = (DateTime)networthList[i].Date;
                }
                //convert Datetime / decimal array to double array and add to instance of plot
                double[] xs = dates.Select(x => x.ToOADate()).ToArray();
                double[] ys = capital.Select(x => Convert.ToDouble(x)).ToArray();
                plot.Plot.AddScatterLines(xs,ys, lineWidth:3);

                //Settings for display
                plot.Plot.XAxis.Label("Date");
                plot.Plot.XAxis.Ticks(true);
                plot.Plot.XAxis.DateTimeFormat(true);

                //Refresh plot instance
                plot.Plot.Render();
                plot.Refresh();
            }
        }

        //Set default timespan to current year
        public static async void SetNetworthtrendXCurrentYear(ScottPlot.FormsPlot plot,DateTimePicker dtpStart, DateTimePicker dtpEnd)
        {
            //Get networthlist
            List<Networth> networthList = await Task.Run(() => Networth.CalculateOverallNetworth());
            //Check empty
            if (networthList.Count > 0)
            {
                //Set dates
                DateTime first = Networth.GetFirstOfCurrentYear(networthList);
                DateTime today = DateTime.Now;

                //set data into datetimepickers
                dtpStart.Value = first;
                dtpEnd.Value = today;

                //Set data to plot
                plot.Plot.SetAxisLimitsX(Convert.ToDouble(first.ToOADate()), Convert.ToDouble(today.ToOADate()));
                SetNetworthtrendYStandart(plot, networthList, dtpStart.Value);

                //Refresh plot
                plot.Refresh();
            }


        }

        //Set custom timespan
        public static async void SetNetworthtrendXCustom(ScottPlot.FormsPlot plot, DateTime start, DateTime end)
        {
            //Load networthlist
            List<Networth> networthList = await Task.Run(() => Networth.CalculateOverallNetworth());
            //Set custom data
            plot.Plot.SetAxisLimitsX(Convert.ToDouble(start.ToOADate()), Convert.ToDouble(end.ToOADate()));
            SetNetworthtrendYStandart(plot, networthList, start);
            //Refresh plot
            plot.Refresh();
        }

        //Calculate max Y Axis scale depending on timespan
        public static void SetNetworthtrendYStandart(ScottPlot.FormsPlot plot,List<Networth> networthList, DateTime start)
        {

            double max = Networth.GetMaxFromSpan(networthList,start);
            plot.Plot.SetAxisLimitsY(-500, max+500);

        }


        //CATEGORY GRAPH
        //##############################################################
        public static void InitBudgetGraph(ScottPlot.FormsPlot plot, DateTime month)
        {
            //Reset the plot
            plot.Reset();

            //Init lists and arrays for scotplot
            List<Budget> bdgtList = Budget.GetBudgetsForMonth(month);
            double[] budgets = new double[bdgtList.Count];
            double[] positions = new double[bdgtList.Count];
            string[] labels = new string[bdgtList.Count];

            //fill arrays with list content
            for(int i = 0; i < bdgtList.Count; i++)
            {
                budgets[i] = Convert.ToDouble(bdgtList[i].TotalSpending);
                labels[i] = bdgtList[i].TransactionType.Name;
                positions[i] = i;
            }
            //Add bars to the plot
            var bar = plot.Plot.AddBar(budgets,positions);
            //SEt Labels for the plot
            plot.Plot.XTicks(positions, labels);
            //set axis limit
            plot.Plot.SetAxisLimits(yMin: 0);
            //Set values above bars
            bar.ShowValuesAboveBars = true;

            plot.Refresh();
        }
    }
}
