using System.ComponentModel.DataAnnotations;

namespace MailroomApplication.Models;

public class Resident
{
    [Display(Name = "ID #")]
    public int residentID {get; set;}
    [Required]
    [Display(Name = "Name")]
    public string residentName {get; set;} = default!;
    [Required]
    [EmailAddress]
    [Display(Name = "E-Mail Address")]
    public string email {get; set;} = default!;
    [Required]
    [Display(Name = "Unit #")]
    public int unitNumber {get; set;}
    public List<Package> Packages {get; set;} = [];
    public List<ResidentPackage> ResidentPackages {get; set;} = [];
}