using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LO.MyAirport.EF;

namespace LO.MyAirport.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VolsController : ControllerBase
    {
        private readonly MyAirportContext _context;

        
        public VolsController(MyAirportContext context)
        {
            _context = context;
        }

        // GET: api/Vols
        /// <summary>
        /// Selectionne l'ensemble des vols de manière asynchrone
        /// </summary>
        /// <returns>Un objet Task qui contient un ActionResult qui lui même contient une liste de vols</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vol>>> GetVols()
        {
            return await _context.Vols.ToListAsync();
        }

        // GET: api/Vols/4?bool bagages
        /// <summary>
        /// L'option bagages permet d'indiquer si l'on veut voir la liste des bagages du vol ou non
        /// si false bagages = null
        /// </summary>
        /// <param name="id"></param>
        /// <param name="bagages">Indique si l'on veut que la liste des bagages du vol soit incluse dans le résultat</param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public async Task<ActionResult<Vol>> GetVol(int id, [FromQuery] bool bagages = false)
        {
            Vol volRes;

            if (bagages)
            {
                volRes = await _context.Vols.Include(v => v.Bagages).FirstAsync(v=> v.VolId==id);//.Where(v => v.VolId == id).FirstAsync();
            }
            else
            {
                volRes = await _context.Vols.FindAsync(id); //Bagages[] == null
            }

            if (volRes == null)
            {
                return NotFound();
            }

            return volRes;

        }

        // PUT: api/Vols/5
        /// <summary>
        /// Méthode permettant de modifier un vol
        /// To protect from overposting attacks, please enable the specific properties you want to bind to, for
        /// more details see https://aka.ms/RazorPagesCRUD.
        /// </summary>
        /// <param name="id">Identifiant du vol à modifier</param>
        /// <param name="vol">Nouvelles valeur à rentrer dans le vol</param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVol(int id, Vol vol)
        {
            if (id != vol.VolId)
            {
                return BadRequest();
            }

            _context.Entry(vol).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VolExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Vols
        /// <summary>
        /// Méthode permettant l'ajout d'un vol
        /// To protect from overposting attacks, please enable the specific properties you want to bind to, for
        /// more details see https://aka.ms/RazorPagesCRUD.
        /// </summary>
        /// <param name="vol"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [HttpPost]
        public async Task<ActionResult<Vol>> PostVol(Vol vol)
        {
            _context.Vols.Add(vol);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVol", new { id = vol.VolId }, vol);
        }

        // DELETE: api/Vols/5
        /// <summary>
        /// Méthode permettant la suppression d'un vol grâce à son id
        /// </summary>
        /// <param name="id">Identifiant du vol à supprimer</param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{id}")]
        public async Task<ActionResult<Vol>> DeleteVol(int id)
        {
            var vol = await _context.Vols.FindAsync(id);
            if (vol == null)
            {
                return NotFound();
            }

            _context.Vols.Remove(vol);
            await _context.SaveChangesAsync();

            return vol;
        }

        /// <summary>
        /// Méthode permettant de savoir si un vol existe ou non
        /// </summary>
        /// <param name="id">Identifiant du vol à vérifier</param>
        /// <returns>Un booleen</returns>
        private bool VolExists(int id)
        {
            return _context.Vols.Any(e => e.VolId == id);
        }
    }
}
