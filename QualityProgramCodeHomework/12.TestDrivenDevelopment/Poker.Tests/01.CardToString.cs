using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Poker;
namespace Poker.Tests
{
    [TestClass]
    public class CardToString
    {
        [TestMethod]
        public void ToStringAceSpades()
        {
            Card card = new Card(CardFace.Ace, CardSuit.Spades);
            string expected = "A♠";
            Assert.AreEqual(expected, card.ToString());
        }

        [TestMethod]
        public void ToStringTenDiamonds()
        {
            Card card = new Card(CardFace.Ten, CardSuit.Diamonds);
            string expected = "10♦";
            Assert.AreEqual(expected, card.ToString());
        }

        [TestMethod]
        public void ToStringTwoClubs()
        {
            Card card = new Card(CardFace.Two, CardSuit.Clubs);
            string expected = "2♣";
            Assert.AreEqual(expected, card.ToString());
        }

        [TestMethod]
        public void ToStringQueenDiamonds()
        {
            Card card = new Card(CardFace.Queen, CardSuit.Hearts);
            string expected = "Q♥";
            Assert.AreEqual(expected, card.ToString());
        }
    }
}
