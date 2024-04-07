using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Fitness_Diet_Reviewer.Models;
using Microsoft.AspNetCore.Authorization;
using Fitness_Diet_Reviewer.ViewModels;
using System.Drawing.Printing;
using Microsoft.AspNetCore.Identity;

namespace Fitness_Diet_Reviewer.Controllers
{
    public class FoodsController : Controller
    {
        private readonly DietReviewerContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public FoodsController(DietReviewerContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> RequestedFoods(string sortOrder, string currentFilter, string searchString, int? pageIndex, int pageSize = 10)
        {

            ViewData["FoodNameSort"] = String.IsNullOrEmpty(sortOrder) ? "foodName_desc" : "";
            ViewData["CarbohydratesSort"] = sortOrder == "carbohydrates" ? "carbohydrates_desc" : "carbohydrates";
            ViewData["FatsSort"] = sortOrder == "fats" ? "fats_desc" : "fats";
            ViewData["ProteinsSort"] = sortOrder == "proteins" ? "proteins_desc" : "proteins";
            ViewData["CaloriesSort"] = sortOrder == "calories" ? "calories_desc" : "calories";

            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            // Query the database based on the sort order
            var foods = from f in _context.RequestedFoods
                        select f;

            // Filter foods based on the search string
            if (!String.IsNullOrEmpty(searchString))
            {
                foods = foods.Where(f =>
                    f.FoodName.Contains(searchString) ||
                    f.Carbohydrates.ToString().Contains(searchString) ||
                    f.Fats.ToString().Contains(searchString) ||
                    f.Proteins.ToString().Contains(searchString)
                );
            }



            switch (sortOrder)
            {
                case "foodName_desc":
                    foods = foods.OrderByDescending(f => f.FoodName);
                    break;
                case "carbohydrates":
                    foods = foods.OrderBy(f => f.Carbohydrates);
                    break;
                case "carbohydrates_desc":
                    foods = foods.OrderByDescending(f => f.Carbohydrates);
                    break;
                case "fats":
                    foods = foods.OrderBy(f => f.Fats);
                    break;
                case "fats_desc":
                    foods = foods.OrderByDescending(f => f.Fats);
                    break;
                case "proteins":
                    foods = foods.OrderBy(f => f.Proteins);
                    break;
                case "proteins_desc":
                    foods = foods.OrderByDescending(f => f.Proteins);
                    break;
                case "calories":
                    foods = foods.OrderBy(f => ((f.Fats * 9) + (f.Carbohydrates * 4) + (f.Proteins * 4)));
                    break;
                case "calories_desc":
                    foods = foods.OrderByDescending(f => ((f.Fats * 9) + (f.Carbohydrates * 4) + (f.Proteins * 4)));
                    break;
                // Add cases for other properties as needed
                default:
                    foods = foods.OrderBy(f => f.FoodName);
                    break;
            }

            ViewData["TotalCount"] = foods.Count();

            int pageNumber = pageIndex ?? 1;

            var paginatedFoods = await PaginatedList<RequestedFood>.CreateAsync(foods.AsQueryable(), pageNumber, pageSize);

            return View(paginatedFoods);
        }
        public async Task<IActionResult> Index(string sortOrder, string currentFilter, string searchString, int? pageIndex, int pageSize = 10)
        {
       
            ViewData["FoodNameSort"] = String.IsNullOrEmpty(sortOrder) ? "foodName_desc" : "";
            ViewData["CarbohydratesSort"] = sortOrder == "carbohydrates" ? "carbohydrates_desc" : "carbohydrates";
            ViewData["FatsSort"] = sortOrder == "fats" ? "fats_desc" : "fats";
            ViewData["ProteinsSort"] = sortOrder == "proteins" ? "proteins_desc" : "proteins";
            ViewData["CaloriesSort"] = sortOrder == "calories" ? "calories_desc" : "calories";

            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;

            // Query the database based on the sort order
            var foods = from f in _context.Foods
                        select f;

            // Filter foods based on the search string
            if (!String.IsNullOrEmpty(searchString))
            {
                foods = foods.Where(f =>
                    f.FoodName.Contains(searchString) ||
                    f.Carbohydrates.ToString().Contains(searchString) ||
                    f.Fats.ToString().Contains(searchString) ||
                    f.Proteins.ToString().Contains(searchString)
                );
            }



            switch (sortOrder)
            {
                case "foodName_desc":
                    foods = foods.OrderByDescending(f => f.FoodName);
                    break;
                case "carbohydrates":
                    foods = foods.OrderBy(f => f.Carbohydrates);
                    break;
                case "carbohydrates_desc":
                    foods = foods.OrderByDescending(f => f.Carbohydrates);
                    break;
                case "fats":
                    foods = foods.OrderBy(f => f.Fats);
                    break;
                case "fats_desc":
                    foods = foods.OrderByDescending(f => f.Fats);
                    break;
                case "proteins":
                    foods = foods.OrderBy(f => f.Proteins);
                    break;
                case "proteins_desc":
                    foods = foods.OrderByDescending(f => f.Proteins);
                    break;
                case "calories":
                    foods = foods.OrderBy(f => ((f.Fats*9)+(f.Carbohydrates*4)+(f.Proteins*4)));
                    break;
                case "calories_desc":
                    foods = foods.OrderByDescending(f => ((f.Fats * 9) + (f.Carbohydrates * 4) + (f.Proteins * 4)));
                    break;
                // Add cases for other properties as needed
                default:
                    foods = foods.OrderBy(f => f.FoodName);
                    break;
            }

            ViewData["TotalCount"] = foods.Count();

            int pageNumber = pageIndex ?? 1;

            var paginatedFoods = await PaginatedList<Food>.CreateAsync(foods.AsQueryable(), pageNumber, pageSize);

            return View(paginatedFoods);
        }

        public ActionResult Search(string term)
        {
            var matchingFoods = _context.Foods
                  .Where(f => f.FoodName.Contains(term))
                  .Select(f => new { id = f.FoodId, text = f.FoodName })
                  .ToList();

            return Json(matchingFoods);
        }


        // GET: Foods/Create
        [Authorize(Roles = "Administrator")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Foods/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Create([Bind("FoodName,Proteins,Carbohydrates,Fats")] Food food)
        {
            if (ModelState.IsValid)
            {
                _context.Add(food);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(food);
        }

        // GET: Foods/Edit/5
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var food = await _context.Foods.FindAsync(id);
            if (food == null)
            {
                return NotFound();
            }
            return View(food);
        }


        
        [Authorize]
        public IActionResult RequestFood()
        {
            return View();
        }
        // POST: Foods/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RequestFood([Bind("FoodId,FoodName,Proteins,Carbohydrates,Fats,UserId")] RequestedFood food)
        {
            if (ModelState.IsValid)
            {
                var currUser = await _userManager.FindByNameAsync(food.UserId);
                food.UserId = currUser.Id;
                _context.Add(food);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Requested food successfully added!";
                return RedirectToAction(nameof(RequestFood));
            }
            return View(food);
        }

        // GET: Foods/Delete/5
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var food = await _context.Foods
                .FirstOrDefaultAsync(m => m.FoodId == id);
            if (food == null)
            {
                return NotFound();
            }

            return View(food);
        }

        // POST: Foods/Delete/5
        [Authorize(Roles = "Administrator")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var food = await _context.Foods.FindAsync(id);
            if (food != null)
            {
                _context.Foods.Remove(food);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [Authorize]
        public async Task<IActionResult> AddRequestedFood(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var food = await _context.RequestedFoods.FindAsync(id);
            if (food == null)
            {
                return NotFound();
            }
            return View(food);
        }
        [Authorize]
        public async Task<IActionResult> RemoveRequestedFood(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var food = await _context.RequestedFoods
                .FirstOrDefaultAsync(m => m.FoodId == id);
            if (food == null)
            {
                return NotFound();
            }

            var foodToRemove = await _context.RequestedFoods.FindAsync(id);
            if (food != null)
            {
                _context.RequestedFoods.Remove(foodToRemove);
            }

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(RequestedFoods));
        }



        private bool FoodExists(int id)
        {
            return _context.Foods.Any(e => e.FoodId == id);
        }
    }
}
