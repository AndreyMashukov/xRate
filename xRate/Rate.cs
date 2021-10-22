using System;

namespace xRate
{
    public class Rate
    {
        public string Ticker { get; }

        public double Value { get; } 

        public DateTime Date { get; }

        public Rate(string ticker, double value, DateTime date)
        {
            this.Ticker = ticker;
            this.Value = value;
            this.Date = date;
        }
    }
}