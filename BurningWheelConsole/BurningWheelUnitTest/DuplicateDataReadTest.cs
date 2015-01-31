using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BurningWheelConsole;

namespace BurningWheelUnitTest
{
    [TestClass]
    public class DuplicateDataReadTest
    {
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void NoDuplicateLifepathsAggregation()
        {
            Lifepath.LIFEPATH_AGGREGATE = new System.Collections.Generic.List<Lifepath>();
            Lifepath.LIFEPATH_AGGREGATE = new System.Collections.Generic.List<Lifepath>();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void NoDuplicateTraitsAggregation()
        {
            Trait.TRAIT_AGGREGATE = new System.Collections.Generic.List<Trait>();
            Trait.TRAIT_AGGREGATE = new System.Collections.Generic.List<Trait>();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void NoDuplicateSkillsAggregation()
        {
            Skill.SKILL_AGGREGATE = new System.Collections.Generic.List<Skill>();
            Skill.SKILL_AGGREGATE = new System.Collections.Generic.List<Skill>();
        }
    }
}
