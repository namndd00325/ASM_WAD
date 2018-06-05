using CakeMaker.Models;
using System;
using System.Net;
using System.Web.Mvc;

namespace CakeMaker.Controllers
{
    public class CakeMakerController : Controller
    {
        CakeMakerContext db = new CakeMakerContext();
        // GET: CakeMaker
        public ActionResult Index()
        {
            return View(db.Products);
        }
        // GET: About
        public ActionResult About()
        {
            return View();
        }
        // GET: All Product
        public ActionResult AllProduct()
        {
            return View(db.Products);
        }
        // GET: /Order/{id}
        public ActionResult Order(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
                return HttpNotFound();
            OrderDetail orderDetail = new OrderDetail();    
            orderDetail.ProductId = product.Id;
            return View(orderDetail);
        }

        // POST: /Order/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Order(OrderDetail orderDetail)
        {
            try
            {
                Console.WriteLine("run");
                if (ModelState.IsValid)
                {
                    Console.WriteLine("run in");
                    orderDetail.Id = Convert.ToInt16(TimeSpan.TicksPerMillisecond);

                    db.OrderDetails.Add(orderDetail);
                    Console.WriteLine("add orderdetail");
                    Customer customer = new Customer();
                    //customer.Username = Convert.ToString(TimeSpan.TicksPerMillisecond);
                    //db.Customers.Add(customer);
                    //Console.WriteLine("add cus");

                    db.SaveChanges();
                    Console.WriteLine("save");

                    return RedirectToAction("Index");
                }
                return View(orderDetail);
            }
            catch
            {
                return View();
            }
        }


    }
}
