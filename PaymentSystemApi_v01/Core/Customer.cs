using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PaymentSystemApi_v01.Core
{

    [Table("Customers")]
    public class Customer: AuditableEntity
    {
        [Required]
        public string NationalId { get; set; } = string.Empty;
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Surname { get; set; } = string.Empty;
        [Required]
        public string CustomerNumber { get; set; } = string.Empty;
        [Required]
        public DateTime DateOfBirth { get; set; } = DateTime.Now;
        public virtual ICollection<TransactionHistory >? TransactionHistory { get; set; }
    } 
}
