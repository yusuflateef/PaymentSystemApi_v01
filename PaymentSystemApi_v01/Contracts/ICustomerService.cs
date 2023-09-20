using PaymentSystemApi_v01.DTO;

namespace PaymentSystemApi_v01.Contracts
{
    public interface ICustomerService
    {
        Task<(bool successful, bool fail)> Customer(CustomerDto input);

        Task<(bool successful, IEnumerable<CustomerDto> customers, bool fail)> Customers();
        Task<(bool successful, CustomerDto customer, bool fail)> CustomerById(string id);

    }
}
