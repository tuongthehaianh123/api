using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EShopWebAPI.Models;
namespace EShopWebAPI.Controllers
{
    public class OrderController : ApiController
    {
        // GET: api/Order
        List<Order> cust = new List<Order>();
        public IEnumerable<Order> Get()
        {
            //viết code xử lý
            using (EShopDBEntities db = new EShopDBEntities())
            {
                return db.Orders.ToList();
            }
        }


        // GET: api/Order/5
        [Route("api/GetOrderByID")]
        public IEnumerable<OrderDetail> GetOrderByID(int id)
        {

            using (EShopDBEntities db = new EShopDBEntities())
            {
                var list = db.OrderDetails.Where(x => x.OrderID == id);
                return db.OrderDetails.ToList();
            }
        }


        // POST: api/Order
        public HttpResponseMessage Post([FromBody]Order cust)
        {
            using (EShopDBEntities db = new EShopDBEntities())
            {
                try
                {
                    db.Orders.Add(cust);
                    db.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.Created, cust);
                }
                catch (Exception ex)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Có lỗi khi thêm dữ liệu!", ex);
                }
                //return db.Employees.ToList();

            }
        }
        // PUT: api/Order/5
        public IEnumerable<Order> Put([FromBody]Order emp)
        {
            using (EShopDBEntities db = new EShopDBEntities())
            {
                Order em = db.Orders.SingleOrDefault(x => x.OrderID == emp.OrderID);//lấy thông tin nv theo mã truyền vào
                //cho phép sửa các thông tin 
                em.OrderID = emp.OrderID;
                em.CustomerID = emp.CustomerID;
                em.OrderDate = emp.OrderDate;
                em.ShipAddress = emp.ShipAddress;               
                db.SaveChanges();
                return db.Orders.ToList();
            }
        }

        // DELETE: api/Order/5
        [HttpDelete]
        [Route("api/DeleteOrder")]
        // DELETE api/values/5
        public IEnumerable<Order> RemoveOrder(int id)
        {
            using (EShopDBEntities db = new EShopDBEntities())
            {
                Order emp = db.Orders.SingleOrDefault(x => x.OrderID == id);
                db.Orders.Remove(emp);
                db.SaveChanges();
                return db.Orders.ToList();
            }
        }
    }
}
