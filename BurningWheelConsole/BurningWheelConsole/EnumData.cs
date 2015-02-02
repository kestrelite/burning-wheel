using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurningWheelConsole
{
    public enum TraitType
    {
        CHARACTER, DIE, CALLON
    }

    public enum RootStat
    {
        PERCEPTION, WILL,
        AGILITY, FORTE, SPEED, STRENGTH,
        EMOTIONAL
    }

    public enum MPPoint
    {
        POS_M, POS_P, POS_MP, POS_MorP,
        NEG_M, NEG_P, NEG_MP, NEG_MorP,
        NONE
    }
}
