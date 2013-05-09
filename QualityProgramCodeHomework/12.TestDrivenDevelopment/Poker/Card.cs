using System;

namespace Poker
{
    public class Card : ICard
    {
        public CardFace Face { get; private set; }
        public CardSuit Suit { get; private set; }

        public Card(CardFace face, CardSuit suit)
        {
            this.Face = face;
            this.Suit = suit;
        }

        public override string ToString()
        {
            string result = Face.ToString();
            if ((int)this.Face <= 10)
            {
                result = ((int)this.Face).ToString();
            }
            else
            {
                result = this.Face.ToString()[0].ToString();
            }

            switch (this.Suit)
            {
                case CardSuit.Clubs: result += "♣"; 
                    break;
                case CardSuit.Diamonds: result += "♦"; 
                    break;
                case CardSuit.Hearts: result += "♥"; 
                    break;
                case CardSuit.Spades: result += "♠"; 
                    break;

            }

            return result;
        }
    }
}
