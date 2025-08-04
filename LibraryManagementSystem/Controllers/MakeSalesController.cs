using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LibraryManagementSystem.Data;
using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Controllers
{
    public class MakeSalesController : Controller
    {
        ApplicationDbContext _context = new ApplicationDbContext();

        // GET: MakeSales
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var sales = await _context.Sales
                .Include(s => s.Customer)
                .Include(s => s.Books)
                .ToListAsync();
            return View(sales);
        }

        // GET: MakeSales/Create
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Books = _context.Stock.ToList();
            ViewBag.Customers = _context.Customers.ToList();
            return View();
        }

        // POST: MakeSales/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MakeSale makeSale, List<int> BookId, List<int> QuantityOfSale)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // Validate that we have books and quantities
                    if (BookId == null || !BookId.Any() || QuantityOfSale == null || !QuantityOfSale.Any())
                    {
                        ModelState.AddModelError("", "Please select at least one book with quantity.");
                        ViewBag.Books = _context.Stock.ToList();
                        ViewBag.Customers = _context.Customers.ToList();
                        return View(makeSale);
                    }

                    // Validate that BookId and QuantityOfSale have the same count
                    if (BookId.Count != QuantityOfSale.Count)
                    {
                        ModelState.AddModelError("", "Book selection and quantity mismatch.");
                        ViewBag.Books = _context.Stock.ToList();
                        ViewBag.Customers = _context.Customers.ToList();
                        return View(makeSale);
                    }

                    // Remove empty selections (where BookId is 0 or quantity is 0)
                    var validSelections = new List<(int bookId, int quantity)>();
                    for (int i = 0; i < BookId.Count; i++)
                    {
                        if (BookId[i] > 0 && QuantityOfSale[i] > 0)
                        {
                            validSelections.Add((BookId[i], QuantityOfSale[i]));
                        }
                    }

                    if (!validSelections.Any())
                    {
                        ModelState.AddModelError("", "Please select at least one valid book with quantity.");
                        ViewBag.Books = _context.Stock.ToList();
                        ViewBag.Customers = _context.Customers.ToList();
                        return View(makeSale);
                    }

                    // Validate stock availability
                    foreach (var selection in validSelections)
                    {
                        var book = await _context.Stock.FindAsync(selection.bookId);
                        if (book == null)
                        {
                            ModelState.AddModelError("", $"Book with ID {selection.bookId} not found.");
                            ViewBag.Books = _context.Stock.ToList();
                            ViewBag.Customers = _context.Customers.ToList();
                            return View(makeSale);
                        }

                        if (book.Quantity < selection.quantity)
                        {
                            ModelState.AddModelError("", $"Insufficient stock for {book.Title}. Available: {book.Quantity}, Requested: {selection.quantity}");
                            ViewBag.Books = _context.Stock.ToList();
                            ViewBag.Customers = _context.Customers.ToList();
                            return View(makeSale);
                        }
                    }

                    // Validate customer exists
                    var customer = await _context.Customers.FindAsync(makeSale.CustomerId);
                    if (customer == null)
                    {
                        ModelState.AddModelError("CustomerId", "Selected customer not found.");
                        ViewBag.Books = _context.Stock.ToList();
                        ViewBag.Customers = _context.Customers.ToList();
                        return View(makeSale);
                    }

                    // Create separate MakeSale records for each book (based on the current database schema)
                    // The foreign key constraint expects a single book per sale record
                    foreach (var selection in validSelections)
                    {
                        var book = await _context.Stock.FindAsync(selection.bookId);
                        
                        var saleRecord = new MakeSale
                        {
                            CustomerId = makeSale.CustomerId,
                            SaleDate = makeSale.SaleDate,
                            BookId = new List<int> { selection.bookId }, // Single book per record
                            QuantityOfSale = new List<int> { selection.quantity }, // Single quantity per record
                            TotalPriceOfSale = book.Price * selection.quantity,
                            BooksId = selection.bookId // Set the foreign key properly
                        };

                        _context.Add(saleRecord);

                        // Update stock quantity
                        book.Quantity -= selection.quantity;
                        _context.Update(book);
                    }

                    await _context.SaveChangesAsync();
                    TempData["SuccessMessage"] = "Sale created successfully!";
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"An error occurred while creating the sale: {ex.Message}");
            }

            // If we got this far, something failed, redisplay form
            ViewBag.Books = _context.Stock.ToList();
            ViewBag.Customers = _context.Customers.ToList();
            return View(makeSale);
        }

        // GET: MakeSales/Delete/5
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var makeSale = await _context.Sales
                .FirstOrDefaultAsync(m => m.MakeSaleId == id);
            if (makeSale == null)
            {
                return NotFound();
            }

            return View(makeSale);
        }

        // POST: MakeSales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var makeSale = await _context.Sales.FindAsync(id);
            if (makeSale != null)
            {
                _context.Sales.Remove(makeSale);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MakeSaleExists(int id)
        {
            return _context.Sales.Any(e => e.MakeSaleId == id);
        }
    }
}
