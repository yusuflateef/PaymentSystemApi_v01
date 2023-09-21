using System.ComponentModel.DataAnnotations.Schema;

namespace PaymentSystemApi_v01.Core
{
    public class TransactionHistory:AuditableEntity
    {
        public DateTime CreationDate { get; set; }
        [ForeignKey("CustormId")]
        public Customer Customer { get; set; } = new ();
        public string CustormId { get; set; } = string.Empty;
    }
}
