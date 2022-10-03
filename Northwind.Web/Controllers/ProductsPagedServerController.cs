﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Northwind.Contracts.Dto.Category;
using Northwind.Contracts.Dto.Product;
using Northwind.Domain.Entities;
using Northwind.Domain.Models;
using Northwind.Persistence;
using Northwind.Services;
using Northwind.Services.Abstraction;
using X.PagedList;

namespace Northwind.Web.Controllers
{
    public class ProductsPagedServerController : Controller
    {
        private readonly NorthwindContext _conten;
        private readonly IServiceManager _context;
        private readonly IUtilityService _utilityService;

        public ProductsPagedServerController(NorthwindContext conten, IServiceManager context, IUtilityService utilityService)
        {
            _conten = conten;
            _context = context;
            _utilityService = utilityService;
        }




        // GET: ProductsService4
        public async Task<IActionResult> Index(string searchString, string currentFilter,
            string sortOrder, int? page, int? fetchSize)
        {
            var pageIndex = page ?? 1;
            var pageSize = fetchSize ?? 5;
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewBag.CurrentFilter = searchString;

            var productForSearch = await _context.ProductService.GetProductPaged(pageIndex, pageSize, false);
            var totalRows = productForSearch.Count();
            if (!String.IsNullOrEmpty(searchString))
            {
                productForSearch = productForSearch.Where(p => p.ProductName.ToLower().Contains(searchString.ToLower()) ||
                p.Supplier.CompanyName.ToLower().Contains(searchString.ToLower()));
            }


            ViewBag.ProductNameSort = String.IsNullOrEmpty(sortOrder) ? "product_name" : "";
            ViewBag.UnitPriceSort = sortOrder == "price" ? "unit_price" : "price";

            var productForSort = from p in productForSearch
                                 select p;
            switch (sortOrder)
            {
                case "product_name":
                    productForSort = productForSort.OrderByDescending(p => p.ProductName);
                    break;
                case "price":
                    productForSort = productForSort.OrderBy(p => p.UnitPrice);
                    break;
                case "unit_price":
                    productForSort = productForSort.OrderByDescending(p => p.UnitPrice);
                    break;
                default:
                    productForSort = productForSort.OrderBy(p => p.ProductName);
                    break;
            }

            var productDtoPaged = new StaticPagedList<ProductDto>(productForSort, pageIndex, pageSize - (pageSize - 1), totalRows);
            ViewBag.PagedList = new SelectList(new List<int> { 8, 15, 20 });
            return View(productDtoPaged);
        }



        [HttpPost]
                public async Task<IActionResult> CreateProductPhoto(ProductPhotoGroupDto productPhotoGroupDto)
        {
            if (ModelState.IsValid)
            {
                var productPhotoGroup = productPhotoGroupDto;
                var listPhoto = new List<ProductPhotoCreateDto>();
                foreach (var itemPhoto in productPhotoGroup.AllPhoto)
                {
                    var fileName = _utilityService.UploadSinggleFile(itemPhoto);
                    var photo = new ProductPhotoCreateDto
                    {
                        PhotoFilename = fileName,
                        PhotoFileSize = (short?)itemPhoto.Length,
                        PhotoFileType = itemPhoto.ContentType
                    };
                    listPhoto.Add(photo);
                }
                _context.ProductService.CreateProductManyPhoto(productPhotoGroupDto.productForCreateDto,listPhoto);
                /*var photo1 = _utilityService.UploadSinggleFile(productPhotoDto.Photo1);
                var photo2 = _utilityService.UploadSinggleFile(productPhotoDto.Photo2);
                var photo3 = _utilityService.UploadSinggleFile(productPhotoDto.Photo3);*/
            }

            ViewData["CategoryId"] = new SelectList(_conten.Categories, "CategoryId", "CategoryName");
            ViewData["SupplierId"] = new SelectList(_conten.Suppliers, "SupplierId", "CompanyName");

            return View("Create");
            /*var latestProductId = _context.ProductService.CreateProductId(productPhotoDto.productForCreateDto);
            if (ModelState.IsValid)
            {
                try
                {
                    var file = productPhotoDto.AllPhoto;
                    var folderName = Path.Combine("Resources", "images");
                    var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                    if (file.Count > 0)
                    {
                        foreach (var item in file)
                        {
                            var fileName = ContentDispositionHeaderValue.Parse(item.ContentDisposition).FileName.Trim('"');
                            var fullPath = Path.Combine(pathToSave, fileName);
                            var dbPath = Path.Combine(folderName, fileName);
                            using (var stream = new FileStream(fullPath, FileMode.Create))
                            {
                                item.CopyTo(stream);
                            }

                            var convertSize = (Int16)item.Length;

                            var productPhoto = new ProductPhotoCreateDto
                            {
                                PhotoFilename = fileName,
                                PhotoFileType = item.ContentType,
                                PhotoFileSize = (byte)convertSize,
                                PhotoProductId = latestProductId.ProductId
                            };
                            _context.ProductPhotoService.Insert(productPhoto);

                        }
                        return RedirectToAction(nameof(Index));

                        *//*var productGroup = new ProductPhotoGroupDto
                        {
                            productForCreateDto = productPhotoDto.productForCreateDto,
                            Photo1 = productPhotoDto.Photo1,
                            Photo2 = productPhotoDto.Photo2,
                            Photo3 = productPhotoDto.Photo3
                        };*//*
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
            return View();*/
        }

        // GET: ProductsService/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var product = await _context.ProductService.GetProductById((int)id, false);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: ProductsService/Create
        public async Task<IActionResult> Create()
        {
            var allCategory = await _context.CategoryService.GetAllCategory(false);
            var allSupplier = await _context.SupplierService.GetAllSupplier(false);
            ViewData["CategoryId"] = new SelectList(allCategory, "CategoryId", "CategoryName");
            ViewData["SupplierId"] = new SelectList(allSupplier, "SupplierId", "CompanyName");
            return View();
        }

        // POST: ProductsService/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductName,SupplierId,CategoryId,QuantityPerUnit,UnitPrice,UnitsInStock,UnitsOnOrder,ReorderLevel,Discontinued")] ProductForCreateDto product)
        {
            if (ModelState.IsValid)
            {
                _context.ProductService.Insert(product);
                return RedirectToAction(nameof(Index));
            }

            var allCategory = await _context.CategoryService.GetAllCategory(false);
            var allSupplier = await _context.SupplierService.GetAllSupplier(false);
            ViewData["CategoryId"] = new SelectList(allCategory, "CategoryId", "CategoryName", product.CategoryId);
            ViewData["SupplierId"] = new SelectList(allSupplier, "SupplierId", "CompanyName", product.SupplierId);
            return View(product);
        }
        //perubahan edit
        // GET: ProductsService/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var product = await _context.ProductService.GetProductPhotoById((int)id, true);
            var productPhoto = await _context.ProductPhotoService.GetProductDtoById((int)id, true);
            if (ModelState.IsValid)
            {
                return View(product);
            }

            ViewData["CategoryId"] = new SelectList(_conten.Categories, "CategoryId", "CategoryName");
            ViewData["SupplierId"] = new SelectList(_conten.Suppliers, "SupplierId", "CompanyName");

            return View(product);
            /*if (id == null)
            {
                return NotFound();
            }
            var product = await _context.ProductService.GetProductById((int)id, true);
            if (product == null)
            {
                return NotFound();
            }
            var allCategory = await _context.CategoryService.GetAllCategory(false);
            var allSupplier = await _context.SupplierService.GetAllSupplier(false);
            ViewData["CategoryId"] = new SelectList(allCategory, "CategoryId", "CategoryName", product.CategoryId);
            ViewData["SupplierId"] = new SelectList(allSupplier, "SupplierId", "CompanyName", product.SupplierId);
            return View(product);*/
        }
        //akhir
        //tambahan edit

        [HttpPost]
        public async Task<IActionResult> EditProductPhoto(int? id)
        {
            if (ModelState.IsValid)
            {
                var product = await _context.ProductService.GetProductPhotoGroupById((int)id, true);
                return View("Edit");
            }
            return View("Edit");
        }
        //batas tamabahan edit
        // POST: ProductsService/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductId,ProductName,SupplierId,CategoryId,QuantityPerUnit,UnitPrice,UnitsInStock,UnitsOnOrder,ReorderLevel,Discontinued")] ProductDto product)
        {
            if (id != product.ProductId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.ProductService.Edit(product);
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            var allCategory = await _context.CategoryService.GetAllCategory(false);
            var allSupplier = await _context.SupplierService.GetAllSupplier(false);
            ViewData["CategoryId"] = new SelectList(allCategory, "CategoryId", "CategoryName", product.CategoryId);
            ViewData["SupplierId"] = new SelectList(allSupplier, "SupplierId", "CompanyName", product.SupplierId);
            return View(product);
        }

        // GET: ProductsService/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var product = await _context.ProductService.GetProductById((int)id, false);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: ProductsService/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.ProductService.GetProductById((int)id, false);
            _context.ProductService.Remove(product);
            return RedirectToAction(nameof(Index));
        }
    }
}
