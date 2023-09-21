using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PaymentSystemApi_v01.Core
{
    [Table("Marchants")]
    [Index(nameof(MarchantNumber), IsUnique = true)]

    public class Marchant:AuditableEntity
    {

        [Required]
        public string BusinessId { get; set; } = string.Empty;
        [Required]
        public string BusinessName { get; set; } = string.Empty;
        [Required]
        public string ContactName { get; set; } = string.Empty;
        [Required]
        public string ContactSurname { get; set; } = string.Empty;
        [Required]
        public string MarchantNumber { get; set; } = string.Empty;
        public double? AverageTransactionVolume { get; set; } 
    }
}
