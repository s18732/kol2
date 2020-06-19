using kol2.Exceptions;
using kol2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kol2.Services
{
    public class EfDbService : IDbService
    {
        public EventDbContext _context { get; set; }
        public EfDbService(EventDbContext context)
        {
            _context = context;
        }

        public Artist GetArtist(int id)
        {
            var artist = _context.Artists.Include(e => e.Artist_Events).SingleOrDefault(e => e.IdArtist == id);
            if (artist == null)
            {
                throw new ArtistDoesNotExistsException($"Artist with an id={id} does not exists");
            }
            artist.Artist_Events = artist.Artist_Events.OrderByDescending(e => e.PerformanceDate).ToList();

            return artist;
        }

        public void ModifyPerformanceTime(Artist_Event artist_Event)
        {
            var ev = _context.Events.Where(e => e.IdEvent == artist_Event.IdEvent).SingleOrDefault();
            if(ev == null)
            {
                throw new EventDoesNotExistsException($"Event with an id={artist_Event.IdEvent} does not exists");
            }
            if (ev.StartDate.CompareTo(DateTime.Now) < 0)
            {
                throw new EventHasAlreadyStartedException($"Event with an id={artist_Event.IdEvent} has already started");
            }
            if(!(ev.StartDate.CompareTo(artist_Event.PerformanceDate) < 0 && artist_Event.PerformanceDate.CompareTo(ev.EndDate) < 0))
            {
                throw new PerformanceDateIsNotWithinEventTime("Performance date is not within event time");
            }
            _context.Attach(artist_Event);
            _context.Entry(artist_Event).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
