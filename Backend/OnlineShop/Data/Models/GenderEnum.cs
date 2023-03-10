using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Data.Models;

public enum GenderEnum : short
{
    [Display(Name = "نامشخص")] Unkhown,
    [Display(Name = "مرد")] Male,
    [Display(Name = "زن")] Female,
}