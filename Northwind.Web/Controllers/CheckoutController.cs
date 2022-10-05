using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Northwind.Contracts.Dto.Order;
using Northwind.Contracts.Dto.OrderDetail;
using Northwind.Contracts.Dto.Product;
using Northwind.Persistence;
using Northwind.Services.Abstraction;
using System;
using System.Threading.Tasks;

namespace Northwind.Web.Controllers
{
    public class CheckoutController : Controller
    {
        private readonly NorthwindContext _conten;
        private readonly IServiceManager _context;
        private readonly IUtilityService _utilityService;

        public CheckoutController(NorthwindContext conten, IServiceManager context, IUtilityService utilityService)
        {
            _conten = conten;
            _context = context;
            _utilityService = utilityService;
        }

        public async Task<IActionResult>CheckoutOrder(ProductDto productDto)
        {
            if (ModelState.IsValid)
            {
                var productId = productDto.ProductId;
                var order = new OrderForCreateDto();
                {
                    order.OrderDate = DateTime.Now;
                    order.RequiredDate = DateTime.Now.AddDays(3);
                }

                var orderDetail = new OrderDetailsForCreateDto();
                {
                    orderDetail.ProductId = productId;
                    orderDetail.UnitPrice = 0;
                    orderDetail.Quantity = 0;
                    orderDetail.Discount = 0;
                    
                }

                _context.ProductService.CreateOrderDetails(order,orderDetail);
                return RedirectToAction(nameof(Index));
            }
            return View(productDto);
            
        }

        // GET: CheckoutController
        public async Task<ActionResult> Index()
        {
            var productSale = await _context.ProductService.GetProductOneSales(false);
            return View(productSale);
        }

        // GET: CheckoutController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CheckoutController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CheckoutController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CheckoutController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CheckoutController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CheckoutController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CheckoutController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
