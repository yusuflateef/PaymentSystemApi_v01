using Moq;
using PaymentSystemApi_v01.DTO;
using PaymentSystemApi_v01.Contracts;
using PaymentSystemApi_v01.Controllers;
using PaymentSystemApi_v01.Core;

namespace PaymentSystemTest
{
   

    public class  TestCustomer
    {
        [Fact]
        public async Task CustomerByNationalId_ReturnsOkResult()
        {
           
            var nationalId = "1234567890"; // Replace with a valid nationalId
            List<TransactionHistoryDto> transacton = new();
            var expectedTransaction = new TransactionHistoryDto
            {
                // Initialize with expected data for testing
                // Adjust the data to match your expectations
                // ...
                CustormId ="123",
                CreationDate = DateTime.Now,
                Customer = new Customer {
                    Name = "testName",
                    CustomerNumber = "08036266786",
                    DateOfBirth = DateTime.Now, 
                    NationalId = nationalId,    
                       Id = "123", 
                       Surname = "testSurname",
                    TransactionHistory=null ,  
                }
            };
            transacton.Add(expectedTransaction);

            var mockCustomerProvider = new Mock<ICustomerService>();
            mockCustomerProvider.Setup(provider =>  provider.TransactionHistory(nationalId).Result.transaction)
                .Returns((transacton)); 
            // Simulate a successful transaction history

            var controller = new CustomerController(mockCustomerProvider.Object);

            // Act
            var result = await controller.CustomerByNationalId(nationalId);

            // Assert
            var okResult = Assert.IsType<TransactionHistoryDto>(result);
            var response = Assert.IsType<TransactionHistoryDto>(okResult);

            mockCustomerProvider.Verify(provider => provider.TransactionHistory(nationalId), Times.Once);
        }
    
}
}