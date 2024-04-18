using Fitness_Diet_Reviewer.Models;
using System.ComponentModel.DataAnnotations;

namespace Fitness_Diet_Reviewer.ViewModels
{
    public class FoodViewModel
    {
        public int FoodId { get; set; }

        public string FoodName { get; set; }

        [RegularExpression(@"^[0-9]+(?:[\.,][0-9]{1,2})?$", ErrorMessage = "Valid Decimal number with maximum 2 decimal places.")]
        public string Proteins { get; set; }
        [RegularExpression(@"^[0-9]+(?:[\.,][0-9]{1,2})?$", ErrorMessage = "Valid Decimal number with maximum 2 decimal places.")]
        public string Carbohydrates { get; set; }
        [RegularExpression(@"^[0-9]+(?:[\.,][0-9]{1,2})?$", ErrorMessage = "Valid Decimal number with maximum 2 decimal places.")]
        public string Fats { get; set; }

        public virtual ICollection<DailyMealRow> DailyMealRows { get; set; } = new List<DailyMealRow>();
        
    }
}
