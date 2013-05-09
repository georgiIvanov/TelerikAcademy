using System;
using System.Linq;
using System.Collections.Generic;

namespace Poker
{
    public class PokerHandsChecker : IPokerHandsChecker
    {
        public bool IsValidHand(IHand hand)
        {
            if (hand.Cards.Count != 5)
            {
                return false;
            }

            for (int i = 0; i < hand.Cards.Count; i++)
            {
                for (int j = 0; j < hand.Cards.Count; j++)
                {
                    if (hand.Cards[i].Face == hand.Cards[j].Face &&
                        hand.Cards[i].Suit == hand.Cards[j].Suit && i != j)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public bool IsStraightFlush(IHand hand)
        {
            if (IsStraight(hand) && IsFlush(hand))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsFourOfAKind(IHand hand)
        {
            if (CountSameFacesOfCard(hand, hand.Cards[0].Face) == 4)
            {
                return true;
            }
            else if(CountSameFacesOfCard(hand, hand.Cards[1].Face) == 4)
            {
                return true;
            }

            return false;
        }

        public bool IsFullHouse(IHand hand)
        {
            if (IsOnePair(hand) && IsThreeOfAKind(hand))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsFlush(IHand hand)
        {
            bool isFlush = true;
            CardSuit flushSuit = hand.Cards[0].Suit;

            foreach (var card in hand.Cards)
            {
                if (card.Suit != flushSuit)
                {
                    isFlush = false;
                }
            }

            return isFlush;
        }

        public bool IsStraight(IHand hand)
        {
            IList<ICard> sortedCards = hand.Cards.OrderByDescending(x => x.Face).ToList();
            bool isStraight = true;

            if (sortedCards[0].Face != CardFace.Ace && sortedCards[1].Face != CardFace.Five)
            {

                for (int i = 0; i < sortedCards.Count - 1; i++)
                {
                    if (sortedCards[i].Face - 1 != sortedCards[i + 1].Face)
                    {
                        isStraight = false;
                        break;
                    }
                }
            }
            else
            {
                for (int i = 1; i < sortedCards.Count - 1; i++)
                {
                    if (sortedCards[i].Face - 1 != sortedCards[i + 1].Face)
                    {
                        isStraight = false;
                        break;
                    }
                }
            }

            return isStraight;
        }

        public bool IsThreeOfAKind(IHand hand)
        {
            bool isThreeOfAKind = false;
            for (int i = 0; i < hand.Cards.Count; i++)
            {
                int result = CountSameFacesOfCard(hand, hand.Cards[i].Face);
                if (result == 3)
                {
                    isThreeOfAKind = true;
                    break;
                }
                else if (result != 3)
                {
                    isThreeOfAKind = false;
                }
            }

            return isThreeOfAKind;

        }

        public bool IsTwoPair(IHand hand)
        {
            int cardsInPairs = 0;
            for (int i = 0; i < hand.Cards.Count; i++)
            {
                int result = CountSameFacesOfCard(hand, hand.Cards[i].Face);
                if (result == 2)
                {
                    cardsInPairs++;
                }
            }

            if (cardsInPairs == 4)
            {
                return true;
            }

            return false;
        }

        public bool IsOnePair(IHand hand)
        {
            bool isOnePair = false;
            for (int i = 0; i < hand.Cards.Count; i++)
            {
                int result = CountSameFacesOfCard(hand, hand.Cards[i].Face);
                if (result == 2)
                {
                    isOnePair = true;
                    break;
                }
                else if(result > 2)
                {
                    isOnePair = false;
                }
            }

            return isOnePair;
        }

        public bool IsHighCard(IHand hand)
        {
            if (!IsFlush(hand) && !IsStraight(hand) &&
                !IsOnePair(hand) && !IsThreeOfAKind(hand))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public int CompareHands(IHand firstHand, IHand secondHand)
        {
            int firstHandStrength = this.HandStrength(firstHand);
            int secondHandStrength = this.HandStrength(secondHand);

            if (firstHandStrength > secondHandStrength)
            {
                return 1;
            }
            else if (firstHandStrength < secondHandStrength)
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }

        private static int CountSameFacesOfCard(IHand hand, CardFace face)
        {
            int countEqualFaces = 0;

            foreach (var card in hand.Cards)
            {
                if (card.Face == face)
                {
                    countEqualFaces++;
                }
            }
            return countEqualFaces;
        }

        private int HandStrength(IHand hand)
        {
            int strength = 1;

            if (this.IsStraightFlush(hand))
            {
                strength = 9;
            }
            else if (this.IsFourOfAKind(hand))
            {
                strength = 8;
            }
            else if (this.IsFullHouse(hand))
            {
                strength = 7;
            }
            else if (this.IsFlush(hand))
            {
                strength = 6;
            }
            else if (this.IsStraight(hand))
            {
                strength = 5;
            }
            else if (this.IsThreeOfAKind(hand))
            {
                strength = 4;
            }
            else if (this.IsTwoPair(hand))
            {
                strength = 3;
            }
            else if (this.IsOnePair(hand))
            {
                strength = 2;
            }

            return strength;
        }
    }
}
