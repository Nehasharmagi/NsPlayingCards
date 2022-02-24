using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NsPlayingCards.Data;

namespace NsPlayingCards.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new NsPlayingCardsContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<NsPlayingCardsContext>>()))
            {
                // Look for any movies.
                if (context.PlayCard.Any())
                {
                    return;   // DB has been seeded
                }

                context.PlayCard.AddRange(
                    new PlayCard
                    {
                        Id=1,
                        CardName= "Spades",
                        CardColor="Black",
                        CardShape="Heart",
                        Type="Regular",
                        Rating="5"
                    },

                    new PlayCard
                    {
                        Id = 2,
                        CardName = "Spades",
                        CardColor = "Black",
                        CardShape = "Heart",
                        Type = "Regular",
                        Rating = "5"
                    }

                    
                );
                context.SaveChanges();
            }
        }
    }
}
