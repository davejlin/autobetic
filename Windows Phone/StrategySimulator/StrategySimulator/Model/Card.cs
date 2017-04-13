using System.Text;

namespace StrategySimulator.Model
{
    public class Card
    {
        public Suits Suit { get; private set; }
        public Values Value { get; private set; }

        public Card(Suits suit, Values value)
        {
            Suit = suit;
            Value = value;
        }

        public override string ToString()
        {
            return new StringBuilder(Suit.ToString()).Append(Value.ToString()).ToString();
        }
    }

    public enum Suits
    {
        None = 0,
        Spades = 1,
        Clubs = 2,
        Diamonds = 3,
        Hearts = 4
    }

    public enum Values
    {
        None = 0,
        Ace = 1,
        Two = 2,
        Three = 3,
        Four = 4,
        Five = 5,
        Six = 6,
        Seven = 7,
        Eight = 8,
        Nine = 9,
        Ten = 10,
        Jack = 11,
        Queen = 12,
        King = 13,
    }
}
