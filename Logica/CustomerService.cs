using Dominio;
using Infraestructura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class CustomerService:ServiceBase,ICustomerService
    {
        readonly ICustomerDbContext _context;

        public CustomerService(ICustomerDbContext ctx)
            :base(ctx)
        {
            
            if (null == ctx)
            {
                throw new ArgumentNullException("CustomerContext");
            }
            _context = ctx;
        }

        public Customer Add(Customer c)
        {
            var customerNew=_context.Customers.Add(c);
            SaveChanges();
            return customerNew;
        }

        public void Delete(int cus)
        {
            Customer c = Get(cus);
            _context.Customers.Remove(c);
             SaveChanges();
        }

        public Customer Get(int id)
        {
            return GetCustomer(id);
        }


        public void Update(int id, Customer customer)
        {
            var customerOld = GetCustomer(id);
            CheckNullCustomer(customerOld);
            UpdateCustomer(customer,customerOld);
            SaveChanges();
        }

        public IEnumerable<Customer> GetAll(string name) 
        {
            return _context.Customers.Where(c=>c.Nombre.Contains(name)||name ==null);

        }
        private static void UpdateCustomer(Customer customer, Customer customerOld) 
        {
            customerOld.Nombre = customer.Nombre;
            customerOld.Phone = customer.Phone;
        }
        private static void CheckNullCustomer(Customer customer) 
        {
            if (null == customer)
            {
                throw new NullReferenceException("El cliente no existe");
            }
        }
        private Customer GetCustomer(int Id)
        {
            return _context.Customers.Where(c => c.Id == Id).FirstOrDefault();
        }
        private int SaveChanges()
        {
            return _context.SaveChanges();
        }


        public IEnumerable<Customer> GetAlls()
        {
            return _context.Customers;

        }

        }




}
