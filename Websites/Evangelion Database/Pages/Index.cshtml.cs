using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EvangelionDatabase.Models;

namespace EvangelionDatabase.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly EvangelionDatabase.Models.EVAContext _context;

    public IndexModel(ILogger<IndexModel> logger, EvangelionDatabase.Models.EVAContext context)
    {
        _logger = logger;
        _context = context;
    }
    public IList<Evangelion> Evangelion { get;set; } = default!;

    [BindProperty(SupportsGet = true)]
    public int PageNum {get; set;} = 1;
    public int PageSize {get; set;} = 10;

    [BindProperty(SupportsGet = true)]
    public string CurrentSort {get; set;}
    public async Task OnGetAsync()
    {
        var query = _context.Evangelion.Select(e => e);

        switch (CurrentSort)
        {
            case "first_asc":
                query = query.OrderBy(e => e.EVAName);
                break;
            case "first_desc":
                query = query.OrderByDescending(e => e.EVAName);
                break;
        }
        if (_context.Evangelion != null)
        {
            Evangelion = await query.Skip((PageNum-1)*PageSize).Take(PageSize).Include(p => p.PilotEvangelions!).ThenInclude(pe => pe.Pilot).ToListAsync();
        }
    }
}
