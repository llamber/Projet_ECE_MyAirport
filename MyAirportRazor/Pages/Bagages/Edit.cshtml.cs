using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LO.MyAirport.EF;

namespace LO.MyAirport.Razor.Pages.Bagages
{
    public class EditModelBagage : PageModel
    {
        private readonly LO.MyAirport.EF.MyAirportContext _context;

        public EditModelBagage(LO.MyAirport.EF.MyAirportContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Bagage Bagage { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Bagage = await _context.Bagages
                .Include(b => b.Vol).FirstOrDefaultAsync(m => m.BagageId == id);

            if (Bagage == null)
            {
                return NotFound();
            }
            ViewData["VolId"] = BagagesHelper.ListVolInfo(_context);
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Bagage).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BagageExists(Bagage.BagageId))
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

        private bool BagageExists(int id)
        {
            return _context.Bagages.Any(e => e.BagageId == id);
        }
    }
}
