using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WordRepetition;

namespace WordRepetitionTests
{
    [TestClass]
    public class MimicaRepeatitionFinderTests
    {
        private MimicaRepetitionFinder _finder;

        [TestInitialize]
        public void SetUp()
        {
            _finder = new MimicaRepetitionFinder();
        }

        [TestMethod]
        public void CreateCharIndexLookUp_StringWithRepeatitions_CorrectResult()
        {
            var testString = "ababcd";
            var result = _finder.CreateCharIndexLookUp(testString);
            Assert.AreEqual(4, result.Count);
            Assert.IsTrue(result.ContainsKey('a'));
            Assert.IsTrue(result.ContainsKey('b'));
            Assert.IsTrue(result.ContainsKey('c'));
            Assert.IsTrue(result.ContainsKey('d'));
            Assert.AreEqual(result['a'].Count,2);
            Assert.AreEqual(result['a'][0], 0);
            Assert.AreEqual(result['a'][1], 2);
            Assert.AreEqual(result['b'].Count, 2);
            Assert.AreEqual(result['b'][0], 1);
            Assert.AreEqual(result['b'][1], 3);
            Assert.AreEqual(result['c'].Count, 1);
            Assert.AreEqual(result['c'][0], 4);
            Assert.AreEqual(result['d'].Count, 1);
            Assert.AreEqual(result['d'][0], 5);
        }

        [TestMethod]
        public void FindRepetition_ThreeRepetitions_FindRepetitionSet()
        {
            var testString = "abababab";

            var result = _finder.FindRepetition(testString);

            Assert.IsTrue(result.Contains("ab"));
            Assert.IsTrue(result.Contains("abab"));
            Assert.IsTrue(result.Contains("ba"));
            Assert.IsTrue(result.Count == 3);
        }
    }
}
