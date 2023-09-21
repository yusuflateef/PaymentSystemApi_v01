using System.ComponentModel.DataAnnotations;

namespace PaymentSystemApi_v01.DTO
{
    public class MarchantDto
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
        public string? AverageTransactionVolume { get; set; } = string.Empty;
    }
}
