using FunnyNails.Models;
using FunnyNails.Models.Employee;
using System;
using System.Linq;

namespace FunnyNails.Data
{
    public class CurWageDbInitaiizer
    {
        public static void CurWageInitaiizer(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.CurWageMgmt.Any())
            {
                return;
            }

            var curwage = new CurWageMgmt[]
            {
                new CurWageMgmt{CurWage=15.00M}
            };
            foreach (CurWageMgmt c in curwage)
            {
                context.CurWageMgmt.Add(c);
            }
            context.SaveChanges();
        }
    }
}
