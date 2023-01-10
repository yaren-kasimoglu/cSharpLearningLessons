using System.ComponentModel.DataAnnotations;

namespace _01_ModelNedir.Models.Enums
{
    public enum WorkingType
    {
        [Display(Name ="Tam Zamanlı")]
        FullTime=1,
        [Display(Name = "Yarı Zamanlı")]
        PartTime =2,
        [Display(Name = "Proje Bazlı")]
        ProjectBase =3,
        [Display(Name = "Serbest Zamanlı")]
        Freelance =4
    }
}
