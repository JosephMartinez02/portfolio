using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using EvangelionDatabase.Models;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EvangelionDatabase.Pages.Evangelions
{
    public class DetailsModel : PageModel
    {
        private readonly ILogger<DetailsModel> _logger;
        private readonly EvangelionDatabase.Models.EVAContext _context;

        public DetailsModel(ILogger<DetailsModel> logger, EvangelionDatabase.Models.EVAContext context)
        {
            _logger = logger;
            _context = context;
        }

        public Evangelion Evangelion { get; set; } = default!;

        [BindProperty]
        public int PilotIDtoDelete {get; set;}

        [BindProperty]
        [Display(Name = "Pilot")]
        public int PilotIDtoAdd {get; set;}
        public List<Pilot> AllPilots {get; set;} = default!;
        public SelectList PilotDropDown {get; set;} = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Evangelion == null)
            {
                return NotFound();
            }

            var evangelion = await _context.Evangelion.Include(p => p.PilotEvangelions!).ThenInclude(pe => pe.Pilot).FirstOrDefaultAsync(m => m.EvangelionID == id);
            AllPilots = await _context.Pilot.ToListAsync();
            PilotDropDown = new SelectList(AllPilots, "PilotID", "FirstName");
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

        public async Task<IActionResult> OnPostDeletePilotAsync(int? id)
        {
            _logger.LogWarning($"OnPost: EvangelionID {id}, DROP pilot {PilotIDtoDelete}");
            if (id == null)
            {
                return NotFound();
            }

            var evangelion = await _context.Evangelion.Include(p => p.PilotEvangelions!).ThenInclude(pe => pe.Pilot).FirstOrDefaultAsync(m => m.EvangelionID == id);
            if (evangelion == null)
            {
                return NotFound();
            }
            else
            {
                Evangelion = evangelion;
            }

            PilotEvangelions pilotToUnassign = _context.PilotEvangelion.Find(PilotIDtoDelete, id.Value)!;

            if (pilotToUnassign != null)
            {
                _context.Remove(pilotToUnassign);
                _context.SaveChanges();
            }
            else
            {
                _logger.LogWarning("Pilot is NOT assigned to any EVAs");
            }
            return RedirectToPage(new {id = id});
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            _logger.LogWarning($"OnPost: EvangelionID {id}, ADD Pilot {PilotIDtoAdd}");
            if (PilotIDtoAdd == 0)
            {
                ModelState.AddModelError("PilotIDtoAdd", "This field is a required field.");
                return Page();
            }
            if (id == null)
            {
                return NotFound();
            }

            var evangelion = await _context.Evangelion.Include(p => p.PilotEvangelions!).ThenInclude(pe => pe.Pilot).FirstOrDefaultAsync(m => m.EvangelionID == id);
            AllPilots = await _context.Pilot.ToListAsync();
            PilotDropDown = new SelectList(AllPilots, "PilotID", "FirstName");
            if (evangelion == null)
            {
                return NotFound();
            }
            else
            {
                Evangelion = evangelion;
            }
            
            if (!_context.PilotEvangelion.Any(pe => pe.PilotID == PilotIDtoAdd && pe.EvangelionID == id.Value))
            {
                PilotEvangelions pilotToAdd = new PilotEvangelions { EvangelionID = id.Value, PilotID = PilotIDtoAdd};
                _context.Add(pilotToAdd);
                _context.SaveChanges();
            }
            else
            {
                _logger.LogWarning("Pilot has already been assigned to this EVA.");
            }

            return RedirectToPage(new {id = id});
        }
    }
}
