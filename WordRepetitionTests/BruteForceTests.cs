using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WordRepetition;
using System.Collections.Generic;
using System.Diagnostics;

namespace WordRepetitionTests
{
    [TestClass]
    public class BruteForceTests
    {
        private BruteForceFinder _bruteForceFinder;

        [TestInitialize]
        public void SetUp()
        {
            _bruteForceFinder = new BruteForceFinder();
        }

        [TestMethod]
        public void IsRepetition_AdjacentSameWord_True()
        {
            var testString = "ABCDABCD";
            var pointerA = 0;
            var pointerB = 4;
            var result = _bruteForceFinder.IsRepetition(testString, pointerA, pointerB);
            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void IsRepetition_NotAdjacentSameWord_False()
        {
            var testString = "ABCDxABCD";
            var pointerA = 0;
            var pointerB = 5;
            var result = _bruteForceFinder.IsRepetition(testString, pointerA, pointerB);
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void IsRepetition_AdjacentDiffWord_False()
        {
            var testString = "ABCDAFCD";
            var pointerA = 0;
            var pointerB = 4;
            var result = _bruteForceFinder.IsRepetition(testString, pointerA, pointerB);
            Assert.AreEqual(false, result);
        }

        [TestMethod]
        public void FindRepetition_ThreeRepetitions_FindRepetitionSet()
        {
            var testString = "abababab";

            var result = _bruteForceFinder.FindRepetition(testString);

            Assert.IsTrue(result.Contains("ab"));
            Assert.IsTrue(result.Contains("abab"));
            Assert.IsTrue(result.Contains("ba"));
            Assert.IsTrue(result.Count == 3);
        }
    }
}
