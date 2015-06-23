using CloudWorkSpace.DAL.DTO.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudWorkSpace.DAL.DTO
{
    public class Invoice
    {
        public int InvoiceId { get; set; }
        [Required]
        public string ProjectName { get; set; }
        [Required]
        public decimal BilledHours { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        public decimal BilledAmount { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
        [DefaultValue(false)]
        public bool IsPaid { get; set; }
        public PaymentType PaymentType { get; set; }
        [DefaultValue(false)]
        public bool IsArchived { get; set; }
    }
}
