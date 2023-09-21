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
            List<CustomerDto> customer= new();
            ////var expectedTransaction = new TransactionHistoryDto
            ////{
            ////    // Initialize with expected data for testing

            ////    CustormId ="123",
            ////    CreationDate = DateTime.Now,
            ////    Customer = new Customer
            ////    {
            ////        Name = "testName",
            ////        CustomerNumber = "08036266786",
            ////        DateOfBirth = DateTime.Now,
            ////        NationalId = nationalId,
            ////        Id = "123",
            ////        Surname = "testSurname",
            ////        TransactionHistory = null,
            ////    }
            ////};
            var custom = new CustomerDto
            {
                Name = "testName",
                CustomerNumber = "08036266786",
                DateOfBirth = DateTime.Now,
                NationalId = nationalId,
                Surname = "testSurname",
                TransactionHistory = null,
            };
            customer.Add(custom);

            var mockCustomerProvider = new Mock<ICustomerService>();
            mockCustomerProvider.Setup(provider =>  provider.Customers().Result)
                .Returns((true, customer, false)); 


            // Test Custom Controller

            var controller = new CustomerController(mockCustomerProvider.Object);

            // Act
            var result =  controller.Customers().Result;


            // Assert
           Assert.IsAssignableFrom<IEnumerable<CustomerDto>>(result);
            Assert.NotNull(result);
           // var response = Assert.IsType<TransactionHistoryDto>(okResult);

            mockCustomerProvider.Verify(provider => provider.TransactionHistory(nationalId), Times.Once);
        }
    
}
}