using System;
using System.Collections.Generic;
using System.Linq;
using Abstractions;
using Extensions;

namespace Models
{
    public class Croupier
    {
        private IEnumerable<Card> _deck;
        private readonly Random _rand;

        public Croupier(Random rand)
        {
            var deck = new List<Card>();
            for (int i = 0; i < 52; i++)
            {
                deck.Add(new Card
                {
                    Value = (i % 13) + 1,
                    Suit = (i / 13) switch
                    {
                        0 => Suit.Spades,
                        1 => Suit.Hearts,
                        2 => Suit.Diamonds,
                        3 => Suit.Hearts,
                        _ => throw new Exception("Mathematics apparently broke. Seek shelter.")
                    }
                });
            }

            _deck = deck;
            _rand = rand;
        }

        public void ShuffleDeck()
        {
            _deck = _deck.Shuffle(_rand);
        }

        public void DealTo(IPlayer first, IPlayer second, IPlayer bank)
        {
            var players = new IPlayer[] { first, second, bank };
            for (int i = 0; i < 6; i++)
            {
                players[i % 3].Hand = players[i % 3].Hand.Append(_deck.ElementAt(i));
            }

            bank.Hand = bank.Hand.Append(_deck.ElementAt(6));
        }

        public void Grade(IPlayer first, IPlayer second, IPlayer bank)
        {
            foreach (var player in new IPlayer[] { first, second, bank })
            {
                player.Score = player.Hand.Sum(c => c.Value);
            }

            if (first.Hand.Select(c => c.Suit).Distinct().Count() == 1)
                first.Score += 20;
            if (second.Hand.Select(c => c.Suit).Distinct().Count() == 1)
                second.Score += 20;
            if (bank.Hand.Select(c => c.Suit).Distinct().Count() == 1)
                bank.Score += 35;
        }
    }
}