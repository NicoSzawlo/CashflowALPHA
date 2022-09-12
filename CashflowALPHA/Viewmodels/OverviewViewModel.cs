using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HelperLibrary;
using HelperLibrary.DataLayer;

namespace CashflowALPHA.Viewmodels
{
    public class OverviewViewModel
    {
        public static async void CalcNetworth()
        {
            await Task.Run(() => Networth.CalculateOverallNetworth());
        }
    }
}
