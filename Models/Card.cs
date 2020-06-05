using System;

namespace Models
{
    public class Card
    {
        private int _value;

        public int Value
        {
            get => _value;
            set
            {
                if (value < 1 || value > 13)
                    throw new ArgumentOutOfRangeException($"Expected card value >= 1 and <= 13. Got {value}.");

                _value = value;
            }
        }
        public Suit Suit { get; set; }
        public string Representation
        {
            get => char.ConvertFromUtf32(Suit switch
            {
                Suit.Spades => 0x1f0a0,
                Suit.Hearts => 0x1f0b0,
                Suit.Diamonds => 0x1f0c0,
                Suit.Clubs => 0x1f0d0,
                _ => throw new ArgumentException($"No representation for unknown Suit: {Suit}")
            } + (Value >= 0xc ? Value + 1 : Value)); // Avoids the Knight
        }
    }
}