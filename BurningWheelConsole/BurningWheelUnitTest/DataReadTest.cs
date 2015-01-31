using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BurningWheelConsole;
using Newtonsoft.Json;
using System.Collections.Generic;
using BurningWheelConsole.Properties;

namespace BurningWheelUnitTest
{
    [TestClass]
    public class DataReadTest
    {
        [TestMethod]
        public void DeserializationTestLifepaths()
        {
            List<Lifepath> t = JsonConvert.DeserializeObject<List<Lifepath>>(Resources.LifepathsJSON);
            Lifepath.LIFEPATH_AGGREGATE = t;
            Assert.IsTrue(Lifepath.LIFEPATH_AGGREGATE != null);
            Assert.IsTrue(Lifepath.LIFEPATH_AGGREGATE.Count > 0);
        }

        [TestMethod]
        public void DeserializationTestSkills()
        {
            List<Skill> t = JsonConvert.DeserializeObject<List<Skill>>(Resources.SkillsJSON);
            Skill.SKILL_AGGREGATE = t;
            Assert.IsTrue(Skill.SKILL_AGGREGATE != null);
            Assert.IsTrue(Skill.SKILL_AGGREGATE.Count > 0);
        }

        [TestMethod]
        public void DeserializationTestTraits()
        {
            List<Trait> t = JsonConvert.DeserializeObject<List<Trait>>(Resources.TraitsJSON);
            Trait.TRAIT_AGGREGATE = t;
            Assert.IsTrue(Trait.TRAIT_AGGREGATE != null);
            Assert.IsTrue(Trait.TRAIT_AGGREGATE.Count > 0);
        }
    }
}
