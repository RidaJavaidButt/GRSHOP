using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GRSHOP.Data;
using GRSHOP.Models;
using Microsoft.AspNetCore.Authorization;

namespace GRSHOP.Controllers
{
    public class GroceriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GroceriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Groceries
        public async Task<IActionResult> Index()
        {
            return View(await _context.Grocery.ToListAsync());
        }

       

        public IActionResult SearchForm()
        {
            return View();
        }
        public async Task<IActionResult> GroceryList()
        {
            return View(await _context.Grocery.ToListAsync());
        }



        public async Task<IActionResult> SearchResult(string Title)
        {
            return View("Index", await _context.Grocery.Where(a => a.Title.Contains(Title)).ToListAsync());
        }

        // GET: Groceries/Details/5


        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var grocery = await _context.Grocery
                .FirstOrDefaultAsync(m => m.Id == id);
            if (grocery == null)
            {
                return NotFound();
            }

            return View(grocery);
        }

        // GET: Groceries/Create

        [Authorize]
        public IActionResult Create()
        {
            ViewData["StoreId"] = new SelectList(_context.Store, "id", "Name");
            ViewData["BrandId"] = new SelectList(_context.Brand, "id", "Name");
            return View();
        }

        // POST: Groceries/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create([Bind("Id,Title,URL,Price,BrandId,StoreId")] Grocery grocery, List<int> Brand)
        {
            if (ModelState.IsValid)
            {
                _context.Grocery.Add(grocery);
                await _context.SaveChangesAsync();
                List<Brand> brands = new List<Brand>();
                foreach (int brand in Brand)
                {
                    brands.Add(new Brand { Id = brand });

                }
                _context.Brand.AddRange(brands);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            ViewData["StoreId"]= new SelectList(_context.Store, "id","id", grocery.StoreId);
            return View(grocery);
        }
        

        // GET: Groceries/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var grocery = await _context.Grocery.FindAsync(id);
            if (grocery == null)
            {
                return NotFound();
            }
            return View(grocery);
        }

        // POST: Groceries/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,URL,Price,BrandId,StoreId")] Grocery grocery)
        {
            if (id != grocery.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(grocery);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GroceryExists(grocery.Id))
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
            return View(grocery);
        }

        // GET: Groceries/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var grocery = await _context.Grocery
                .FirstOrDefaultAsync(m => m.Id == id);
            if (grocery == null)
            {
                return NotFound();
            }

            return View(grocery);
        }

        // POST: Groceries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var grocery = await _context.Grocery.FindAsync(id);
            _context.Grocery.Remove(grocery);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GroceryExists(int id)
        {
            return _context.Grocery.Any(e => e.Id == id);
        }
    }
}
