using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Fitness_Diet_Reviewer.Models;
using Fitness_Diet_Reviewer.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace Fitness_Diet_Reviewer.Controllers
{
    public class DailyMealRowsController : Controller
    {
        private readonly DietReviewerContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public DailyMealRowsController(DietReviewerContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager =  userManager;
        }


        // GET: DailyMealRows/Create
        [Authorize]
        public IActionResult Create(string? eatTime, string? dayOfWeek)
        {
            ViewData["FitnessDietId"] = new SelectList(_context.FitnessDiets, "DietId", "DietId");
            ViewData["ProductId"] = new SelectList(_context.Foods, "FoodId", "FoodId");
            ViewData["EatTime"] = eatTime;
            ViewData["DayOfWeek"] = dayOfWeek;
            return View();
        }

        // POST: DailyMealRows/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DailyMealRowId,ProductId,AmountInGrams,FitnessDietId,DayOfWeek,EatTime")] DailyMealRow dailyMealRow)
        {
            if (ModelState.IsValid)
            {
                var currUser = _userManager.FindByNameAsync(User.Identity.Name).Result;
                dailyMealRow.FitnessDietId = _context.FitnessDiets.Where(d => d.UserId == currUser.Id).First().DietId;
                _context.Add(dailyMealRow);
                await _context.SaveChangesAsync();
                return RedirectToAction("ViewProfile", "Accounts", new { id = User.Identity.Name, fragment = "fitness-diet" });
            }
            ViewData["FitnessDietId"] = new SelectList(_context.FitnessDiets, "DietId", "DietId", dailyMealRow.FitnessDietId);
            ViewData["ProductId"] = new SelectList(_context.Foods, "FoodId", "FoodId", dailyMealRow.ProductId);
            return View(dailyMealRow);
        }

        // GET: DailyMealRows/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            DailyMealViewModel model = new DailyMealViewModel();
            var dailyMealRow = await _context.DailyMealRows.FindAsync(id);
            if (dailyMealRow == null)
            {
                return NotFound();
            }

            var diet = _context.FitnessDiets.FirstOrDefault(x => x.DietId == dailyMealRow.FitnessDietId);
            dailyMealRow.FitnessDiet = diet;
            ViewData["FitnessDietId"] = new SelectList(_context.FitnessDiets, "DietId", "DietId", dailyMealRow.FitnessDietId);
            ViewData["ProductId"] = new SelectList(_context.Foods, "FoodId", "FoodId", dailyMealRow.ProductId);
            var currFood = _context.Foods.FirstOrDefault(x => x.FoodId == dailyMealRow.ProductId);
            if(currFood!=null)
            {
                ViewData["FoodName"] = currFood.FoodName;
                ViewData["FoodId"] = currFood.FoodId;
            }

            var dailyMealRows = _context.DailyMealRows.ToList();
            model.DailyMealRow=dailyMealRow;
            model.DailyMealRows = dailyMealRows;

            return View(model);
        }

        // POST: DailyMealRows/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DailyMealRowId,ProductId,AmountInGrams,FitnessDietId,DayOfWeek,EatTime")] DailyMealRow dailyMealRow)
        {
            if (id != dailyMealRow.DailyMealRowId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var currUser = _userManager.FindByNameAsync(User.Identity.Name).Result;
                    dailyMealRow.FitnessDietId = _context.FitnessDiets.Where(d => d.UserId == currUser.Id).First().DietId;
                    _context.Update(dailyMealRow);
                    await _context.SaveChangesAsync();

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DailyMealRowExists(dailyMealRow.DailyMealRowId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("ViewProfile", "Accounts", new { id = User.Identity.Name, fragment = "fitness-diet" });
            }
            ViewData["FitnessDietId"] = new SelectList(_context.FitnessDiets, "DietId", "DietId", dailyMealRow.FitnessDietId);
            ViewData["ProductId"] = new SelectList(_context.Foods, "FoodId", "FoodId", dailyMealRow.ProductId);
            DailyMealViewModel model = new DailyMealViewModel();
            model.DailyMealRow = dailyMealRow;
            model.DailyMealRows = _context.DailyMealRows.ToList();
            return View(model);
        }

        // GET: DailyMealRows/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dailyMealRow = await _context.DailyMealRows
                .Include(d => d.FitnessDiet)
                .Include(d => d.Product)
                .FirstOrDefaultAsync(m => m.DailyMealRowId == id);
            if (dailyMealRow == null)
            {
                return NotFound();
            }

            return View(dailyMealRow);
        }

        // POST: DailyMealRows/Delete/5
        [HttpPost, ActionName("Delete")]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dailyMealRow = await _context.DailyMealRows.FindAsync(id);
            if (dailyMealRow != null)
            {
                _context.DailyMealRows.Remove(dailyMealRow);
            }

            await _context.SaveChangesAsync();
             return RedirectToAction("ViewProfile", "Accounts", new { id = User.Identity.Name, fragment = "fitness-diet" });
        }

        private bool DailyMealRowExists(int id)
        {
            return _context.DailyMealRows.Any(e => e.DailyMealRowId == id);
        }
    }
}
