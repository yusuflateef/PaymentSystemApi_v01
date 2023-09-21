using PaymentSystemApi_v01.Core;
using PaymentSystemApi_v01.DTO;

namespace PaymentSystemApi_v01.Contracts
{
    public interface ICustomerService
    {
        Task<(bool successful, bool fail)> Customer(CustomerRequest input);

        Task<(bool successful, IEnumerable<CustomerDto> customers, bool fail)> Customers();
        Task<(bool successful, CustomerDto customer, bool fail)> CustomerById(string id);

        Task<(bool successful, IEnumerable<TransactionHistoryDto> transaction, bool fail)> TransactionHistory();
        Task<(bool successful, IEnumerable<TransactionHistoryDto> transaction, bool fail)> TransactionHistory(string CustomerId);

    }
}
