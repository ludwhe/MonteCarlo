using System.Collections.Generic;
using Models;

namespace Abstractions
{
    public interface IPlayer
    {
        IEnumerable<Card> Hand { get; set; }
        int Score { get; set; }
    }
}