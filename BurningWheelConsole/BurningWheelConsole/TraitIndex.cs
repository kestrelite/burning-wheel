using BurningWheelConsole.Properties;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurningWheelConsole
{
    public static class TraitIndex
    {
        private static List<Trait> _TRAIT_AGGREGATE;
        private static List<Trait> TRAIT_AGGREGATE
        {
            get
            {
                if (_TRAIT_AGGREGATE == null)
                {
                    _TRAIT_AGGREGATE = JsonConvert.DeserializeObject<List<Trait>>(Resources.TraitsJSON);

                    foreach (Trait t in _TRAIT_AGGREGATE)
                    {
                        NullReferenceException e = new NullReferenceException("Null field in Trait " + t.Name);

                        if (t.Name == null) throw e;
                        if (t.Restrictions == null) throw e;
                        if (t.Text == null) throw e;
                    }
                }

                return _TRAIT_AGGREGATE;
            }
        }

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
}
