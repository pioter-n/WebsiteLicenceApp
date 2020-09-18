using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebsiteLicenceApp.Areas.Orders.Models;
using WebsiteLicenceApp.Data;
using WebsiteLicenceApp.Models;

namespace WebsiteLicenceApp.Areas.Orders.Controllers
{


    
    public class ViewModel
    {
        public int SelectedItemId { get; set; }
        public bool PaynamentCompleted { get; set; }
        public IReadOnlyCollection<SelectListItem> Items { get; set; } = new List<SelectListItem>();
    }

    [Area("Orders")]
    public class OrdersController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly UserManager<ApplicationUser> userManager;

        public OrdersController(ApplicationDbContext context, 
            UserManager<ApplicationUser> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }



        // GET: Orders/Orders
        public async Task<IActionResult> Index()
        {
            return View(await context.Order.ToListAsync());
        }

        // GET: Orders/Orders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await context.Order
                .FirstOrDefaultAsync(m => m.Id == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // GET: Orders/Orders/Create
        public async Task<IActionResult> Create()
        {
            var viewModel = new ViewModel
            {
                Items = await context.TypeLicences.Select(x => new SelectListItem(x.Name, x.Id.ToString())).ToArrayAsync(),
            };

            return View(viewModel);
        }

        // POST: Orders/Orders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            var licenseType = await context.TypeLicences
                .SingleOrDefaultAsync(x => x.Id == viewModel.SelectedItemId);

            if (licenseType == null)
            {
                ModelState.AddModelError(nameof(ViewModel.SelectedItemId), "Popraw");
                return View(viewModel);
            }

            var user = await userManager.GetUserAsync(User);
            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "Zaloguj się");
                return View(viewModel);
            }

            var order = new Order
            {
                IdUser = user.Id,
                Actual = viewModel.PaynamentCompleted,
                TypeLicence = licenseType,
            };

            await context.Order.AddAsync(order);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Orders/Orders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await context.Order.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            return View(order);
        }

        // POST: Orders/Orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,IdUser,Actual")] Order order)
        {
            if (id != order.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    context.Update(order);
                    await context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderExists(order.Id))
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
            return View(order);
        }

        // GET: Orders/Orders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await context.Order
                .FirstOrDefaultAsync(m => m.Id == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // POST: Orders/Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var order = await context.Order.FindAsync(id);
            context.Order.Remove(order);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderExists(int id)
        {
            return context.Order.Any(e => e.Id == id);
        }
    }
}
