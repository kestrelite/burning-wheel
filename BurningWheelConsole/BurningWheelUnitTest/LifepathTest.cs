using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BurningWheelConsole;

namespace BurningWheelUnitTest
{
    [TestClass]
    public class LifepathTest
    {
        [TestMethod]
        public void LifepathLeadsCorrectly()
        {
            Lifepath lpA = new Lifepath();
            lpA.Leads = new List<string>();
            lpA.Leads.Add("Overlook");
            lpA.Setting = "Village";

            Lifepath lpB = new Lifepath();
            lpB.Setting = "Overlook";

            Lifepath lpC = new Lifepath();
            lpC.Setting = "Overpass";

            Assert.IsTrue(lpA.LeadsTo(lpB));
            Assert.IsFalse(lpA.LeadsTo(lpC));
        }
    }
}
