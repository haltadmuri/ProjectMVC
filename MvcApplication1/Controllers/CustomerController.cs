using Dominio;
using Logica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MvcApplication1.Controllers
{
    public class CustomerController : ApiController
    {
        /*Inyección de dependencias*/
        readonly ICustomerService _service;

        public CustomerController(ICustomerService service)
        {
            this._service = service;
        }

        // GET api/values
        public IEnumerable<Customer> Get()
        {
            return _service.GetAlls().ToList();
        }

        // GET api/values/5
        public Customer Get(int id)
        {
            var customerId = _service.Get(id);
            if (customerId.Nombre == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return customerId;
        }

        // POST api/values
        public void Post([FromBody]Customer customer)
        {
            if (customer.Nombre == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            _service.Add(customer);
        }

        // PUT api/values/5
        //Edit
        public void Put(int id, [FromBody]Customer customer)
        {
            if (null == customer)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            customer.Id = id;
            _service.Update(id, customer);
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            Customer customerId = _service.Get(id);
            if (customerId.Nombre == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            _service.Delete(id);
        }
    }
}


//HTTPRESPONSE web api -> para conseguir devovler un 404 
