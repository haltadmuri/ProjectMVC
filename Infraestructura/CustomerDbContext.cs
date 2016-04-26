using Dominio;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura
{
    public class CustomerDbContext: DbContext,ICustomerDbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public CustomerDbContext()
        {
            var cadenaConexion = this.Database.Connection.ConnectionString;

        }


    }
}
