using PaymentSystemApi_v01.Core;
using System.ComponentModel.DataAnnotations.Schema;

namespace PaymentSystemApi_v01.DTO
{
    public class TransactionHistoryDto
    {

        public DateTime CreationDate { get; set; }

        public Customer Customer { get; set; } = new();
        public string CustormId { get; set; } = string.Empty;
    }
}
