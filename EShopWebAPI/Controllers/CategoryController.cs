using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EShopWebAPI.DTO;
using EShopWebAPI.Models;
namespace EShopWebAPI.Controllers
{
    public class CategoryController : ApiController
    {
        // GET: api/Category
        List<Category> emps = new List<Category>();
        public IEnumerable<Category> Get()
        {
            //viết code xử lý
            using (EShopDBEntities db = new EShopDBEntities())
            {
                //lấy về toàn bộ sản phẩm trong bảng product
                return db.Categories.ToList();
            }
        }

        // GET: api/Category/5
        public Category Get(int id)
        {
            using (EShopDBEntities db = new EShopDBEntities())
            {
                //lấy về một sản phẩm theo mã loại
                return db.Categories.SingleOrDefault(x => x.CategoryID == id);
            }
        }
        // POST: api/Category
        //Thêm một loại sp
        public List<Category> Post([FromBody]Category emp)
        {
            using (EShopDBEntities db = new EShopDBEntities())
            {
                db.Categories.Add(emp);
                db.SaveChanges();
                return db.Categories.ToList();
            }
        }

        // PUT: api/Category/5
        public List<Category> Put(int id, [FromBody]Category emp)
        {
            using (EShopDBEntities db = new EShopDBEntities())
            {
                Category em = db.Categories.SingleOrDefault(x => x.CategoryID == emp.CategoryID);//lấy thông tin nv theo mã truyền vào
                //cho phép sửa các thông tin 
                em.CategoryID = emp.CategoryID;
                em.CategoryName = emp.CategoryName;
                em.Description = emp.Description;
                db.SaveChanges();
                return db.Categories.ToList();
            }
        }
        [HttpDelete]
        [Route("api/DeleteCategory")]
        // DELETE: api/Category/5
        public IEnumerable<Category> RemoveEmployee(int id)
        {
            using (EShopDBEntities db = new EShopDBEntities())
            {
                Category emp = db.Categories.SingleOrDefault(x => x.CategoryID == id);
                db.Categories.Remove(emp);
                db.SaveChanges();
                return db.Categories.ToList();
            }
        }
    }
}
