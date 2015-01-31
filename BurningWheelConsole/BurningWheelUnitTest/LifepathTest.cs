using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BurningWheelConsole;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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

            //The only thing it shouldn't lead to is itself
            Lifepath lpD = new Lifepath();
            lpD.Setting = "Village";

            Assert.IsTrue(lpA.LeadsTo(lpB));
            Assert.IsTrue(lpA.LeadsTo(lpC));
            Assert.IsFalse(lpA.LeadsTo(lpD));
        }

        [TestMethod]
        public void SerializeDeserializeTest()
        {
            Lifepath testLP = new Lifepath();
            testLP.Leads = new List<string>();
            testLP.Leads.Add("Outcast");
            testLP.Name = "Born Peasant";
            testLP.MentalPhysical = MPPoint.POS_MorP;
            testLP.Years = 8;

            string JSON = JsonConvert.SerializeObject(testLP);
            Assert.IsTrue(JSON.Length > 0);

            Lifepath l2 = JsonConvert.DeserializeObject<Lifepath>(JSON);
            StringAssert.Equals(testLP.Name, l2.Name);
            Assert.AreEqual(testLP.Years, l2.Years);
            Assert.AreEqual(testLP.MentalPhysical, l2.MentalPhysical);
        }
    }
}
