using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreBusiness.Entities;
using DataStore.SQL;

namespace UseCases
{
    public class ViewCustomersUseCase : IViewCustomersUseCase
    {
        private readonly ICustomerRepo customerRepo;

        public ViewCustomersUseCase(ICustomerRepo customerRepo)
        {
            this.customerRepo = customerRepo;
        }
        public IEnumerable<Customer> Execute()
        {
            return customerRepo.GetCustomers();
        }
    }
}