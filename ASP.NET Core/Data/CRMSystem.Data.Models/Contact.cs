namespace CRMSystem.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using CRMSystem.Data.Common.Models;

    public class Contact : BaseDeletableModel<int>
    {
        [Required]
        public int ContactId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Phone { get; set; }

        public int AccountId { get; set; }

        public Account Account { get; set; }

        public int DealId { get; set; }

        public Deal Deal { get; set; }
    }
}
