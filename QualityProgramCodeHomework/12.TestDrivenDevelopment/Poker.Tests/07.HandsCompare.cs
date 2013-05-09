using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Poker.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CompareStraightTwoPair()
        {
            PokerHandsChecker checker = new PokerHandsChecker();
            // straight ace low
            Hand hand1 = new Hand(new List<ICard>() { 
                new Card(CardFace.Three, CardSuit.Diamonds),
                new Card(CardFace.Five, CardSuit.Clubs),
                new Card(CardFace.Two, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Four, CardSuit.Spades),
            });

            // two pair
            Hand hand2 = new Hand(new List<ICard>() { 
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Eight, CardSuit.Diamonds),
                new Card(CardFace.Five, CardSuit.Clubs),
                new Card(CardFace.Five, CardSuit.Spades),
            });

            Assert.AreEqual(1, checker.CompareHands(hand1, hand2));
        }

        [TestMethod]
        public void CompareOnePairTwoPair()
        {
            PokerHandsChecker checker = new PokerHandsChecker();
            // one pair
            Hand hand1 = new Hand(new List<ICard>() { 
                new Card(CardFace.Seven, CardSuit.Clubs),
                new Card(CardFace.Three, CardSuit.Hearts),
                new Card(CardFace.Seven, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Eight, CardSuit.Spades),
            });

            // two pair
            Hand hand2 = new Hand(new List<ICard>() { 
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Eight, CardSuit.Diamonds),
                new Card(CardFace.Five, CardSuit.Clubs),
                new Card(CardFace.Five, CardSuit.Spades),
            });

            Assert.AreEqual(-1, checker.CompareHands(hand1, hand2));
        }

        [TestMethod]
        public void CompareTwoPairThree()
        {
            PokerHandsChecker checker = new PokerHandsChecker();
            // two pair
            Hand hand1 = new Hand(new List<ICard>() { 
                new Card(CardFace.Ace, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Clubs),
                new Card(CardFace.Eight, CardSuit.Diamonds),
                new Card(CardFace.Five, CardSuit.Clubs),
                new Card(CardFace.Five, CardSuit.Spades),
            });

            // three eights
            Hand hand2 = new Hand(new List<ICard>() { 
                new Card(CardFace.Eight, CardSuit.Clubs),
                new Card(CardFace.Eight, CardSuit.Hearts),
                new Card(CardFace.Jack, CardSuit.Diamonds),
                new Card(CardFace.Eight, CardSuit.Spades),
                new Card(CardFace.Five, CardSuit.Hearts),
            });
            Assert.AreEqual(-1, checker.CompareHands(hand1, hand2));
        }

        [TestMethod]
        public void CompareFullFlush()
        {
            PokerHandsChecker checker = new PokerHandsChecker();
            // full
            Hand hand1 = new Hand(new List<ICard>() { 
                new Card(CardFace.Queen, CardSuit.Diamonds),
                new Card(CardFace.Queen, CardSuit.Clubs),
                new Card(CardFace.Queen, CardSuit.Diamonds),
                new Card(CardFace.Ten, CardSuit.Clubs),
                new Card(CardFace.Ten, CardSuit.Spades),
            });

            // flush
            Hand hand2 = new Hand(new List<ICard>() { 
                new Card(CardFace.Six, CardSuit.Clubs),
                new Card(CardFace.Eight, CardSuit.Clubs),
                new Card(CardFace.Seven, CardSuit.Clubs),
                new Card(CardFace.King, CardSuit.Clubs),
                new Card(CardFace.Nine, CardSuit.Clubs),
            });
            Assert.AreEqual(1, checker.CompareHands(hand1, hand2));
        }

        [TestMethod]
        public void CompareFourStraight()
        {
            PokerHandsChecker checker = new PokerHandsChecker();
            // four
            Hand hand1 = new Hand(new List<ICard>() { 
                new Card(CardFace.Three, CardSuit.Clubs),
                new Card(CardFace.Three, CardSuit.Hearts),
                new Card(CardFace.Three, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Three, CardSuit.Spades),
            });

            // straight
            Hand hand2 = new Hand(new List<ICard>() { 
                new Card(CardFace.Ten, CardSuit.Diamonds),
                new Card(CardFace.Eight, CardSuit.Clubs),
                new Card(CardFace.Jack, CardSuit.Diamonds),
                new Card(CardFace.Nine, CardSuit.Clubs),
                new Card(CardFace.Queen, CardSuit.Spades),
            });
            Assert.AreEqual(1, checker.CompareHands(hand1, hand2));
        }

        [TestMethod]
        public void CompareThreeAndStraight()
        {
            PokerHandsChecker checker = new PokerHandsChecker();
            // four
            Hand hand1 = new Hand(new List<ICard>() { 
                new Card(CardFace.Nine, CardSuit.Clubs),
                new Card(CardFace.Nine, CardSuit.Hearts),
                new Card(CardFace.Nine, CardSuit.Diamonds),
                new Card(CardFace.Ace, CardSuit.Hearts),
                new Card(CardFace.Three, CardSuit.Spades),
            });

            // straight
            Hand hand2 = new Hand(new List<ICard>() { 
                new Card(CardFace.Ten, CardSuit.Diamonds),
                new Card(CardFace.Eight, CardSuit.Clubs),
                new Card(CardFace.Jack, CardSuit.Diamonds),
                new Card(CardFace.Nine, CardSuit.Clubs),
                new Card(CardFace.Queen, CardSuit.Spades),
            });
            Assert.AreEqual(-1, checker.CompareHands(hand1, hand2));
        }
    }
}
