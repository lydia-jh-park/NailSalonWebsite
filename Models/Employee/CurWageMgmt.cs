using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FunnyNails.Models.Employee
{
    public class CurWageMgmt
    {
        [Key]
        public int CurWageID { get; set; }

        [Display(Name = "Current Wage")]
        public decimal CurWage { get; set; } = 7.00M;
    }
}
