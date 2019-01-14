using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using FunnyNails.Models;

namespace FunnyNails.Models.Customer
{
    public class SalesMgmt
    {
        [Key]
        public int SalesID { get; set; }

        [DataType(DataType.Date)]
        public DateTime PurchaseDate { get; set; }
        
        public string Item { get; set; }

        public decimal Cost { get; set; }

        public decimal Discount { get; set; }

        [Display(Name = "Sales Remark")]
        public string SalesRemark { get; set; }
    }
}
