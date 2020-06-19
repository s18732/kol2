using kol2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kol2.Services
{
    public interface IDbService
    {
        public Artist GetArtist(int id);
        public void ModifyPerformanceTime(Artist_Event artist_Event);
    }
}
