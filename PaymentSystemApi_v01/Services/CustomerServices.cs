using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using PaymentSystemApi_v01.Contracts;
using PaymentSystemApi_v01.Core;
using PaymentSystemApi_v01.DTO;
using System.Collections.Generic;

namespace PaymentSystemApi_v01.Services
{
    public class CustomerServices: ICustomerService
    {
        private readonly IMapper _mapper;
        public CustomerServices(ApplicationDbContext context, IMapper mapper)
        {
            Context = context;
            _mapper = mapper;
            SeedCustomer();
        }

        private void SeedCustomer()
        {
            List<TransactionHistory> histories = new List<TransactionHistory>();
            if (!Context.Customers.Any())
            {
                Context.Customers.Add(new Customer
                {   Id ="1",
                    NationalId = "01234567891",
                    Name = "wumi",
                    CustomerNumber = "+2348036266786",
                    Surname = "Yusuf",
                    DateOfBirth = DateTime.Now,
                  
                });

                var entity = new TransactionHistory
                {
                    CreationDate = DateTime.Now,
                    CustormId = "1",
                };

                var entry = Context.Entry(entity);
                entry.State = EntityState.Added;
            }
            

                Context.SaveChanges();
            
            

        }

        public ApplicationDbContext Context { get; }



        public async Task<(bool successful, CustomerDto customer, bool fail)> CustomerById(string id)
        {
            return await Task.FromResult((true, _mapper.Map<CustomerDto>(Context.Customers.FirstOrDefault(x => x.Id == id)), false));
        }

        public async Task<(bool successful, IEnumerable<CustomerDto> customers, bool fail)> Customers()
        {
            var customers = Context.Customers.
                Join(Context.transactionHistories, cus=> cus.Id, trans=> trans.CustormId, (cus, trans) => new {customer = cus, transactionHistory = trans }).Select(data => new Customer
                {
                  NationalId =  data.customer.NationalId,
                  Name = data.customer.Name,
                  DateOfBirth = data.customer.DateOfBirth,
                  Surname = data.customer.Surname,
                  CustomerNumber = data.customer.CustomerNumber
                 
                });
            
            return await Task.FromResult((true, _mapper.Map<IEnumerable<CustomerDto>>(customers), false));
        }

        public async Task<(bool successful, bool fail)> Customer(CustomerDto input)
        {
             await Context.AddAsync(input);
           var result= await Context.SaveChangesAsync();
            if (result > -1)
            { 
            
            return  await Task.FromResult((true, false));
            }
            return await Task.FromResult((false, true));

        }


        public async Task<(bool successful, IEnumerable<TransactionHistory> customers, bool fail)> TransactionHistoryByCustomerId(string CustomerId)
        {
            var customers = Context.Customers.
                Join(Context.transactionHistories, cus => cus.Id, trans => trans.CustormId, (cus, trans) => new { customer = cus, transactionHistory = trans }).Select(data => new Customer
                {
                    NationalId = data.customer.NationalId,
                    Name = data.customer.Name,
                    DateOfBirth = data.customer.DateOfBirth,
                    Surname = data.customer.Surname,
                    CustomerNumber = data.customer.CustomerNumber

                });

            return await Task.FromResult((true, _mapper.Map<IEnumerable<TransactionHistory>>(customers), false));
        }

        public async Task<(bool successful, IEnumerable<TransactionHistory> customers, bool fail)> TransactionHistory(string CustomerId)
        {
            var customers = Context.Customers.
                Join(Context.transactionHistories, cus => cus.Id, trans => trans.CustormId, (cus, trans) => new { customer = cus, transactionHistory = trans }).Select(data => new Customer
                {
                    NationalId = data.customer.NationalId,
                    Name = data.customer.Name,
                    DateOfBirth = data.customer.DateOfBirth,
                    Surname = data.customer.Surname,
                    CustomerNumber = data.customer.CustomerNumber

                });

            return await Task.FromResult((true, _mapper.Map<IEnumerable<TransactionHistory>>(customers), false));
        }


    }
}
