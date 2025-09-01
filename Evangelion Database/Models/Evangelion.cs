using System.ComponentModel.DataAnnotations;

namespace EvangelionDatabase.Models
{
    public class Evangelion
    {
        public int EvangelionID {get; set;}
        [Display(Name = "EVA Name")]
        [Required]
        public string EVAName {get; set;} = string.Empty;
        [Required]
        public string Description {get; set;} = string.Empty;
        [Required]
        public string Picture {get; set;} = string.Empty;
        public List<PilotEvangelions>? PilotEvangelions {get; set;} = default!;
    }
}