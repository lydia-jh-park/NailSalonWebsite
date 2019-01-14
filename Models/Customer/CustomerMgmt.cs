using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FunnyNails.Models
{
    public class CustomerMgmt
    {
        [Key]
        public int CustomerID { get; set; }

        public decimal Credits { get; set; }
    }
}
