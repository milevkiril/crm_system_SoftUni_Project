namespace CRMSystem.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Information
    {
        [Key]
        public int InformationId { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string InvoiceCode { get; set; }

        public Contact Representative { get; set; }
    }
}
