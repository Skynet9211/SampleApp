using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SampleApp.Data;
using SampleApp.Models;

namespace SampleApp.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ApplicationdbContext _context;

        public ProductsController(ApplicationdbContext context)
        {
            _context = context;
        }

        // GET: Products
        public async Task<IActionResult> ProductIndex()
        {
              return _context.Product != null ? 
                          View(await _context.Product.ToListAsync()) :
                          Problem("Entity set 'ApplicationdbContext.Product'  is null.");
        }

      

       
        public IActionResult ProductCreate()
        {Product pr = new Product();
            return View( pr);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ProductCreate([Bind("productId,name,price")] Product product)
        {
            if (ModelState.IsValid)
            {
                var temp = _context.Product.OrderBy(x => x.productId);
                var temp2 = temp.LastOrDefault();
                var temp3 = temp2.productId;
                product.productId=temp3+1;
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(ProductIndex));
            }
            return View(product);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> ProductEdit(int? id)
        {
            if (id == null || _context.Product == null)
            {
                return NotFound();
            }

            var product = await _context.Product.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return  View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ProductEdit(int id, [Bind("productId,name,price")] Product product)
        {
            if (id != product.productId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var sale = _context.Sale.FirstOrDefault(x => x.productId == product.productId);
                    if (sale != null)
                    {
                        if (sale.productId == product.productId)
                        {
                            if (sale.product != product.name)
                            {
                                sale.product = product.name;
                            }
                            if (sale.price != product.price)
                            {
                                sale.price = product.price;
                                sale.total = sale.price * sale.quantity;
                            }
                            _context.Update(sale);
                            _context.Update(product);
                        }
                    }
                    else
                    {
                        _context.Update(product);
                    }
                   
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.productId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(ProductIndex));
            }
            return View(product);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Product == null)
            {
                return NotFound();
            }

            var product = await _context.Product
                .FirstOrDefaultAsync(m => m.productId == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Product == null)
            {
                return Problem("Entity set 'ApplicationdbContext.Product'  is null.");
            }
            var product = await _context.Product.FindAsync(id);
            if (product != null)
            {
                _context.Product.Remove(product);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(ProductIndex));
        }

        private bool ProductExists(int id)
        {
          return (_context.Product?.Any(e => e.productId == id)).GetValueOrDefault();
        }
        public IActionResult oye()
        {
            return View();  
        }
    }
}
