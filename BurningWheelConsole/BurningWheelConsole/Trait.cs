using BurningWheelConsole.Properties;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurningWheelConsole
{
    public class TraitAggregator
    {
        private static List<Trait> _TRAIT_AGGREGATE;
        private static List<Trait> TRAIT_AGGREGATE
        {
            get
            {
                return _TRAIT_AGGREGATE
                    ?? (_TRAIT_AGGREGATE = JsonConvert.DeserializeObject<List<Trait>>(Resources.TraitsJSON));
            }
        }

        public static int AggregateTraits() { return TRAIT_AGGREGATE.Count(); }

        public static Trait getTraitByName(string name)
        {
            foreach (Trait t in TRAIT_AGGREGATE)
            {
                if (t.Name.Equals(name)) return copyTrait(t);
            }
            return null;
        }

        private static Trait copyTraitList(List<Trait> trait)
        {
            string JSON = JsonConvert.SerializeObject(trait);
            return JsonConvert.DeserializeObject<Trait>(JSON);
        }

        private static Trait copyTrait(Trait trait)
        {
            string JSON = JsonConvert.SerializeObject(trait);
            return JsonConvert.DeserializeObject<Trait>(JSON);
        }
    }

    public class Trait
    {
        public string Name { set; get; }
        public string Text { set; get; }
        public string Restrictions { set; get; }
        public bool LPOnlyTrait { set; get; }
        public int Points { set; get; }
        public TraitType Type { set; get; }
    }
}

