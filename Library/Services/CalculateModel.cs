using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public class CalculateModel
    {
        public CalculateModel(int limit, double penaltyFee, string currency)
        {
            _limit = limit;
            _penaltyFee = penaltyFee;
            Currency = currency;
        }

        private int _limit;
        private double _penaltyFee;
        public int TotalDayCount { get; set; }
        public int DayCountPenaltied { get { return TotalDayCount - _limit > 0 ? TotalDayCount - _limit : 0; } }
        public double PenaltyPayment { get { return DayCountPenaltied > 0 ? _penaltyFee * DayCountPenaltied : 0; } }
        public string Currency { get; private set; }
    }
}
