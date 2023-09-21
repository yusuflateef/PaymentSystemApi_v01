namespace PaymentSystemApi_v01.Core
{
    public class AuditableEntity
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        
    }
}
