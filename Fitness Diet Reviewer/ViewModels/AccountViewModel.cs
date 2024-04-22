using Fitness_Diet_Reviewer.Models;
using System;

namespace Fitness_Diet_Reviewer.ViewModels
{
    public class AccountViewModel
    {
        public FitnessDiet FitnessDiet { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public List<Food> Foods { get; set; }
        public List<DailyMealRow> DailyMealRows { get; set; }
        public List<Guideline> Guidelines { get; set; }

        public string[] DaysOfWeek { get; } = ["Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday"];
        public Dictionary<string, decimal> CaloriesPerDay { get; set; } = new();
        public Dictionary<string, decimal> ProteinsPerDay { get; set; } = new();
        public Dictionary<string, decimal> CarbohydratesPerDay { get; set; } = new();
        public Dictionary<string, decimal> FatsPerDay { get; set; } = new();

        public decimal AverageCaloriesPerDay { get; set; } = 0m;
        public bool ProfileIsNotCompleted { get; set; }
        public AccountViewModel()
        {
            foreach (var day in DaysOfWeek)
            {
                CaloriesPerDay[day] = 0;
            }
            foreach (var day in DaysOfWeek)
            {
                ProteinsPerDay[day] = 0;
            }
            foreach (var day in DaysOfWeek)
            {
                CarbohydratesPerDay[day] = 0;
            }
            foreach (var day in DaysOfWeek)
            {
                FatsPerDay[day] = 0;
            }
        }
    }
}
