using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kol2.Models
{
    public class Artist
    {
        public int IdArtist { get; set; }
        public string Nickname { get; set; }
        public ICollection<Artist_Event> Artist_Events { get; set; }
    }
}
