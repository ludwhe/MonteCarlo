using System.Collections.Generic;
using Abstractions;

namespace Models
{
    public class Player : IPlayer
    {
        public IEnumerable<Card> Hand { get; set; }
        public int Score { get; set; }

        public Player ()
        {
            Hand = new List<Card>();
        }
    }
}