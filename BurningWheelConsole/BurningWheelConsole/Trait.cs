using BurningWheelConsole.Properties;
using Newtonsoft.Json;
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
            get
            {
                return _TRAIT_AGGREGATE
                    ?? (_TRAIT_AGGREGATE = JsonConvert.DeserializeObject<List<Trait>>(Resources.TraitsJSON));
            }
        }

        public static int AggregateTraits() { return Trait.TRAIT_AGGREGATE.Count(); }

        public string Name { set; get; }
        public string Restrictions { set; get; }
        public bool LPOnlyTrait { set; get; }
        public int Points { set; get; }
        public TraitType TraitType { set; get; }
    }
}

