using Dominio;
using Infraestructura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logica
{
    public interface ICustomerService:  IDisposable
    {
       
        Customer Add(Customer c);
        void Delete(int c);
        Customer Get(int id);
        void Update(int id,Customer customer);
        IEnumerable<Customer> GetAll(string name);
        IEnumerable<Customer> GetAlls();
    }
}
