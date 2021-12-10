using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FinalProject.Models;

using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FinalProject.Pages.Tournaments
{
    public class DetailsModel : PageModel
    {

        private readonly ILogger<DetailsModel> _logger;
        private readonly FinalProject.Models.Context _context;

        public DetailsModel(FinalProject.Models.Context context, ILogger<DetailsModel> logger)
        {
            _logger = logger;
            _context = context;
        }

        public Tournament Tournament { get; set; }

        [BindProperty]
        public int PlayerIdToDelete {get; set;}

        [BindProperty]
        [Display(Name = "Player")]
        public int PlayerIdToAdd {get; set;}
        public List<Player> AllPlayers {get; set;}
        public SelectList PlayersDropDown {get; set;}

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Bring in related data with .Include and .ThenInclude
            Tournament = await _context.Tournament.Include(p => p.PlayerTournaments).ThenInclude(pt => pt.Player).FirstOrDefaultAsync(m => m.TournamentID == id);
            AllPlayers = await _context.Player.ToListAsync();
            PlayersDropDown = new SelectList(AllPlayers, "PlayerID", "UserName");

            if (Tournament == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostDeletePlayerAsync(int? id)
        {
            _logger.LogWarning($"OnPost: TournamentId {id}, DROP Player {PlayerIdToDelete}");
            if (id == null)
            {
                return NotFound();
            }

            Tournament = await _context.Tournament.Include(s => s.PlayerTournaments).ThenInclude(sc => sc.Player).FirstOrDefaultAsync(m => m.TournamentID == id);
            //AllPlayers = await _context.Player.ToListAsync();
            //PlayersDropDown = new SelectList(AllPlayers, "PlayerID", "UserName");
            
            if (Tournament == null)
            {
                return NotFound();
            }

            PlayerTournament PlayerToDrop = _context.PlayerTournament.Find(PlayerIdToDelete, id.Value);

            if (PlayerToDrop != null)
            {
                _context.Remove(PlayerToDrop);
                _context.SaveChanges();
            }
            else
            {
                _logger.LogWarning("Tournament NOT enrolled in Player");
            }

            return RedirectToPage(new {id = id});
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            _logger.LogWarning($"OnPost: TournamentId {id}, ADD Player {PlayerIdToAdd}");
            if (PlayerIdToAdd == 0)
            {
                ModelState.AddModelError("PlayerIdToAdd", "This field is a required field.");
                return Page();
            }
            if (id == null)
            {
                return NotFound();
            }

            Tournament = await _context.Tournament.Include(p => p.PlayerTournaments).ThenInclude(pt => pt.Player).FirstOrDefaultAsync(m => m.TournamentID == id);            
            AllPlayers = await _context.Player.ToListAsync();
            PlayersDropDown = new SelectList(AllPlayers, "PlayerID", "UserName");

            if (Tournament == null)
            {
                return NotFound();
            }

            if (!_context.PlayerTournament.Any(sc => sc.PlayerID == PlayerIdToAdd && sc.TournamentID == id.Value))
            {
                PlayerTournament PlayerToAdd = new PlayerTournament { TournamentID = id.Value, PlayerID = PlayerIdToAdd};
                _context.Add(PlayerToAdd);
                _context.SaveChanges();
            }
            else
            {
                _logger.LogWarning("Tournament already enrolled in the Player");
            }

            // Best practice is that OnPost should redirect. This clears the form data.
            // FIXME: Can we just populate the routeValues from what is already there?
            return RedirectToPage(new {id = id});
        }
    
    }
}
