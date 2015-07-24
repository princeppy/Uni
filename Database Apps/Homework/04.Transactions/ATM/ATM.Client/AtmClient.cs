using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AtmNamespace.Data;
using System.Transactions;
using News.Models;

namespace AtmClient
{
    class AtmClient
    {
        static void Main(string[] args)
        {
            // Create the DB. I Decided to use code first.
            GenerateDatabase();

            // There is no need of repeatble read isolation level
            var scope = new TransactionScope();
            //Optional parameters for the transaction:
            //TransactionScopeOption.Required, new TransactionOptions(){IsolationLevel = });

            MakeAWithdraw(scope);
        }

        private static void MakeAWithdraw(TransactionScope scope)
        {
            try
            {
                using (scope)
                {
                    Console.WriteLine("Enter your card number:");
                    var cardNumberEntered = Console.ReadLine();

                    Console.WriteLine("Enter your PIN number:");
                    var pinEntered = "";

                    pinEntered = MaskPinOnConsole(pinEntered);


                    Console.WriteLine("\nEnter the sum you want to withdrawl");
                    var sumToWithdraw = decimal.Parse(Console.ReadLine());


                    using (var ctx = new AtmEntities())
                    {
                        var cardNumber = ctx.Accounts.FirstOrDefault(c => c.CardNumber == cardNumberEntered);

                        if (cardNumber == null || cardNumber.CardPin != pinEntered)
                        {
                            throw new InvalidDataException();
                        }
                        if (sumToWithdraw > cardNumber.Money)
                        {
                            throw new ArgumentOutOfRangeException();
                        }

                        cardNumber.Money -= sumToWithdraw;
                        var dateOfWithdraw = DateTime.Now;
                        Console.WriteLine(
                            "You have successfully withdrawed ${0}\nYour remaining sum is: ${1}",
                            sumToWithdraw,
                            cardNumber.Money
                            );

                        var historyData = ctx.TransactionHistory;

                        historyData.Add(new TransactionData()
                        {
                            CardNumber = cardNumberEntered,
                            TransactionDate = dateOfWithdraw,
                            Money = cardNumber.Money

                        });

                        ctx.SaveChanges();

                        scope.Complete();
                    }
                }
            }
            catch (InvalidDataException ide)
            {
                Console.WriteLine("The card number is not valid or the pin code is wrong");
            }
            catch (ArgumentOutOfRangeException aore)
            {
                Console.WriteLine("There is not enough money in the account. You cheater! Go to jail :D");
            }
        }

        private static string MaskPinOnConsole(string pinEntered)
        {
            ConsoleKeyInfo key;

            do
            {
                key = Console.ReadKey(true);

                if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                {
                    pinEntered += key.KeyChar;
                    Console.Write("*");
                }
                else
                {
                    if (key.Key == ConsoleKey.Backspace && pinEntered.Length > 0)
                    {
                        pinEntered = pinEntered.Substring(0, (pinEntered.Length - 1));
                        Console.Write("\b \b");
                    }
                }
            }
                // Stops receving keys once Enter is pressed
            while (key.Key != ConsoleKey.Enter);
            return pinEntered;
        }

        private static void GenerateDatabase()
        {
            var ctx = new AtmEntities();
            var news = ctx.Accounts.ToList();
        }


    }
}
