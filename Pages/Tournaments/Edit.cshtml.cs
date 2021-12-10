using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FinalProject.Models;
using Microsoft.Extensions.Logging;

namespace FinalProject.Pages.Tournaments
{
    public class EditModel : PageModel
    {
        private readonly FinalProject.Models.Context _context;
        private readonly ILogger _logger;

        public EditModel(FinalProject.Models.Context context, ILogger<EditModel> logger)
        {
            _context = context;
            _logger = logger;
        }

        [BindProperty]
        public Tournament Tournament { get; set; } // This is the specific Tournament you are editing
        public List<Player> Players {get; set;} // This is a list of all Players

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Bring in related data using Include and ThenInclude
            Tournament = await _context.Tournament.Include(s => s.PlayerTournaments).ThenInclude(sc => sc.Player).FirstOrDefaultAsync(m => m.TournamentID == id);
            // Get a list of all Players. This list is used to make the checkboxes
            Players = _context.Player.ToList();

            if (Tournament == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int[] selectedPlayers)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            //_context.Attach(Tournament).State = EntityState.Modified;
            // Find the Tournament you want to update and update all their "normal properties" (TournamentName and TournamentGame)
            var TournamentToUpdate = await _context.Tournament.Include(s => s.PlayerTournaments).ThenInclude(sc => sc.Player).FirstOrDefaultAsync(m => m.TournamentID == Tournament.TournamentID);
            TournamentToUpdate.TournamentName = Tournament.TournamentName;
            TournamentToUpdate.TournamentGame = Tournament.TournamentGame;
            TournamentToUpdate.TournamentDetails = Tournament.TournamentDetails;
            TournamentToUpdate.StartDate = Tournament.StartDate;

            // Separate method to update the Players because it can get complex
            UpdatePlayerTournament(selectedPlayers, TournamentToUpdate);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TournamentExists(Tournament.TournamentID))
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

        private bool TournamentExists(int id)
        {
            return _context.Tournament.Any(e => e.TournamentID == id);
        }

        private void UpdatePlayerTournament(int[] selectedPlayers, Tournament TournamentToUpdate)
        {
            if (selectedPlayers == null)
            {
                TournamentToUpdate.PlayerTournaments = new List<PlayerTournament>();
                return;
            }

            List<int> currentPlayers = TournamentToUpdate.PlayerTournaments.Select(c => c.PlayerID).ToList();
            List<int> selectedPlayersList = selectedPlayers.ToList();

            foreach (var Player in _context.Player)
            {
                if (selectedPlayersList.Contains(Player.PlayerID))
                {
                    if (!currentPlayers.Contains(Player.PlayerID))
                    {
                        // Add Player here
                        TournamentToUpdate.PlayerTournaments.Add(
                            new PlayerTournament { TournamentID = TournamentToUpdate.TournamentID, PlayerID = Player.PlayerID }
                        );
                        _logger.LogWarning($"Tournament {TournamentToUpdate.TournamentName} {TournamentToUpdate.TournamentGame} ({TournamentToUpdate.TournamentID}) - ADD {Player.PlayerID} {Player.UserName}");
                    }
                }
                else
                {
                    if (currentPlayers.Contains(Player.PlayerID))
                    {
                        // Remove Player here
                        PlayerTournament PlayerToRemove = TournamentToUpdate.PlayerTournaments.SingleOrDefault(s => s.PlayerID == Player.PlayerID);
                        _context.Remove(PlayerToRemove);
                        _logger.LogWarning($"Tournament {TournamentToUpdate.TournamentName} {TournamentToUpdate.TournamentGame} ({TournamentToUpdate.TournamentID}) - DROP {Player.PlayerID} {Player.UserName}");
                    }
                }
            }
        }
    }
}
