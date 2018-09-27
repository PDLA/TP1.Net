using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WSConvertisseur.Models;

namespace WSConvertisseur.Controllers
{
    /// <summary>
    /// Controller des devises
    /// </summary>
    [Produces("application/json")]
    [Route("api/Devise")]
    public class DeviseController : Controller
    {
        public List<Devise> devises; 
        
        /// <summary>
        /// Constructeur
        /// </summary>
        public DeviseController()
        {
            devises = new List<Devise>();
            devises.Add(new Devise(1, "Dollar", 1.08));
            devises.Add(new Devise(2, "Franc Suisse", 1.07));
            devises.Add(new Devise(3, "Yen", 120));
        }

        /// <summary>
        /// Get all currencies
        /// </summary>
        /// <returns>Http Response</returns>
        /// <response code="200">When currencies are found</response>
        /// <response code="404">When currencies not found</response>
        // GET: api/Devise
        [HttpGet]
        public IEnumerable<Devise> GetAll()
        {
            return devises;
        }

        /// <summary>
        /// Get a single currecncy.
        /// </summary>
        /// <param name="id">The id of the currency</param>
        /// <returns>Http Response</returns>
        /// <response code="200">When the currency id is found</response>
        /// <response code="404">When the currency id is not found</response>
        // GET: api/Devise/5
        [HttpGet("{id}", Name = "GetDevise")]
        public IActionResult GetById(int id)
        {
            Devise devise = devises.FirstOrDefault((d) => d.Id == id);
            if (devise == null)
            {
                return NotFound();
            }
            return Ok(devise);
        }

        /// <summary>
        /// Add a currency
        /// </summary>
        /// <param name="devise">The new currency to add</param>
        /// <returns>Http Response</returns>
        /// <response code="400">When the currency couldn't be created</response>
        /// <response code="201">when the currency is created</response>
        // POST: api/Devise
        [HttpPost]
        public IActionResult Post([FromBody]Devise devise)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            devises.Add(devise);
            return CreatedAtRoute("GetDevise", new { id = devise.Id }, devise);
        }

        /// <summary>
        /// Modify a currency
        /// </summary>
        /// <param name="id">The id of the currency to modify</param>
        /// <param name="devise">New version of the currency</param>
        /// <returns>Http Response</returns>
        /// <response code="204">When the currency is modified</response>
        /// <response code="400">When the currency doesn't exist</response>
        // PUT: api/Devise/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Devise devise)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != devise.Id)
            {
                return BadRequest();
            }
            int index = devises.FindIndex((d) => d.Id == id);
            if (index < 0)
            {
                return NotFound();
            }
            devises[index] = devise;
            return NoContent();
        }

        /// <summary>
        /// Delete a curency
        /// </summary>
        /// <param name="id">The id of the currency to delete</param>
        /// <returns>Http Response</returns>
        /// <response code="200">When the currency has been deleted</response>
        /// <response code="404">When the currency is not found</response>
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Devise devise = devises.FirstOrDefault((d) => d.Id == id);
            if (devise == null)
            {
                return NotFound();
            }
            devises.Remove(devise);
            return Ok(devise);
        }
    }
}
