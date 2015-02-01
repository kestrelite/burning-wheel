using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BurningWheelConsole;

namespace BurningWheelUnitTest
{
    [TestClass]
    public class CharacterTest
    {
        [TestMethod]
        public void CharacterReceivesLP()
        {
            LifepathData.AggregateLifepaths();
            Character c = new Character();
            Lifepath BornPeasant = LifepathData.getLifepathByStringNameSetting("Born Peasant", "Human_Peasant");
            Assert.IsNotNull(BornPeasant);

            c.AddLifepath(BornPeasant);
            Assert.AreEqual(c.GetLifepathList().Count, 1);

            Assert.IsTrue(c.DropLifepath(BornPeasant));
            Assert.IsFalse(c.DropLifepath(BornPeasant));
        }
    }
}
