using System;
using Abstractions;

namespace Models
{
    public class Game
    {
        public bool Round()
        {
            var croupier = new Croupier();
            var players = Tuple.Create<IPlayer, IPlayer>(new Player(), new Player());
            var bank = new Player();

            croupier.ShuffleDeck();
            croupier.DealTo(players.Item1, players.Item2, bank);

            croupier.Grade(players.Item1, players.Item2, bank);

            return bank.Score > players.Item1.Score
                && bank.Score > players.Item2.Score;
        }
    }
}