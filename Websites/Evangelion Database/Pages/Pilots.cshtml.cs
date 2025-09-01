using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EvangelionDatabase.Models;

namespace EvangelionDatabase.Pages;

public class PilotModel : PageModel
{
    private readonly ILogger<PilotModel> _logger;
    private readonly EvangelionDatabase.Models.EVAContext _context;

    public PilotModel(ILogger<PilotModel> logger, EvangelionDatabase.Models.EVAContext context)
    {
        _logger = logger;
        _context = context;
    }
    public IList<Pilot> Pilot { get;set; } = default!;

    public async Task OnGetAsync()
    {
        if (_context.Pilot != null)
        {
            Pilot = await _context.Pilot.Include(p => p.PilotEvangelions!).ThenInclude(pe => pe.Evangelion).ToListAsync();
        }
    }
}