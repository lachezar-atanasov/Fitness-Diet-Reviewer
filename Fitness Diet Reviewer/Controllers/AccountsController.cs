using Fitness_Diet_Reviewer.Models;
using Fitness_Diet_Reviewer.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Fitness_Diet_Reviewer.Controllers
{
    public class AccountsController : Controller
    {
        private readonly DietReviewerContext _context;

        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;
        public AccountsController(DietReviewerContext context, RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task<IActionResult> FitnessInstructors(string sortOrder, string currentFilter, string searchString, int? pageIndex, int pageSize = 10)
        {

            ViewData["NameSort"] = String.IsNullOrEmpty(sortOrder) ? "nameSort_desc" : "";
            //ViewData["CarbohydratesSort"] = sortOrder == "carbohydrates" ? "carbohydrates_desc" : "carbohydrates";

            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;
            ViewData["CurrentSort"] = sortOrder;

            var fitnessInsturctorsRoleId = _roleManager.FindByNameAsync("Fitness Instructor").Result.Id;

            var users = from userRole in _context.UserRoles
                        join user in _context.Users on userRole.UserId equals user.Id
                        where userRole.RoleId == fitnessInsturctorsRoleId
                        select user;

            if (!String.IsNullOrEmpty(searchString))
            {
                users = users.Where(f =>
                    f.UserName.Contains(searchString)
                );
            }



            switch (sortOrder)
            {
                case "nameSort_desc":
                    users = users.OrderByDescending(f => f.UserName);
                    break;

                default:
                    users = users.OrderBy(f => f.UserName);
                    break;
            }

            ViewData["TotalCount"] = users.Count();

            int pageNumber = pageIndex ?? 1;

            var paginatedList = await PaginatedList<ApplicationUser>.CreateAsync(users.AsQueryable(), pageNumber, pageSize);

            return View(paginatedList);
        }

        [Authorize]
        public async Task<IActionResult> GetStatusIndicatorData(int id)
        {
            // Replace with your actual logic to determine the status
            var fitnessDiet = _context.FitnessDiets
                .Include(x=>x.Guidelines)
                .FirstOrDefault(x => x.DietId == id);
            if (fitnessDiet == null)
            {
                return NotFound(); // Handle scenario where FitnessDiet with the given id is not found
            }

            var newIsReviewed = !fitnessDiet.Guidelines.All(x => x.IsLiked == false || x.IsLiked == null);
            if (newIsReviewed)
            {
                fitnessDiet.Status = "Reviewed";
                
            }
            else
            {
                fitnessDiet.Status = "PendingFeedback";
            }

            _context.SaveChanges();

            var model = new
            {
                isReviewed = newIsReviewed,
                status = fitnessDiet.Status,
                dietId = fitnessDiet.DietId
            };

            return Json(model);
        }
        [Authorize]
        public async Task<IActionResult> SetGuidelineStatus(int id, bool? isLiked)
        {
            var guidelineToChange = _context.Guideline
                .Include(x=>x.FitnessDiet)
                .Include(x=>x.FitnessDiet.Guidelines)
                .FirstOrDefault(x => x.GuidelineId == id);
            if (guidelineToChange == null)
            {
                return NotFound();
            }

            var currUser = await _userManager.FindByIdAsync(guidelineToChange.FitnessDiet.UserId);
            if (currUser == null)
            {
                return NotFound();
            }

            guidelineToChange.IsLiked = isLiked;

            if (guidelineToChange.FitnessDiet.Guidelines.All(x => x.IsLiked == false || x.IsLiked == null))
            {
                guidelineToChange.FitnessDiet.Status = "PendingFeedback";
            }
                _context.SaveChanges();

            return Json(new { success = true, userName = currUser.UserName });
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Edit(string? description, string name, string? weight, string? height, string? gender, string? age, string? activity, string? first_name, string? last_name)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = await _userManager.FindByNameAsync(name);

                if (description != null)
                {
                    user.Description = description;
                }
                if (weight != null)
                {
                    user.Weight = decimal.Parse(weight);
                }
                if (height != null)
                {
                    user.Height = decimal.Parse(height);
                }
                if (age != null)
                {
                    user.Age = int.Parse(age);
                }
                if (gender != null)
                {
                    user.Gender = gender;
                }
                if (activity != null)
                {
                    user.ActivityLevel = activity;
                }
                if (first_name != null)
                {
                    user.FirstName = first_name;
                }
                if (last_name != null)
                {
                    user.LastName = last_name;
                }

                // Save changes to the database
                await _userManager.UpdateAsync(user);

                return RedirectToAction("ViewProfile", "Accounts", new { id = name });
            }

            TempData["Message"] = "Validation failed. Please check your input.";
            return RedirectToAction("ViewProfile", "Accounts");
        }

        [Authorize]
        public async Task<IActionResult> UsersList(string sortOrder, string currentFilter, string searchString, int? pageIndex, int pageSize = 10)
        {

            ViewData["NameSort"] = String.IsNullOrEmpty(sortOrder) ? "nameSort_desc" : "";
            ViewData["AgeSort"] = sortOrder == "ages" ? "ages_desc" : "ages";
            ViewData["WeightSort"] = sortOrder == "weight" ? "weight_desc" : "weight";
            ViewData["GenderSort"] = sortOrder == "gender" ? "gender_desc" : "gender";
            //ViewData["CarbohydratesSort"] = sortOrder == "carbohydrates" ? "carbohydrates_desc" : "carbohydrates";

            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;
            ViewData["CurrentSort"] = sortOrder;

            var users = from userRole in _context.UserRoles
                        join user in _context.Users on userRole.UserId equals user.Id
                        select user;

            // Filter foods based on the search string
            if (!String.IsNullOrEmpty(searchString))
            {
                users = users.Where(f =>
                    f.UserName.Contains(searchString)
                );
            }



            switch (sortOrder)
            {
                case "nameSort_desc":
                    users = users.OrderByDescending(u => u.UserName);
                    break;
                case "ages":
                    users = users.OrderBy(u => u.Age);
                    break;
                case "ages_desc":
                    users = users.OrderByDescending(u => u.Age);
                    break;
                case "weight":
                    users = users.OrderBy(u => u.Weight);
                    break;
                case "weight_desc":
                    users = users.OrderByDescending(u => u.Weight);
                    break;
                case "gender":
                    users = users.OrderBy(u => u.Gender);
                    break;
                case "gender_desc":
                    users = users.OrderByDescending(u => u.Gender);
                    break;
                // Add more cases for other sorting options

                default:
                    users = users.OrderBy(u => u.UserName);
                    break;
            }


            ViewData["TotalCount"] = users.Count();

            int pageNumber = pageIndex ?? 1;

            var paginatedList = await PaginatedList<ApplicationUser>.CreateAsync(users.AsQueryable(), pageNumber, pageSize);

            return View(paginatedList);
        }
        [Authorize]
        public async Task<IActionResult> FitnessDietsList(string sortOrder, string currentFilter, string searchString, int? pageIndex, int pageSize = 10)
        {

            ViewData["NameSort"] = String.IsNullOrEmpty(sortOrder) ? "nameSort_desc" : "";
            ViewData["AgeSort"] = sortOrder == "ages" ? "ages_desc" : "ages";
            ViewData["WeightSort"] = sortOrder == "weight" ? "weight_desc" : "weight";
            ViewData["GenderSort"] = sortOrder == "gender" ? "gender_desc" : "gender";
            //ViewData["CarbohydratesSort"] = sortOrder == "carbohydrates" ? "carbohydrates_desc" : "carbohydrates";

            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["CurrentFilter"] = searchString;
            ViewData["CurrentSort"] = sortOrder;

            var users = from userRole in _context.UserRoles
                        join user in _context.Users on userRole.UserId equals user.Id
                        select user;

            // Filter foods based on the search string
            if (!String.IsNullOrEmpty(searchString))
            {
                users = users.Where(f =>
                    f.UserName.Contains(searchString)
                );
            }

            users = users.Where(x => x.FitnessDietUser.Status == "PendingFeedback");



            switch (sortOrder)
            {
                case "nameSort_desc":
                    users = users.OrderByDescending(u => u.UserName);
                    break;
                case "ages":
                    users = users.OrderBy(u => u.Age);
                    break;
                case "ages_desc":
                    users = users.OrderByDescending(u => u.Age);
                    break;
                case "weight":
                    users = users.OrderBy(u => u.Weight);
                    break;
                case "weight_desc":
                    users = users.OrderByDescending(u => u.Weight);
                    break;
                case "gender":
                    users = users.OrderBy(u => u.Gender);
                    break;
                case "gender_desc":
                    users = users.OrderByDescending(u => u.Gender);
                    break;
                // Add more cases for other sorting options

                default:
                    users = users.OrderBy(u => u.UserName);
                    break;
            }


            ViewData["TotalCount"] = users.Count();

            int pageNumber = pageIndex ?? 1;

            var paginatedList = await PaginatedList<ApplicationUser>.CreateAsync(users.AsQueryable(), pageNumber, pageSize);

            return View(paginatedList);
        }


        [Authorize]
        public IActionResult ViewProfile([FromRoute(Name = "id")] string name)
        {
            if (!_context.Users.Any(x => x.UserName == name))
            {
                return RedirectToAction("Index", "Home");
            }
            var currUser = _userManager.FindByNameAsync(User.Identity.Name).Result;

            string userId = currUser.Id;

            if (!_context.FitnessDiets.Any(x => x.UserId == userId))
            {
                var newFitnessDiet = new FitnessDiet() { UserId = userId };
                _context.FitnessDiets.Add(newFitnessDiet);
                _context.SaveChanges();
            }

            ViewData["Username"] = name;

            var user = _context.ApplicationUsers.Where(x => x.UserName == name).First();
            bool hasFitnessDiet = _context.FitnessDiets.Where(x => x.UserId == user.Id).ToList().Count>0;
            if (!hasFitnessDiet)
            {
                var userToAssign = _userManager.FindByNameAsync(name).Result;
                var newFitnessDiet = new FitnessDiet() { UserId = userToAssign.Id };
                _context.FitnessDiets.Add(newFitnessDiet);
                _context.SaveChanges();
            }
            var fitnessDiet = _context.FitnessDiets.Where(x => x.UserId == user.Id).First();
            var guidelines = _context.Guideline.Where(x => x.FitnessDietId == fitnessDiet.DietId).ToList();
            var dailyMealRows = _context.DailyMealRows.Where(x => x.FitnessDietId == fitnessDiet.DietId).ToList();

            var model = new AccountViewModel();

            model.ApplicationUser = user;
            model.FitnessDiet = fitnessDiet;
            model.DailyMealRows = dailyMealRows;
            model.Guidelines = guidelines;
            model.Foods = _context.Foods.ToList();
            bool profileIsNotCompleted = model.ApplicationUser.Age == null ||
                                         model.ApplicationUser.Gender == null ||
                                         model.ApplicationUser.ActivityLevel == null ||
                                         model.ApplicationUser.Height == null ||
                                         model.ApplicationUser.Weight == null;
            model.ProfileIsNotCompleted = profileIsNotCompleted;

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Fitness Instructor")]
        public async Task<IActionResult> AddGuideline(string id, string? guidelines)
        {
            var fitnessDiets = _context.FitnessDiets.FirstOrDefault(x=>x.DietId==int.Parse(id));
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var currUser = await _userManager.FindByIdAsync(fitnessDiets.UserId);
            var gudeilineToAdd = new Guideline()
            {
                Content = guidelines,
                FitnessDietId = int.Parse(id),
                FitnessInstructorId = user.Id
            };
            _context.Guideline.AddAsync(gudeilineToAdd);
            _context.SaveChanges();
            fitnessDiets.Status = "Reviewed";
            _context.Update(fitnessDiets);
            await _context.SaveChangesAsync();
            return RedirectToAction("ViewProfile", "Accounts", new { id = currUser.UserName });
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> ChangeStatus(int id, string newStatus)
        {
            var fitnessDiets = _context.FitnessDiets.FirstOrDefault(x => x.DietId == id);
            if (fitnessDiets != null)
            {
                fitnessDiets.Status = newStatus;
                _context.Update(fitnessDiets);
                await _context.SaveChangesAsync();
                var currUser = await _userManager.FindByIdAsync(fitnessDiets.UserId);

                return RedirectToAction("ViewProfile", "Accounts", new { id = currUser.UserName });
            }
            return RedirectToAction("Index", "Home");
        }
            [Authorize]
            [HttpPost]
            public async Task<IActionResult> RemoveGuideline(string id)
            {
                var user = await _userManager.FindByNameAsync(User.Identity.Name);
                
                var guidelineToRemove = _context.Guideline
                    .FirstOrDefault(x => x.FitnessDietId == int.Parse(id) && (x.FitnessInstructorId == user.Id || User.IsInRole("Administrator")));

                if (guidelineToRemove != null)
                {
                    var fitnessDietOfGuideline = _context.FitnessDiets
                        .Include(x => x.Guidelines)
                        .FirstOrDefault(x => x.DietId == guidelineToRemove.FitnessDietId);
                _context.Remove(guidelineToRemove);
                    _context.SaveChanges();
                    if (fitnessDietOfGuideline.Guidelines.Count == 0)
                    {
                        fitnessDietOfGuideline.Status = "PendingFeedback";
                        _context.Update(fitnessDietOfGuideline);
                        await _context.SaveChangesAsync();
                    }
                    return Json(new { success = true });
                }

                return Json(new { success = false });
            }

        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Promote([FromRoute(Name = "id")] string name)
        {
            var user = _userManager.FindByNameAsync(name).Result;
            if (!string.IsNullOrWhiteSpace(name))
            {
                var currentRole = _userManager.GetRolesAsync(user).Result.First();
                
                if (currentRole == "User") 
                {
                    await _userManager.RemoveFromRoleAsync(user, currentRole);
                    user.Stars = user.Stars + '*';
                    _context.Update(user);
                    _context.SaveChanges();
                    await _userManager.AddToRoleAsync(user, "Fitness Instructor");
                }
                else if(currentRole == "Fitness Instructor" && user.Stars != "*****")
                {

                    user.Stars = user.Stars + '*';
                    _context.Update(user);
                    _context.SaveChanges();
                }
                else if(currentRole == "Fitness Instructor" && user.Stars == "*****")
                {
                    user.Stars = "";
                    _context.Update(user);
                    _context.SaveChanges();
                    await _userManager.RemoveFromRoleAsync(user, currentRole);
                    await _userManager.AddToRoleAsync(user, "Administrator");
                }
                    }
            return RedirectToAction("ViewProfile", "Accounts", new { id = user.UserName});

        }

        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Demote([FromRoute(Name = "id")] string name)
        {
            var user = _userManager.FindByNameAsync(name).Result;
            if (!string.IsNullOrWhiteSpace(name))
            {

                var currentRole = _userManager.GetRolesAsync(user).Result.First();

                if (currentRole == "Administrator")
                {
                    await _userManager.RemoveFromRoleAsync(user, currentRole);
                    user.Stars = "*****";
                    _context.Update(user);
                    _context.SaveChanges();
                    await _userManager.AddToRoleAsync(user, "Fitness Instructor");
                }
                else if (currentRole == "Fitness Instructor" && user.Stars != "*")
                {

                    user.Stars = user.Stars.Substring(0, user.Stars.Length - 1);
                    _context.Update(user);
                    _context.SaveChanges();
                }
                else if (currentRole == "Fitness Instructor" && user.Stars == "*")
                {
                    user.Stars = "";
                    _context.Update(user);
                    _context.SaveChanges();
                    await _userManager.RemoveFromRoleAsync(user, currentRole);
                    await _userManager.AddToRoleAsync(user, "User");
                }
            }
            return RedirectToAction("ViewProfile", "Accounts", new { id = user.UserName });

        }

        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> RemoveUser([FromRoute(Name = "id")] string name)
        {
            var user = _userManager.FindByNameAsync(name).Result;
            if (!string.IsNullOrWhiteSpace(name))
            {
                await _userManager.DeleteAsync(user);

            }
            return RedirectToAction("UsersList", "Accounts");

        }
    }
}
