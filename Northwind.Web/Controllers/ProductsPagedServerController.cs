using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Northwind.Contracts.Dto.Product;
using Northwind.Domain.Models;
using Northwind.Persistence;
using Northwind.Services.Abstraction;
using X.PagedList;

namespace Northwind.Web.Controllers
{
    public class ProductsPagedServerController : Controller
    {
        private readonly NorthwindContext _context;
        private readonly IServiceManager _serviceContext;
        private readonly IUtilityService _utilityService;
        public ProductsPagedServerController(NorthwindContext context, IServiceManager serviceContext, IUtilityService utilityService)
        {
            _context = context;
            _serviceContext = serviceContext;
            _utilityService = utilityService;
        }

        // GET: ProductsPagedServer
        public async Task<IActionResult> Index(string sortOrder, string searchString,
            string currentFilter, int? page, int? fetchSize)
        {
            var pageIndex = page ?? 1;
            var pageSize = fetchSize ?? 5;
            //keep state searching value
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.currentFilter = searchString;

            var productDtos = await _serviceContext.ProductService.GetProductPaged(pageIndex, pageSize, false);

            var totalRows = productDtos.Count();

            if (!string.IsNullOrEmpty(searchString))
            {
                productDtos = productDtos.Where(p => p.ProductName.ToLower().Contains(searchString.ToLower()));
            }

            ViewBag.NameProductSort = String.IsNullOrEmpty(sortOrder) ? "nameProduct_desc" : "";
            ViewBag.UnitPriceSort = sortOrder == "UnitPrice" ? "unitPrice_desc" : "UnitPrice";
            var productSort = from item in productDtos
                              select item;
            switch (sortOrder)
            {
                case "nameProduct_desc":
                    productSort = productSort.OrderByDescending(s => s.ProductName);
                    break;
                case "UnitProduct_desc":
                    productSort = productSort.OrderBy(s => s.UnitPrice);
                    break;
                default:
                    productSort = productSort.OrderBy(s => s.ProductName);
                    break;
            }

            var productDtosPaged =
                new StaticPagedList<ProductDto>(productSort, pageIndex, pageSize - (pageSize - 1), totalRows);
            ViewBag.pageList = new SelectList(new List<int> { 8, 15, 20 });

            return View(productDtosPaged);
        }
        
        /*public async Task<IActionResult> CreateProductPhoto(ProductPhotoGroupDto productPhotoDto)
        {
            return View("Create");
        }*/

        //POST : CreateProductPhoto
        public async Task<IActionResult> CreateProductPhoto(ProductPhotoGroupDto productPhotoGroupDto)
        {
            if (ModelState.IsValid)
            {
                var productPhotoGroup = productPhotoGroupDto;
                var listPhoto = new List<ProductPhotoForCreateDto>();

                foreach (var itemPhoto in productPhotoGroup.AllPhoto)
                {
                    var fileName = _utilityService.UploadSingleFile(itemPhoto);
                    var photo = new ProductPhotoForCreateDto
                    {
                        PhotoFilename = fileName,
                        PhotoFileSize = (short?)itemPhoto.Length,
                        PhotoFileType = itemPhoto.ContentType

                    };

                    listPhoto.Add(photo);
                }
                _serviceContext.ProductService.CreateProductManyPhoto(productPhotoGroup.ProductForCreateDto, listPhoto);
            }

            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName");
            ViewData["SupplierId"] = new SelectList(_context.Suppliers, "SupplierId", "CompanyName");
            return View("Create");
        }


        // GET: ProductsPagedServer/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Category)
                .Include(p => p.Supplier)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: ProductsPagedServer/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName");
            ViewData["SupplierId"] = new SelectList(_context.Suppliers, "SupplierId", "CompanyName");
            return View();
        }

        // POST: ProductsPagedServer/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductId,ProductName,SupplierId,CategoryId,QuantityPerUnit,UnitPrice,UnitsInStock,UnitsOnOrder,ReorderLevel,Discontinued")] Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName", product.CategoryId);
            ViewData["SupplierId"] = new SelectList(_context.Suppliers, "SupplierId", "CompanyName", product.SupplierId);
            return View(product);
        }

        // GET: ProductsPagedServer/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName", product.CategoryId);
            ViewData["SupplierId"] = new SelectList(_context.Suppliers, "SupplierId", "CompanyName", product.SupplierId);
            return View(product);
        }

        // POST: ProductsPagedServer/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductId,ProductName,SupplierId,CategoryId,QuantityPerUnit,UnitPrice,UnitsInStock,UnitsOnOrder,ReorderLevel,Discontinued")] Product product)
        {
            if (id != product.ProductId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.ProductId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName", product.CategoryId);
            ViewData["SupplierId"] = new SelectList(_context.Suppliers, "SupplierId", "CompanyName", product.SupplierId);
            return View(product);
        }

        // GET: ProductsPagedServer/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Category)
                .Include(p => p.Supplier)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: ProductsPagedServer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Products.FindAsync(id);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.ProductId == id);
        }
    }
}
