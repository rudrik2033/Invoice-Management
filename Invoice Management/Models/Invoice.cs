using Microsoft.EntityFrameworkCore;

namespace Invoice_Management.Models
{
    public class Invoice
    {
        public int Id { get; set; }


        public string Number { get; set; } = "";
        public string status { get; set; } = "";
        public DateTime? IssueDate { get; set; }
        public DateTime? DueDate { get; set; }




        public string Services { get; set; } = "";
        [Precision(16, 2)]
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }




        public string CustomerName { get; set; } = "";
        public string Email { get; set; } = "";
        public string Phone { get; set; } = "";
        public string Address { get; set; } = "";
    }
}
