using System.ComponentModel.DataAnnotations;

namespace Invoice_Management.Models
{
    public class InvoiceDbo
    {
        [Required]
        public string Number { get; set; } = "";
        [Required]
        public string status { get; set; } = "";
        public DateTime? IssueDate { get; set; }
        public DateTime? DueDate { get; set; }



        [Required]
        public string Services { get; set; } = "";
        [Required,Display(Name ="Unit Price")]
        public decimal UnitPrice { get; set; }
        [Required]
        public int Quantity { get; set; }



        [Required,Display(Name ="Client Name")]
        public string CustomerName { get; set; } = "";
        [Required,EmailAddress]
        public string Email { get; set; } = "";
        [Required,Phone]
        public string Phone { get; set; } = "";
        public string Address { get; set; } = "";
    }
}
