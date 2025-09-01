using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EvangelionDatabase.Models;

namespace EvangelionDatabase.Pages.Evangelions
{
    public class EditModel : PageModel
    {
        private readonly ILogger<DetailsModel> _logger;
        private readonly EvangelionDatabase.Models.EVAContext _context;

        public EditModel(ILogger<DetailsModel> logger, EvangelionDatabase.Models.EVAContext context)
        {
            _logger = logger;
            _context = context;
        }

        [BindProperty]
        public Evangelion Evangelion { get; set; } = default!;
        public List<Pilot> Pilots { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Evangelion == null)
            {
                return NotFound();
            }

            var evangelion = await _context.Evangelion.Include(p => p.PilotEvangelions!).ThenInclude(pe => pe.Pilot).FirstOrDefaultAsync(m => m.EvangelionID == id);
            Pilots = _context.Pilot.ToList();
            if (evangelion == null)
            {
                return NotFound();
            }
            Evangelion = evangelion;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int[] selectedPilots)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            //_context.Attach(Evangelion).State = EntityState.Modified;

            var evangelionToUpdate = await _context.Evangelion.Include(e => e.PilotEvangelions!).ThenInclude(pe => pe.Pilot).FirstOrDefaultAsync(p => p.EvangelionID == Evangelion.EvangelionID);
            if (evangelionToUpdate != null)
            {
                evangelionToUpdate.EVAName = Evangelion.EVAName;

                UpdatePilotEvangelions(selectedPilots, evangelionToUpdate);
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EvangelionExists(Evangelion.EvangelionID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool EvangelionExists(int id)
        {
            return _context.Evangelion.Any(e => e.EvangelionID == id);
        }

        private void UpdatePilotEvangelions(int[] selectedPilots, Evangelion evangelionToUpdate)
        {
            if (selectedPilots == null)
            {
                evangelionToUpdate.PilotEvangelions = new List<PilotEvangelions>();
                return;
            }

            List<int> currentPilots = evangelionToUpdate.PilotEvangelions!.Select(p => p.PilotID).ToList();
            List<int> selectedPilotsList = selectedPilots.ToList();

            foreach (var pilot in _context.Pilot)
            {
                if (selectedPilotsList.Contains(pilot.PilotID))
                {
                    if (!currentPilots.Contains(pilot.PilotID))
                    {
                        evangelionToUpdate.PilotEvangelions!.Add(
                            new PilotEvangelions { EvangelionID = evangelionToUpdate.EvangelionID, PilotID = pilot.PilotID }
                        );
                        _logger.LogWarning($"{evangelionToUpdate.EVAName} ({evangelionToUpdate.EvangelionID}) - Assign {pilot.PilotID} {pilot.FirstName} {pilot.LastName}");
                    }
                }
                else
                {
                    if (currentPilots.Contains(pilot.PilotID))
                    {
                        PilotEvangelions pilotToRemove = evangelionToUpdate.PilotEvangelions!.SingleOrDefault(e => e.PilotID == pilot.PilotID)!;
                        _context.Remove(pilotToRemove);
                        _logger.LogWarning($"{evangelionToUpdate.EVAName} ({evangelionToUpdate.EvangelionID}) - Unassign {pilot.PilotID} {pilot.FirstName} {pilot.LastName}");
                    }
                }
            }
        }
    }
}
