namespace AtmNamespace.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Collections.Generic;
    using AtmNamespace.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<AtmEntities>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(AtmEntities context)
        {

            if (!context.Accounts.Any())
            {
                Console.WriteLine("DATABASE GENERATED FROM SCRATCH");
                var accountsList = new List<Account>()
                {
                    new Account() {CardNumber = "1111111114",CardPin = "1234",Money = 10000.0m},
                    new Account() {CardNumber = "1111111115",CardPin = "0000",Money = 20000.0m},
                    new Account() {CardNumber = "1111111116",CardPin = "4321",Money = 30000.0m},
                    new Account() {CardNumber = "1111111117",CardPin = "5678",Money = 40000.0m},
                    new Account() {CardNumber = "1111111118",CardPin = "8765",Money = 50000.0m},
                    
                };
                context.Accounts.AddRange(accountsList);

                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("DATABSE ALREADY GENERATED");
            }
        }
    }
}
