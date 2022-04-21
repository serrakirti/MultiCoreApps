#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MultiCoreApp.Core.Models;
using MultiCoreApp.MVC.ApiServices;
using MultiCoreApp.MVC.DTOs;

namespace MultiCoreApp.MVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductApiService _productApiService;
        private readonly CategoryApiService _categoryApiService;
        private readonly IMapper _mapper;
        
        public ProductController(ProductApiService productApiService, IMapper mapper, CategoryApiService categoryApiService)
        {
            _productApiService = productApiService;
            _mapper = mapper;
            _categoryApiService = categoryApiService;

        }

        // GET: Product
        public async Task<IActionResult> Index()
        {
            IEnumerable<ProductWithCategoryDto> pro = await _productApiService.GetAllWithCategoryAsync();
            return View(pro);
        }

        // GET: Product/Details/5
        public async Task<IActionResult> Details(Guid id)
        {
            var proDto = await _productApiService.GetByIdAsync(id);

            return View(proDto);
        }

        // GET: Product/Create
        public IActionResult Create()
        {
            var cat = _categoryApiService.GetAllAsync().Result;
            ViewData["CategoryId"] = new SelectList(cat, "Id", "Name");
            return View();
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductWithCategoryDto proDto)
        {
            ModelState.Remove("category");
            if (ModelState.IsValid)
            {
                await _productApiService.AddAsync(proDto);
                return RedirectToAction("Index");
            }

            await _productApiService.AddAsync(proDto);
            ViewData["CategoryId"] = new SelectList(_categoryApiService.GetAllAsync().Result, "Id", "Name", proDto.CategoryId);
            return View(proDto);
        }

        // GET: Product/Edit/5
        public async Task<IActionResult> Edit(Guid id)
        {
           
            var proDto = await _productApiService.GetByIdAsync(id);

            ViewData["CategoryId"] = new SelectList(_categoryApiService.GetAllAsync().Result, "Id", "Name", proDto.CategoryId);
            return View(proDto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]//Dışarıdan manuel girişlere engel olur...
        public async Task<IActionResult> Edit(Guid id, ProductWithCategoryDto proDto)
        {

            ModelState.Remove("category");
            if (ModelState.IsValid)
            {
                await _productApiService.Update(proDto);
                return RedirectToAction("Index");
            }
            ViewData["CategoryId"] = new SelectList(_categoryApiService.GetAllAsync().Result, "Id", "Name", proDto.CategoryId);
            return View(proDto);
        }

        // GET: Product/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {

            //if (id == null)
            //{
            //    return NotFound();
            //}

            //var product = await _context.Product
            //    .Include(p => p.Category)
            //    .FirstOrDefaultAsync(m => m.Id == id);
            //if (product == null)
            //{
            //    return NotFound();
            //}

            return View();
        }

        // POST: Product/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            //var product = await _context.Product.FindAsync(id);
            //_context.Product.Remove(product);
            //await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        //private bool ProductExists(Guid id)
        //{
        //    return _context.Product.Any(e => e.Id == id);
        //}
    }
}
