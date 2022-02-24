using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NsPlayingCards.Models;

namespace NsPlayingCards.Data
{
    public class NsPlayingCardsContext : DbContext
    {
        public NsPlayingCardsContext (DbContextOptions<NsPlayingCardsContext> options)
            : base(options)
        {
        }

        public DbSet<NsPlayingCards.Models.PlayCard> PlayCard { get; set; }
    }
}
