using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using FunnyNails.Models;
using FunnyNails.Models.Customer;
using FunnyNails.Models.Employee;

namespace FunnyNails.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public ApplicationDbContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<FunnyNails.Models.ApplicationUser> ApplicationUser { get; set; }

        public DbSet<FunnyNails.Models.Customer.AppointmentMgmt> AppointmentMgmt { get; set; }

        public DbSet<FunnyNails.Models.CustomerMgmt> CustomerMgmt { get; set; }

        public DbSet<FunnyNails.Models.Customer.SalesMgmt> SalesMgmt { get; set; }

        public DbSet<FunnyNails.Models.Employee.CurWageMgmt> CurWageMgmt { get; set; }

        public DbSet<FunnyNails.Models.Employee.WorkMgmt> WorkMgmt { get; set; }

        public DbSet<FunnyNails.Models.Employee.SalaryMgmt> SalaryMgmt { get; set; }
        public object Applicationuser { get; internal set; }
    }
}
