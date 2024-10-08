﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Fitness_Diet_Reviewer.Models;

public partial class FitnessDiet
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int DietId { get; set; }
    public string UserId { get; set; }
    public string Status { get; set; }
    public virtual ICollection<DailyMealRow> DailyMealRows { get; set; } = new List<DailyMealRow>();
    public virtual ICollection<Guideline> Guidelines { get; set; } = new List<Guideline>();
    public virtual ApplicationUser User { get; set; }
}