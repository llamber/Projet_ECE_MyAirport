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
    public class BagagesController : ControllerBase
    {
        private readonly MyAirportContext _context;

        public BagagesController(MyAirportContext context)
        {
            _context = context;
        }

        // GET: api/Bagages
        /// <summary>
        /// Selectionne l'ensemble des bagages de manière asynchrone
        /// </summary>
        /// <returns>Un objet Task qui contient un ActionResult qui lui même contient une liste de Bagages</returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Bagage>>> GetBagages()
        {
            return await _context.Bagages.ToListAsync();
        }

        // GET: api/Bagages/5
        /// <summary>
        /// Selection les bagages grâce à leur identifiant de manière asynchrone
        /// </summary>
        /// <param name="id">Identifiant du bagage</param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public async Task<ActionResult<Bagage>> GetBagage(int id)
        {
            var bagage = await _context.Bagages.FindAsync(id);

            if (bagage == null)
            {
                return NotFound();
            }

            return bagage;
        }

        // PUT: api/Bagages/5
        /// <summary>
        /// Méthode permettant la modification d'un bagage
        /// To protect from overposting attacks, please enable the specific properties you want to bind to, for
        /// more details see https://aka.ms/RazorPagesCRUD.
        /// </summary>
        /// <param name="id">Identifiant du bagage a modifier</param>
        /// <param name="bagage">Nouvelles valeurs a remplacer dans le bagage</param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBagage(int id, Bagage bagage)
        {
            if (id != bagage.BagageId)
            {
                return BadRequest();
            }

            _context.Entry(bagage).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BagageExists(id))
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

        // POST: api/Bagages
        /// <summary>
        /// Méthode permettant l'ajout d'un bagage
        ///To protect from overposting attacks, please enable the specific properties you want to bind to, for
        /// more details see https://aka.ms/RazorPagesCRUD.
        /// </summary>
        /// <param name="bagage"></param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [HttpPost]
        public async Task<ActionResult<Bagage>> PostBagage(Bagage bagage)
        {
            _context.Bagages.Add(bagage);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBagage", new { id = bagage.BagageId }, bagage);
        }

        // DELETE: api/Bagages/5
        /// <summary>
        /// Méthode permettant de supprimer un bagage grâce à son identifiant
        /// </summary>
        /// <param name="id">Identifiant du bagage à supprimer</param>
        /// <returns></returns>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{id}")]
        public async Task<ActionResult<Bagage>> DeleteBagage(int id)
        {
            var bagage = await _context.Bagages.FindAsync(id);
            if (bagage == null)
            {
                return NotFound();
            }

            _context.Bagages.Remove(bagage);
            await _context.SaveChangesAsync();

            return bagage;
        }

        /// <summary>
        /// Méthode permettant de dire si un bagage existe ou non
        /// </summary>
        /// <param name="id">Identifiant du bagage à vérifier</param>
        /// <returns>un booleen</returns>
        private bool BagageExists(int id)
        {
            return _context.Bagages.Any(e => e.BagageId == id);
        }
    }
}
