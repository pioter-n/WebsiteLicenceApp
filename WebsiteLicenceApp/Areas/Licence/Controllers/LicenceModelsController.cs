using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebsiteLicenceApp.Data;
using WebsiteLicenceApp.Models;

namespace WebsiteLicenceApp.Areas.Licence.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class LicenceModelsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public LicenceModelsController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: api/LicenceModels
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<ApplicationUser>> GetUserLicence()
        {
            List<LicenceModel> a = await _context.UserLicence.ToListAsync();
            return _context.UserLicence.First<LicenceModel>().User;
           // return "Piotr";
            //return await _context.UserLicence.ToListAsync();
        }

        // GET: api/LicenceModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LicenceModel>> GetLicenceModel(int id)
        {
            var licenceModel = await _context.UserLicence.FindAsync(id);

            if (licenceModel == null)
            {
                return NotFound();
            }

            return licenceModel;
        }

        // PUT: api/LicenceModels/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLicenceModel(int id, LicenceModel licenceModel)
        {
            if (id != licenceModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(licenceModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LicenceModelExists(id))
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

        // POST: api/LicenceModels
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<LicenceModel>> PostLicenceModel(LicenceModel licenceModel)
        {
            _context.UserLicence.Add(licenceModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLicenceModel", new { id = licenceModel.Id }, licenceModel);
        }

        // DELETE: api/LicenceModels/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult<LicenceModel>> DeleteLicenceModel(int id)
        {
            var licenceModel = await _context.UserLicence.FindAsync(id);
            if (licenceModel == null)
            {
                return NotFound();
            }

            _context.UserLicence.Remove(licenceModel);
            await _context.SaveChangesAsync();

            return licenceModel;
        }
        [Authorize]
        private bool LicenceModelExists(int id)
        {
            return _context.UserLicence.Any(e => e.Id == id);
        }
    }
}
