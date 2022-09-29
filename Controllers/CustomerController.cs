
using Microsoft.AspNetCore.Mvc;

using Microsoft.EntityFrameworkCore;
using SampleApp.Data;
using SampleApp.Models;

namespace SampleApp.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ApplicationdbContext _context;

        public CustomerController(ApplicationdbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
              return _context.Customer != null ? 
                          View(await _context.Customer.ToListAsync()) :
                          Problem("Entity set 'ApplicationdbContext.Customer'  is null.");
        }

      
      

        public IActionResult Create()
        {
            return View();
        }

   
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("customerId,customerFirstName,customerLastName,email,region,status")] Customer customer)
        {
            if (ModelState.IsValid)
                 
            {
                var temp = _context.Customer.OrderBy(X => X.customerId).Last();
                var temp2 = temp.customerId + 1;
                customer.customerId = temp2;
                _context.Add(customer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }
        public async Task<IActionResult> Details (int? id)
        {
            if (id == null || _context.Customer == null)
            {
                return NotFound();
            }
            var customer = await _context.Customer.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        // GET: Customer/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Customer == null)
            {
                return NotFound();
            }

            var customer = await _context.Customer.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("customerId,customerFirstName,customerLastName,email,region,status")] Customer customer)
        {
            if (id != customer.customerId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var sale = _context.Sale.FirstOrDefault(x => x.customerId == customer.customerId);
                    if (sale != null)
                    {
                        if (sale.customerId == customer.customerId)
                        {
                            if (sale.customerName != (customer.customerFirstName + " " + customer.customerLastName))
                            {
                                sale.customerName = (customer.customerFirstName + " " + customer.customerLastName);
                            }
                            _context.Update(sale);
                            _context.Update(customer);
                        }
                    }
                    else
                    {
                        _context.Update(customer);
                    }
                   
                   await  _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerExists(customer.customerId))
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
            return View(customer);
        }

        
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Customer == null)
            {
                return NotFound();
            }

            var customer = await _context.Customer
                .FirstOrDefaultAsync(m => m.customerId == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Customer == null)
            {
                return Problem("Entity set 'ApplicationdbContext.Customer'  is null.");
            }
            var customer = await _context.Customer.FindAsync(id);
            if (customer != null)
            {
                _context.Customer.Remove(customer);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerExists(int id)
        {
          return (_context.Customer?.Any(e => e.customerId == id)).GetValueOrDefault();
        }
    }
}
