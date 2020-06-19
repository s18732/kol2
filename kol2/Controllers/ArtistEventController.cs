using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using kol2.Exceptions;
using kol2.Models;
using kol2.Services;
using Microsoft.AspNetCore.Mvc;

namespace kol2.Controllers
{
    public class ArtistEventController : Controller
    {
        private IDbService _context;
        public ArtistEventController(IDbService context)
        {
            _context = context;
        }
        [HttpPut("{id}, {id2}")]
        [Route("api/artists/{id}/events/{id2}")]
        public IActionResult ModifyPerformanceTime(Artist_Event artist_Event)
        {
            try
            {
                _context.ModifyPerformanceTime(artist_Event);
                return NoContent();
            }
            catch(EventDoesNotExistsException exc)
            {
                return NotFound(exc.Message);
            }
            catch (EventHasAlreadyStartedException exc)
            {
                return BadRequest(exc.Message);
            }
            catch (PerformanceDateIsNotWithinEventTime exc)
            {
                return BadRequest(exc.Message);
            }
        }
    }
}