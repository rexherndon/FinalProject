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
    public class IndexModel : PageModel
    {
        private readonly FinalProject.Models.Context _context;

        public IndexModel(FinalProject.Models.Context context)
        {
            _context = context;
        }

        public IList<Tournament> Tournament { get;set; }

        public async Task OnGetAsync()
        {
            Tournament = await _context.Tournament.ToListAsync();
        }
    }
}
