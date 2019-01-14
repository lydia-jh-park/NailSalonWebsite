using FunnyNails.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FunnyNails.Data
{
    public class CreditDbInitializer
    {
        public static void CreditInitializer(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.CustomerMgmt.Any())
            {
                return;
            }

            var credits = new CustomerMgmt[]
            {
                new CustomerMgmt{Credits=0.00M}
            };
            foreach (CustomerMgmt c in credits)
            {
                context.CustomerMgmt.Add(c);
            }
            context.SaveChanges();
        }
    }
}
