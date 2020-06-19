using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using kol2.Exceptions;
using kol2.Services;
using Microsoft.AspNetCore.Mvc;

namespace kol2.Controllers
{
    [Route("api/artists")]
    public class ArtistController : ControllerBase
    {
        private IDbService _context;
        public ArtistController(IDbService context)
        {
            _context = context;
        }
        [HttpGet("{id:int}")]
        public IActionResult GetArtist(int id)
        {
            try
            {
                var result = _context.GetArtist(id);
                return Ok(result);
            }
            catch(ArtistDoesNotExistsException exc)
            {
                return NotFound(exc.Message);
            }
        }
    }
}