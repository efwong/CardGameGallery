using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGameLibrary
{
    public class Player
    {
        public String name { get; set; }

        /// <summary>
        /// Player's current hand of cards
        /// </summary>
        public IEnumerable<Card> hand { get; set; }
    }
}
