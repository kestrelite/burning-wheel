using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BurningWheelConsole;

namespace BurningWheelUnitTest
{
    [TestClass]
    public class StatRecorderTest
    {
        [TestMethod]
        public void StatRecorderAddsGets()
        {
            StatRecorder r = new StatRecorder();

            r.AddValue(RootStat.Agility.ToString(), new StatValue(StatLevels.Black, 3));
            r.AddValue(RootStat.Forte.ToString(), new StatValue(StatLevels.Black, 4));

            Assert.IsTrue(r.HasValue(RootStat.Agility));
            Assert.IsNotNull(r.GetValue(RootStat.Forte));
            Assert.AreEqual(r.GetValue(RootStat.Forte).dice, 4);
            Assert.AreEqual(r.GetValue(RootStat.Agility).dice, 3);
        }

        [TestMethod]
        public void StatRecorderDeletes()
        {
            StatRecorder r = new StatRecorder();

            r.AddValue(RootStat.Agility.ToString(), new StatValue(StatLevels.Black, 3));
            r.AddValue(RootStat.Forte.ToString(), new StatValue(StatLevels.Black, 4));

            Assert.IsNotNull(r.GetValue(RootStat.Forte));
            Assert.IsTrue(r.DelValue(RootStat.Forte));
            Assert.IsNull(r.GetValue(RootStat.Forte));
            Assert.IsNotNull(r.GetValue(RootStat.Agility));
        }
    }
}
