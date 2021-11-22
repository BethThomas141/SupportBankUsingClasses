using System;
using System.Collections.Generic;

namespace SupportBankUsingClasses
{
    public class Person
    {
        public string name;
        public double balance;
        public List<string> transactions;
        
        public Person(string name)
        {
            this.name = name;
            this.balance = 0;
            this.transactions = new List<string>();
        }

        public void oweStatement()
        {
            if (this.balance < 0)
            {
                Console.WriteLine($"{this.name} owes £{Math.Round(-1*this.balance,2)}");
            }
            else
            {
                Console.WriteLine($"{this.name} is owed £{Math.Round(this.balance,2)}");
            }
        }

        public void printTransactions()
        {
            foreach (var item in this.transactions)
            {
                Console.WriteLine(item);
            }
               
        }
        
        
    }
}