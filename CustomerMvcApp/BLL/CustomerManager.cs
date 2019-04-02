using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using CustomerMvcApp.DLL;
using CustomerMvcApp.Models;

namespace CustomerMvcApp.BLL
{
    public class CustomerManager
    {
        CustomerRepository customerRepository = new CustomerRepository();

        public bool IsSaved(Customer customer)
        {
            bool isSaved = customerRepository.Saved(customer);
            return isSaved;

        }

        public Customer GetCustomerInfo(string Code)
        {
            return customerRepository.GetCustomerInfo(Code);
        }

        public List<Customer> Show()
        {
            var dataList = customerRepository.Show();
            return dataList;
        }

        public bool Delete(int id)
        {
            var isDeleted = customerRepository.Delete(id);
            return isDeleted;
        }

        internal List<Customer> Search(Customer customer)
        {
            var dataList = customerRepository.Search(customer);
            return dataList;
        }

        internal Customer GetById(int id)
        {
            var data = customerRepository.GetById(id);
            return data;
        }

        internal bool Update(Customer customer)
        {
            var isUpdated = customerRepository.Update(customer);
            return isUpdated;
        }
    }
}