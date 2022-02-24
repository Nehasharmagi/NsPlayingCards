using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace NsPlayingCards.Models
{
    public class PlayCard
    {
        public int Id { get; set; }
        public string CardName { get; set; }

        public string CardShape { get; set; }
        
        public string CardColor { get; set; }

        public string Type { get; set; }

        public string Rating { get; set; }

    }
}
