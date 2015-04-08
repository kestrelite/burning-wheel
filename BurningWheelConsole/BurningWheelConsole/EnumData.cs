using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurningWheelConsole
{
    public enum TraitType
    {
        Character, Die, Callon
    }

    public enum RootStat
    {
        Perception, Will,
        Agility, Forte, Speed, Strength,
        Emotional
    }

    public enum MPPoint
    {
        Pos_M, Pos_P, Pos_MP, Pos_MorP,
        Neg_M, Neg_P, Neg_MP, Neg_MorP,
        None
    }
}
