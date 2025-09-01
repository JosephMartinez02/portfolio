using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using EvangelionDatabase.Models;

namespace EvangelionDatabase.Pages.Evangelions
{
    public class CreateModel : PageModel
    {
        private readonly EvangelionDatabase.Models.EVAContext _context;

        public CreateModel(EvangelionDatabase.Models.EVAContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Evangelion Evangelion { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Evangelion == null || Evangelion == null)
            {
                return Page();
            }

            _context.Evangelion.Add(Evangelion);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
