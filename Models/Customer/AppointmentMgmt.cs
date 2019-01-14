using FunnyNails.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FunnyNails.Models.Customer
{
    public class AppointmentMgmt
    {
        [Key]
        public int AppointmentID { get; set; }

        [Display(Name = "Appointment Date")]
        public DateTime AppointmentDate { get; set; }

        [Display(Name ="Employee Name")]
        public string EmpName { get; set; }

        //public void PopulateDepartmentsDropDownList(ApplicationDbContext _context,
        //    object selectedDepartment = null)
        //{
        //    var w = from e in _context.ApplicationUser
        //            orderby e.RegisterType
        //            select e;
        //    if (w == "Employee")
        //    {
        //        var departmentsQuery = from d in _context.
        //                               orderby d.Name
        //                               select d;
        //    }

        //        DepartmentNameSL = new SelectList(departmentsQuery.AsNoTracking(),
        //    "DepartmentID", "Name", selectedDepartment);
        //}

        public int Rating { get; set; }
    }
}
