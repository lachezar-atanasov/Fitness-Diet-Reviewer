using Fitness_Diet_Reviewer.Models;

namespace Fitness_Diet_Reviewer.ViewModels
{
    public class DailyMealViewModel
    {
        public DailyMealRow DailyMealRow { get; set; }

        public ICollection<DailyMealRow> DailyMealRows { get; set; } = new List<DailyMealRow>();
        
    }
}
