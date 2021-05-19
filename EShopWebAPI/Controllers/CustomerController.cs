using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EShopWebAPI.Models;
namespace EShopWebAPI.Controllers
{
    public class CustomerController : ApiController
    {
        // GET: api/CustomerController
        List<Customer> cust = new List<Customer>();
        public IEnumerable<Customer> Get()
        {
            //viết code xử lý
            using (EShopDBEntities db = new EShopDBEntities())
            {
                return db.Customers.ToList();
            }
        }

        // GET: api/CustomerController/5
        //lấy về một khách hàng theo mã
        public HttpResponseMessage Get(int id)
        {
            using (EShopDBEntities db = new EShopDBEntities())
            {
                var em = db.Customers.SingleOrDefault(x => x.CustomerID == id);
                return Request.CreateResponse(HttpStatusCode.OK, em);
            }

        }

        [HttpGet]
        [Route("api/ListCurtomerByAddress")]
        public IEnumerable<Customer> ListCurtomerByAddress(string Address)
        {
            using (EShopDBEntities db = new EShopDBEntities())
            {
                var listCust = db.Customers.Where(e => e.Address == Address);
                return listCust.ToList();
            }
        }
        // POST: api/CustomerController
        public HttpResponseMessage Post([FromBody]Customer cus)
        {
            using (EShopDBEntities db = new EShopDBEntities())
            {
                try
                {
                    db.Customers.Add(cus);
                    db.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.Created, cus);
                }
                catch (Exception ex)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Có lỗi khi thêm dữ liệu!", ex);
                }
                //return db.Employees.ToList();

            }
        }

        // PUT: api/CustomerController/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/CustomerController/5
        public void Delete(int id)
        {
        }
    }
}
