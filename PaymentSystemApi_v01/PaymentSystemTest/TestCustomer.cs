using Moq;
using PaymentSystemApi_v01.DTO;
using PaymentSystemApi_v01.Contracts;
using PaymentSystemApi_v01.Controllers;
using PaymentSystemApi_v01.Core;
using System.Collections.Generic;

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
            mockCustomerProvider.Setup(provider =>  provider.TransactionHistory(nationalId).Result)
                .Returns((true,transacton,false)); 


            // Test Custom Controller

            var controller = new CustomerController(mockCustomerProvider.Object);

            // Act
            var result = await controller.CustomerByNationalId(nationalId);


            // Assert
          //  Assert.IsType<(bool,IEnumerable <TransactionHistoryDto>,bool)>(result);
            Assert.NotEmpty(result.Value.transaction);
           // var response = Assert.IsType<TransactionHistoryDto>(okResult);

            mockCustomerProvider.Verify(provider => provider.TransactionHistory(nationalId), Times.Once);
        }
    
}
}