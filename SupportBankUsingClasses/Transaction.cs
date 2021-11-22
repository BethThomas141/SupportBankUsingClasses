using System;

namespace SupportBankUsingClasses
{
    public class Transaction
    {
        public string date;
        public string name1;
        public string name2;
        public string description;
        public double amount;
        public string narrative;
        
        
        public Transaction(string[] row)
        {
            this.date = row[0];
            this.name1 = row[1];
            this.name2 = row[2];
            this.description = row[3];
            this.amount = Convert.ToDouble(row[4]);
            this.narrative = $"{this.name1} owes {this.name2} £{this.amount} for {this.description}";
        }
    }
}