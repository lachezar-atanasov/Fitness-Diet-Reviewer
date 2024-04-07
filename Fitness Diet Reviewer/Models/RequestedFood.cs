using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Fitness_Diet_Reviewer.Models;

public partial class RequestedFood
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int FoodId { get; set; }
    public string FoodName { get; set; }

    public decimal Proteins { get; set; }

    public decimal Carbohydrates { get; set; }

    public decimal Fats { get; set; }

    public string? UserId { get; set; }

    public virtual ApplicationUser? User { get; set; }


}