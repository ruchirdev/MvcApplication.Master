using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcApplication.Contract
{
    public interface ICustomerRepository : IDisposable
    {
        /// <summary>
        /// Add / Update Customer record
        /// </summary>
        /// <param name="model">Dto.CustomerViewModel </param>
        /// <returns>bool</returns>
        bool Save(Dto.CustomerViewModel model);

        /// <summary>
        /// Rerturns a Customer record by customer id
        /// </summary>
        /// <param name="id">Customer id</param>
        /// <returns>Dto.CustomerViewModel</returns>
        Dto.CustomerViewModel GetById(Guid id);
    }
}
