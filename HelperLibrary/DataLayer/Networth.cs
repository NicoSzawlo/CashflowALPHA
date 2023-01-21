﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace HelperLibrary.DataLayer
{

    //Model for calculating the networth trend
    public class Networth
    {
        public DateTime? Date { get; set; }
        public decimal Capital { get; set; }


        public static List<Networth> CalculateOverallNetworth()
        {
            List<Networth> DateList = new List<Networth>();

            List<Transaction> TrxList = Transaction.GetObjectListDb();
            if(TrxList.Count > 0) 
            { 
                //Initiating List of Dates from first in DB to NOW
                for (DateTime date = (DateTime)TrxList[0].Date; date <= DateTime.Now; date = date.AddDays(1))
                {
                    DateList.Add( new Networth { Date = date});
                }

                //Get current liquid networth
                DateList[DateList.Count - 1].Capital = Account.GetNetworth();

                //Calculate networth from transactions
                for(int i = DateList.Count-1; i >= 0; i--)
                {
                    if (i < DateList.Count - 1)
                    {
                        DateList[i].Capital = DateList[i + 1].Capital;
                    }
                
                    foreach (Transaction transaction in TrxList)
                    {
                        if (DateList[i].Date == transaction.Date)
                        {
                            DateList[i].Capital -= (decimal)transaction.Amount;
                        }

                    }
                }
            }
            return DateList;

        }

        public static DateTime GetFirstOfCurrentYear(List<Networth> networthList)
        {
            DateTime today = DateTime.Now;
            DateTime firstDayOfYear = new DateTime();
            DateTime listitem = new DateTime();
            decimal high = 0;
            for(int i = networthList.Count-1; i >= 0; i--)
            {
                listitem = (DateTime)networthList[i].Date;
                
                if (listitem.Year < today.Year)
                {
                    firstDayOfYear = (DateTime)networthList[i + 1].Date;
                    break;
                }
            }

            return firstDayOfYear;
        }

        public static double GetMaxFromSpan(List<Networth> networthList, DateTime start)
        {
            decimal max = 0;
            double dmax = 0;
            for(int i = networthList.Count-1; i >= 0; i--)
            {
                if(networthList[i].Date > start)
                {
                    if (networthList[i].Capital > max)
                    {
                        max = networthList[i].Capital;
                    }
                }
            }
            dmax = Convert.ToDouble(max);
            return dmax;
        }

    }
}
