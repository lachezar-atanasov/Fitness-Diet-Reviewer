using Fitness_Diet_Reviewer.Models;

namespace Fitness_Diet_Reviewer.ViewModels
{
    public class DailyMealRowViewModel
    {
        public FitnessDiet FitnessDiet { get; set; }
        public List<Food> Foods { get; set; }
        public List<DailyMealRow> DailyMealRows { get; set; }

    }
}
