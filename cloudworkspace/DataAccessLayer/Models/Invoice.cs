using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class Invoice
    {
        public int InvoiceId { get; set; }
        [Required]
        public string ProjectName { get; set; }
        [Required]
        public decimal BilledHours { get; set; }
        [Required]
        [Column(TypeName = "money")]
        public decimal BilledAmount { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [DefaultValue(false)]
        public bool IsPaid { get; set; }
        public PaymentType PaymentType { get; set; }
        [DefaultValue(false)]
        public bool IsArchived { get; set; }
    }

    public enum PaymentType
    {
        Cash = 0,
        Check = 1,
        Card = 2,
        Wired = 3
    }
}
