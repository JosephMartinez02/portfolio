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
    public class IndexModel : PageModel
    {
        private readonly EvangelionDatabase.Models.EVAContext _context;

        public IndexModel(EvangelionDatabase.Models.EVAContext context)
        {
            _context = context;
        }

        public IList<Evangelion> Evangelion { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Evangelion != null)
            {
                Evangelion = await _context.Evangelion.Include(p => p.PilotEvangelions!).ThenInclude(pe => pe.Pilot).ToListAsync();
            }
        }
    }
}
