using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FinalProject.Models;

namespace FinalProject.Pages.Tournaments
{
    public class DetailsModel : PageModel
    {
        private readonly FinalProject.Models.Context _context;

        public DetailsModel(FinalProject.Models.Context context)
        {
            _context = context;
        }

        public Tournament Tournament { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Tournament = await _context.Tournament.FirstOrDefaultAsync(m => m.TournamentID == id);

            if (Tournament == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
