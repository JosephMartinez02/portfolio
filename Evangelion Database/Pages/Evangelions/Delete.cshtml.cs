using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EvangelionDatabase.Models;

namespace EvangelionDatabase.Pages.Evangelions
{
    public class DeleteModel : PageModel
    {
        private readonly EvangelionDatabase.Models.EVAContext _context;

        public DeleteModel(EvangelionDatabase.Models.EVAContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Evangelion Evangelion { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Evangelion == null)
            {
                return NotFound();
            }

            var evangelion = await _context.Evangelion.FirstOrDefaultAsync(m => m.EvangelionID == id);

            if (evangelion == null)
            {
                return NotFound();
            }
            else 
            {
                Evangelion = evangelion;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Evangelion == null)
            {
                return NotFound();
            }
            var evangelion = await _context.Evangelion.FindAsync(id);

            if (evangelion != null)
            {
                Evangelion = evangelion;
                _context.Evangelion.Remove(Evangelion);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
