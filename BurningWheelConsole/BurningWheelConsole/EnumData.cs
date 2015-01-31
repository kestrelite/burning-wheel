using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurningWheelConsole
{
    public enum TraitType
    {
        CHAR, DT, CO
    }

    public enum RootStat
    {
        PERC, WILL,
        AGIL, FORT, SPD, STR,
        HATE, GREED, GRIEF,
        NONE
    }

    public enum MPPoint
    {
        POS_M, POS_P, POS_MP, POS_MorP,
        NEG_M, NEG_P, NEG_MP, NEG_MorP
    }
}
