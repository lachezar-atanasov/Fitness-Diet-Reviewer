using Microsoft.AspNetCore.Identity;
using Microsoft.Identity.Client;

namespace Fitness_Diet_Reviewer.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? Description { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public int? Age { get; set; }

        public string? Stars { get; set; }

        public decimal? Height { get; set; }

        public decimal? Weight { get; set; }

        public string? Gender { get; set; }

        public string? ActivityLevel { get; set; }

        public virtual ICollection<FitnessDiet> FitnessDietFitnessInstructors { get; set; } = new List<FitnessDiet>();
        public virtual ICollection<Guideline> GuidelinesFitnessInstructors { get; set; } = new List<Guideline>();
        public virtual FitnessDiet FitnessDietUser { get; set; }
        public virtual RequestedFood RequestedFoodUser { get; set; }

    }
}
