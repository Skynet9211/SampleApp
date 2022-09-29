using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SampleApp.Data;
using SampleApp.Data.Helpers;
using SampleApp.Models;

namespace SampleApp.Controllers
{
    public class SaleController : Controller
    {
        private readonly ApplicationdbContext _context;

        public SaleController(ApplicationdbContext context)
        {
            _context = context;
        }

       
        public async Task<IActionResult> Index()
        {
            
            List<Product> pr = _context.Product.ToList();
            ViewBag.prtb1 = new SelectList(pr, "name", "name");
            return _context.Sale != null ? 
                          View(await _context.Sale.ToListAsync()) :
                          Problem("Entity set 'ApplicationdbContext.Sale'  is null.");
        }

       
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Sale == null)
            {
                return NotFound();
            }

            var sale = await _context.Sale
                .FirstOrDefaultAsync(m => m.saleId == id);
            if (sale == null)
            {
                return NotFound();
            }

            return View(sale);
        }

        
        public IActionResult Create()
        {
            List<Product> pr = _context.Product.ToList();
            ViewBag.prtb1 = new SelectList(pr, "name", "name");
            var cus = (from c in _context.Customer
                       select new SelectListItem
                       {
                           Text = c.customerFirstName + " " + c.customerLastName,
                           Value = c.customerFirstName + " " + c.customerLastName
                       });
            ViewBag.crtb1 = new SelectList(cus, "Value", "Text");


            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("saleId,saleDate,productId,product,customerId,customerName,price,quantity,total")] Sale sale)
        {
            if (ModelState.IsValid)
            {
                var temp = _context.Product.FirstOrDefault(x => x.name == sale.product);
                sale.productId = temp.productId;
                var temp2 = _context.Customer.FirstOrDefault(x => x.customerFirstName + " " + x.customerLastName == sale.customerName);
                sale.customerId = temp2.customerId;
                sale.price = temp.price;
                var sId = _context.Sale.OrderBy(x => x.saleId).Last();
                sale.saleId = sId.saleId + 1;
                sale.total = sale.price * sale.quantity;
               
                    _context.Add(sale);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sale);
        }

      
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Sale == null)
            {
                return NotFound();
            }

            var sale = await _context.Sale.FindAsync(id);
            if (sale == null)
            {
                return NotFound();
            }
            List<Product> pr = _context.Product.ToList();
            ViewBag.prtb1 = new SelectList(pr, "name", "name");
            var cus = (from c in _context.Customer
                       select new SelectListItem
                       {
                           Text = c.customerFirstName + " " + c.customerLastName,
                           Value = c.customerFirstName + " " + c.customerLastName
                       });
            ViewBag.crtb1 = new SelectList(cus, "Value", "Text");
            return View(sale);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("saleId,saleDate,productId,product,customerId,customerName,price,quantity,total")] Sale sale)
        {
            if (id != sale.saleId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {   
                    
                    _context.Update(sale);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SaleExists(sale.saleId))
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
            return View(sale);
        }

        
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Sale == null)
            {
                return NotFound();
            }

            var sale = await _context.Sale
                .FirstOrDefaultAsync(m => m.saleId == id);
            if (sale == null)
            {
                return NotFound();
            }

            return View(sale);
        }

       
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Sale == null)
            {
                return Problem("Entity set 'ApplicationdbContext.Sale'  is null.");
            }
            var sale = await _context.Sale.FindAsync(id);
            if (sale != null)
            {
                _context.Sale.Remove(sale);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Range1()
        {   
           
            return View();
        }
       

        private bool SaleExists(int id)
        {
          return (_context.Sale?.Any(e => e.saleId == id)).GetValueOrDefault();
        }
    }
}
