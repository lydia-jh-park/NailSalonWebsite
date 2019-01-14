using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FunnyNails.Models.Employee
{
    public class SalaryMgmt
    {
        [Key]
        public int SalaryID { get; set; }

        public decimal Salary { get; set; }
    }
}
