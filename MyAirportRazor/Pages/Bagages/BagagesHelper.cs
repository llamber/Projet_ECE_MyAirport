using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LO.MyAirport.Razor.Pages.Bagages
{
    public static class BagagesHelper
    {
        public static SelectList ListVolInfo(LO.MyAirport.EF.MyAirportContext context)
        {
            var vols = context.Vols.Select(v => new
            {
                v.VolId,
                Description = $"{v.Cie} {v.Lig} : {v.Dhc.ToShortDateString()}"
            }).ToList();
            return new SelectList(vols, "VolId", "Description");
        }
    }
}
