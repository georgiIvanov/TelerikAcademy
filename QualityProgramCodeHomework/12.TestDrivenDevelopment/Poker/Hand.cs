using System;
using System.Collections.Generic;

namespace Poker
{
    public class Hand : IHand
    {
        public IList<ICard> Cards { get; private set; }

        public Hand(IList<ICard> cards)
        {
            this.Cards = cards;
        }

        public override string ToString()
        {
            string result = string.Empty;

            foreach (var card in Cards)
            {
                result += string.Format("{0} ", card.ToString());
            }
            result = result.Trim();
            return result;
        }
    }
}
