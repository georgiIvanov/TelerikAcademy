using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Poker;
using System.Collections.Generic;

namespace Poker.Tests
{
    [TestClass]
    public class HandToString
    {
        [TestMethod]
        public void ToStringHand()
        {
            Hand hand = new Hand(new List<ICard>() { 
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.King, CardSuit.Hearts),
                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.Seven, CardSuit.Diamonds),
            });
            string expected = "A♣ A♦ K♥ K♠ 7♦";

            Assert.AreEqual(expected, hand.ToString());
        }

        [TestMethod]
        public void ToStringHandBelow10()
        {
            Hand hand = new Hand(new List<ICard>() { 
                new Card(CardFace.Two, CardSuit.Diamonds),
                new Card(CardFace.Three, CardSuit.Diamonds),
                new Card(CardFace.Five, CardSuit.Spades),
                new Card(CardFace.Seven, CardSuit.Hearts),
                new Card(CardFace.Seven, CardSuit.Diamonds),
            });
            string expected = "2♦ 3♦ 5♠ 7♥ 7♦";

            Assert.AreEqual(expected, hand.ToString());
        }

        [TestMethod]
        public void ToStringHandAbove10()
        {
            Hand hand = new Hand(new List<ICard>() { 
                new Card(CardFace.Jack, CardSuit.Clubs),
                new Card(CardFace.King, CardSuit.Spades),
                new Card(CardFace.Ten, CardSuit.Spades),
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Queen, CardSuit.Diamonds),
            });
            string expected = "J♣ K♠ 10♠ A♦ Q♦";

            Assert.AreEqual(expected, hand.ToString());
        }

    }
}
