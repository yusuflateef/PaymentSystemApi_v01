using PaymentSystemApi_v01.Core;
using System.ComponentModel.DataAnnotations;

namespace PaymentSystemApi_v01.DTO
{
    public class CustomerDto
    {
        [Required]
        public string NationalId { get; set; } = string.Empty;
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Surname { get; set; } = string.Empty;
        [Required]
        public string CustomerNumber { get; set; } = string.Empty;
        public ICollection<TransactionHistory> TransactionHistory { get; set; } 
        public DateTime DateOfBirth { get; set; } = DateTime.Now;

    }
}
