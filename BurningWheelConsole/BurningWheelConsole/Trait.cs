using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurningWheelConsole
{
    public class Trait
    {
        private static List<Trait> _TRAIT_AGGREGATE;
        public static List<Trait> TRAIT_AGGREGATE
        {
            set
            {
                if (TRAIT_AGGREGATE_SET) throw new InvalidOperationException("Can't set trait aggregate twice!");
                TRAIT_AGGREGATE_SET = true;
                Trait._TRAIT_AGGREGATE = value;
            }
            get { return Trait._TRAIT_AGGREGATE; }
        }
        private static bool TRAIT_AGGREGATE_SET = false;

        public string Name { set; get; }
        public string Restrictions { set; get; }
        public bool LPOnlyTrait { set; get; }
        public int Points { set; get; }
        public TraitType TraitType { set; get; }
    }
}

