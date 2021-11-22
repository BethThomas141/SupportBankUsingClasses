using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace SupportBankUsingClasses
{
    class Program
    {
        static void Main(string[] args)
        {
            //storing each line of the csv file in a list called rows

            string[] rows = System.IO.File.ReadAllLines("C:/Work/Training/SupportBankUsingClasses/Transactions2014.csv");

            //creating a list of distinct names involved in transactions
            var nameList  = new List<string>();

            foreach (string row in rows)
            {
                string[] splitRow = row.Split(',');
                if (!nameList.Contains(splitRow[1]))
                {
                    nameList.Add(splitRow[1]);
                }
                if (!nameList.Contains(splitRow[2]))
                {
                    nameList.Add(splitRow[2]);
                }

            }
            
            //creating an empty list of Persons and then filling it with everyone 
            var personList = new List<Person>();
            foreach(var name in nameList)
            {
                Person item = new Person(name);
                personList.Add(item);
            }
            
            //going back through each row of the csv file and assigning attributes to each person
            foreach (string row in rows)
            {
                string[] splitRow = row.Split(',');
                Transaction transaction = new Transaction(splitRow);
                var person1 = personList.Single(p => p.name == transaction.name1);
                var person2 = personList.Single(p => p.name == transaction.name2);
                person1.balance -= transaction.amount;
                person2.balance += transaction.amount;
                person1.transactions.Add(transaction.narrative);
                person2.transactions.Add(transaction.narrative);
            }
            
            //creating interactive component
            var outputString =
                "What would you like to know? Available commands are 'List all' or 'List name'.\nAvailable names are:";
            foreach (var name in nameList)
            {
                outputString += $"\n- {name}";
            }
            Console.WriteLine(outputString);
            string UserInput = Console.ReadLine();
            try
            { 
                if (UserInput.ToLower() == "list all")
                {
                    foreach (Person person in personList)
                    {
                        person.oweStatement();
                    }
                }
                else if (nameList.Contains(UserInput.Remove(0,5)))
                {
                    var PersonOfInterest = personList.Single(p => p.name == UserInput.Remove(0,5));
                    PersonOfInterest.printTransactions();
                
                }
                else
                {
                    Console.WriteLine(
                        "Unrecognised request, if you entered a name perhaps they don't exist on our database. Names are case sensitive.");
                }
                
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine(
                    "Unrecognised request, if you entered a name perhaps they don't exist on our database");
            }


        }
    }
}