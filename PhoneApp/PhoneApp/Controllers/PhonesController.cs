using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PhoneApp.Models;

namespace PhoneApp.Controllers
{
    public class PhonesController : Controller
    {
        private readonly PhoneAppContext _context;

        public PhonesController(PhoneAppContext context)
        {
            _context = context;
        }

        // GET: Phones
        // GET: Movies
        public async Task<IActionResult> Index(double phoneRating, string searchString)
        {
            // Use LINQ to get list of genres.
            IQueryable<decimal> genreQuery = from m in _context.Phone
                                            orderby m.Rating
                                            select m.Rating;

            var movies = from m in _context.Phone
                         select m;

            if (!string.IsNullOrEmpty(searchString))
            {
                movies = movies.Where(s => s.Brand.Contains(searchString));
            }

            //if (!string.IsNullOrEmpty(movieGenre))
            //{
            //    movies = movies.Where(x => x.Genre == movieGenre);
            //}

            var movieGenreVM = new PhoneRatingViewModel
            {
                Rating = new SelectList(await genreQuery.Distinct().ToListAsync()),
                Phones = await movies.ToListAsync()
            };

            return View(movieGenreVM);
        }


        //public async Task<IActionResult> Index(string searchString)
        //{
        //    var phones = from p in _context.Phone
        //                 select p;

        //    if (!String.IsNullOrEmpty(searchString))
        //    {
        //        phones = phones.Where(s => s.Brand.Contains(searchString));
        //    }

        //    return View(await phones.ToListAsync());
        //}


        // GET: Phones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phone = await _context.Phone
                .SingleOrDefaultAsync(m => m.Id == id);
            if (phone == null)
            {
                return NotFound();
            }

            return View(phone);
        }

        // GET: Phones/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Phones/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Brand,ReleaseDate,Rating,Price")] Phone phone)
        {
            if (ModelState.IsValid)
            {
                _context.Add(phone);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(phone);
        }

        // GET: Phones/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phone = await _context.Phone.SingleOrDefaultAsync(m => m.Id == id);
            if (phone == null)
            {
                return NotFound();
            }
            return View(phone);
        }

        // POST: Phones/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Brand,ReleaseDate,Rating,Price")] Phone phone)
        {
            if (id != phone.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(phone);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PhoneExists(phone.Id))
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
            return View(phone);
        }

        // GET: Phones/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phone = await _context.Phone
                .SingleOrDefaultAsync(m => m.Id == id);
            if (phone == null)
            {
                return NotFound();
            }

            return View(phone);
        }

        // POST: Phones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var phone = await _context.Phone.SingleOrDefaultAsync(m => m.Id == id);
            _context.Phone.Remove(phone);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PhoneExists(int id)
        {
            return _context.Phone.Any(e => e.Id == id);
        }
    }
}
