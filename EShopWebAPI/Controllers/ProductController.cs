using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EShopWebAPI.Models;
namespace EShopWebAPI.Controllers
{
    public class ProductController : ApiController
    {
        // GET: api/Product
        List<Product> emps = new List<Product>();
        public IEnumerable<Product> Get()
        {
            //viết code xử lý
            using (EShopDBEntities db = new EShopDBEntities())
            {
                //lấy về toàn bộ sản phẩm trong bảng product
                return db.Products.ToList();
            }
        }

        // GET: api/Product/5
        [Route("api/product/GetProductByID")]
        public HttpResponseMessage GetProductByID(int id)
        {
            using (EShopDBEntities db = new EShopDBEntities())
            {
                var em = db.Products.SingleOrDefault(x => x.ProductID == id);
                return Request.CreateResponse(HttpStatusCode.OK, em);

            }
        }

        // POST: api/Product
        //Thêm một loại sp
        public HttpResponseMessage Post([FromBody]Product emp)
        {
            using (EShopDBEntities db = new EShopDBEntities())
            {
                try
                {
                    db.Products.Add(emp);
                    db.SaveChanges();

                    return Request.CreateResponse(HttpStatusCode.Created, emp);
                }
                catch (Exception ex)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Có lỗi khi thêm dữ liệu!", ex);
                }
            }
        }

        // PUT: api/Product/5
        public IEnumerable<Product> Put([FromBody]Product emp)
        {
            using (EShopDBEntities db = new EShopDBEntities())
            {
                Product em = db.Products.SingleOrDefault(x => x.ProductID == emp.ProductID);
                em.ProductID = emp.ProductID;
                em.CategoryID = emp.CategoryID;
                em.ProductName = emp.ProductName;
                em.UnitPrice = emp.UnitPrice;
                em.Quantity = emp.Quantity;
              
                db.SaveChanges();
                return db.Products.ToList();
            }
        }
        // DELETE: api/Product/5
        [HttpDelete]
        [Route("api/product/DeleteProduct")]
        // DELETE: api/Category/5
        public IEnumerable<Product> RemoveProduct(int id)
        {
            using (EShopDBEntities db = new EShopDBEntities())
            {
                Product emp = db.Products.SingleOrDefault(x => x.ProductID == id);
                db.Products.Remove(emp);
                db.SaveChanges();

                return db.Products.ToList();
            }
        }
    }
}
