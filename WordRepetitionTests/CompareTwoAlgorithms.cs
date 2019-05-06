using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WordRepetition;

namespace WordRepetitionTests
{
    [TestClass]
    public class CompareTwoAlgorithms
    {
        [TestMethod]
        public void TwoAlgorithmsProduceSameResult()
        {
            IWordRepetitionFinder finder;
            var testString = "ababcddsdfegrefgrefgrefgrefgxdfertgh";
            finder = new BruteForceFinder();
            var bruteForceResult = finder.FindRepetition(testString);
            finder = new MimicaRepetitionFinder();
            var mimicaResult = finder.FindRepetition(testString);

            Assert.AreEqual(bruteForceResult.Count, mimicaResult.Count);
            foreach (var r in bruteForceResult)
            {
                Assert.IsTrue(mimicaResult.Contains(r));
            }
        }
    }
}
