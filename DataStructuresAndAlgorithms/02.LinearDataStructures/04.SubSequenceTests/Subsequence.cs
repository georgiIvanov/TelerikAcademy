using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using LongestSubsequenceProgram;

namespace _04.SubSequenceTests
{
    [TestClass]
    public class Subsequence
    {
        [TestMethod]
        public void SubsequenceInBeginning()
        {
            List<int> numbers = new List<int> 
            { 2, 2, 2, 2, 3, 2, 3, 1, 5, 2 };

            List<int> subSequence = 
            LongestSubsequence.FindLongestSubsequence(numbers);

            foreach (var number in subSequence)
            {
                Assert.AreEqual(2, number);
            }

            Assert.AreEqual(4, subSequence.Count);
        }

        [TestMethod]
        public void SubsequenceInMiddle()
        {
            List<int> numbers = new List<int> 
            { 4, 2, 2, 5, 1, 3, 3, 3, 1, 5, 2 };

            List<int> subSequence =
            LongestSubsequence.FindLongestSubsequence(numbers);

            foreach (var number in subSequence)
            {
                Assert.AreEqual(3, number);
            }

            Assert.AreEqual(3, subSequence.Count);
        }

        [TestMethod]
        public void SubsequenceInMiddleNegative()
        {
            List<int> numbers = new List<int> 
            { 4, 2, 2, -5, 1, -3, -3, -3, 1, 5, 2 };

            List<int> subSequence =
            LongestSubsequence.FindLongestSubsequence(numbers);

            foreach (var number in subSequence)
            {
                Assert.AreEqual(-3, number);
            }

            Assert.AreEqual(3, subSequence.Count);
        }

        [TestMethod]
        public void SubsequenceInEnd()
        {
            List<int> numbers = new List<int> 
            { 4, 2, 2, 5, 2, 3, 2, 5, 5, 5, 5 };

            List<int> subSequence =
            LongestSubsequence.FindLongestSubsequence(numbers);

            foreach (var number in subSequence)
            {
                Assert.AreEqual(5, number);
            }

            Assert.AreEqual(4, subSequence.Count);
        }

        [TestMethod]
        public void SubsequenceCount1()
        {
            List<int> numbers = new List<int> { 4 };

            List<int> subSequence =
            LongestSubsequence.FindLongestSubsequence(numbers);

            foreach (var number in subSequence)
            {
                Assert.AreEqual(4, number);
            }

            Assert.AreEqual(1, subSequence.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void SubsequenceEmpty()
        {
            List<int> numbers = new List<int> {  };

            List<int> subSequence =
            LongestSubsequence.FindLongestSubsequence(numbers);
        }
    }
}
