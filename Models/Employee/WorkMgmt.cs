using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FunnyNails.Models.Employee
{
    public class WorkMgmt
    {
        [Key]
        public int WorkID { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        [Display(Name = "Work Day")]
        public DateTime WorkDay { get; set; }

        [DataType(DataType.Time)]
        [Display(Name = "Start Time")]
        public DateTime WorkStart { get; set; }

        [DataType(DataType.Time)]
        [Display(Name = "End Time")]
        public DateTime WorkEnd { get; set; }
    }
}
