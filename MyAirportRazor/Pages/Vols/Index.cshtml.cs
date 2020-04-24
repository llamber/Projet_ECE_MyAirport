using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using LO.MyAirport.EF;

namespace LO.MyAirport.Razor.Pages.Vols
{
    public class IndexModelVol : PageModel
    {
        private readonly LO.MyAirport.EF.MyAirportContext _context;

        public IndexModelVol(LO.MyAirport.EF.MyAirportContext context)
        {
            _context = context;
        }

        public IList<Vol> Vol { get;set; }

        public async Task OnGetAsync()
        {
            Vol = await _context.Vols.ToListAsync();
        }
    }
}
