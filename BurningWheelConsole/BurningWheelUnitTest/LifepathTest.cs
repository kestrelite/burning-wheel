using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BurningWheelConsole;
using System.Collections.Generic;

namespace BurningWheelUnitTest
{
    [TestClass]
    public class LifepathTest
    {
        [TestMethod]
        public void LifepathFetchByName()
        {
            LifepathAggregator.AggregateLifepaths();
            List<Lifepath> list = LifepathAggregator.getLifepathByStringName("Born Peasant");
            Assert.IsNotNull(list);
            Assert.AreEqual(list.Count, 1);
            Assert.AreEqual(list[0].Name, "Born Peasant");
        }

        [TestMethod]
        public void BornLifepathsParseRace()
        {
            LifepathAggregator.AggregateLifepaths();
            List<Lifepath> list = LifepathAggregator.getBornLifepaths("Human");
            Assert.IsTrue(list.Count > 0);
            foreach (Lifepath lp in list)
            {
                Assert.IsTrue(lp.isBornLifepath);
            }

            List<Lifepath> list2 = LifepathAggregator.getBornLifepaths("FfweEFJIJfjf");
            Assert.IsTrue(list2.Count == 0);
        }

        [TestMethod]
        public void LifepathIsCopied() //To ensure we're not modifying the base values stored in Aggregator
        {
            List<Lifepath> listA = LifepathAggregator.getLifepathByStringName("Born Peasant");
            List<Lifepath> listB = LifepathAggregator.getLifepathByStringName("Born Peasant");
            Assert.AreNotSame(listA, listB);
            listA[0].ResPoints = 23848;
            Assert.AreNotEqual(listA[0].ResPoints, listB[0].ResPoints);
        }
    }
}
