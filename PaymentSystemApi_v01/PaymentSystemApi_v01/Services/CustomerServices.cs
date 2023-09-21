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

        public async Task<(bool successful, bool fail)> Customer(CustomerRequest input)
        {
            var newCustomer = _mapper.Map<Customer>(input);
             await Context.AddAsync(newCustomer);
            await Context.transactionHistories.AddAsync(new TransactionHistory {
                CreationDate = DateTime.Now,
                CustormId = newCustomer.Id,
            });;

           var result= await Context.SaveChangesAsync();
            if (result > -1)
            { 
            
            return  await Task.FromResult((true, false));
            }
            return await Task.FromResult((false, true));

        }


        public async Task<(bool successful, IEnumerable<TransactionHistoryDto> transaction, bool fail)> TransactionHistory()
        {
            var transaction = Context.transactionHistories.
                Join(Context.Customers, trans => trans.CustormId, cus => cus.Id, (trans, cus) => new { transactionHistory = trans, customer = cus })
                     
                .Select(data => new TransactionHistory
                {
                    Id = data.transactionHistory.Id,
                    Customer = data.customer,
                    CreationDate = data.transactionHistory.CreationDate,
                    CustormId = data.customer.Id,

                });


            


            return await Task.FromResult((true, _mapper.Map<IEnumerable<TransactionHistoryDto>>(transaction), false));
        }

        public async Task<(bool successful, IEnumerable<TransactionHistoryDto> transaction, bool fail)> TransactionHistory(string NationalId)
        {
            

            var transaction = Context.transactionHistories.
                Join(Context.Customers, trans => trans.CustormId, cus => cus.Id, (trans, cus) => new { transactionHistory = trans, customer = cus })
                     .Where(custom => custom.customer.NationalId == NationalId)
                .Select(data => new TransactionHistory
                {
                    Id = data.transactionHistory.Id,
                    Customer = data.customer,
                    CreationDate = data.transactionHistory.CreationDate,
                    CustormId = data.customer.Id,

                });
                 

            //var transaction = Context.transactionHistories.Include(x => x.Customer).FirstOrDefault(n=> n.Customer.NationalId.Equals(NationalId));


            var mapperResult = _mapper.Map<IEnumerable<TransactionHistoryDto>>(transaction);
            return await Task.FromResult((true, mapperResult, false));
        }


    }
}
