using MvcApplication.Contract;
using MvcApplication.Domain.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcApplication.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        #region Global Variables
        private readonly MvcApplicationDatabase _context;
        #endregion

        #region Initialization
        public CustomerRepository()
        {
            _context = new MvcApplicationDatabase();
        }

        public void Dispose()
        {
            if (_context != null)
                _context.Dispose();
        }
        #endregion

        #region ICustomerRepository Methods

        /// <summary>
        /// Add / Update Customer record
        /// </summary>
        /// <param name="model">Dto.CustomerViewModel </param>
        /// <returns>bool</returns>
        public bool Save(Dto.CustomerViewModel model)
        {
            var customer = new Domain.DomainObjects.Customer();
            if (model.Id.Equals(default(Guid)))
            {
                customer = AutoMapper.Mapper.Map<Dto.CustomerViewModel, Domain.DomainObjects.Customer>(model);
                customer.Id = Guid.NewGuid();
                customer.Status = 1;

                _context.Customer.Add(customer);
            }
            else
            {
                customer = GetCustomer(model.Id);

                if (customer == null)
                    return false;

                customer = AutoMapper.Mapper.Map<Dto.CustomerViewModel, Domain.DomainObjects.Customer>(model);
            }
            var result = _context.SaveChanges();

            return result > 0 ? true : false;
        }

        /// <summary>
        /// Rerturns a Customer record by customer id
        /// </summary>
        /// <param name="id">Customer id</param>
        /// <returns>Dto.CustomerViewModel</returns>
        public Dto.CustomerViewModel GetById(Guid id)
        {
            var customer = GetCustomer(id);

            if (customer == null)
                return null;

            return AutoMapper.Mapper.Map<Domain.DomainObjects.Customer, Dto.CustomerViewModel>(customer);
        }
        #endregion

        #region Private Methods

        /// <summary>
        /// Returnss a Customer record by customer id
        /// </summary>
        /// <param name="id">Customer id</param>
        /// <returns> Domain.DomainObjects.Customer </returns>
        private Domain.DomainObjects.Customer GetCustomer(Guid id)
        {
            return _context.Customer.FirstOrDefault(x => x.Id.Equals(id));
        }

        #endregion
    }
}
