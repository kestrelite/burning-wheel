using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurningWheelConsole
{
    public class Character
    {
        private List<Lifepath> LifepathList = new List<Lifepath>();

        public List<Lifepath> GetLifepathList() { return LifepathList; }

        public void AddLifepath(Lifepath lp)
        {
            if (lp == null) throw new ArgumentNullException();
            LifepathList.Add(lp);
        }

        //Bool indicates whether the item was actually in the list at all
        public bool DropLifepath(Lifepath lp)
        {
            if (LifepathList.Contains(lp))
            {
                LifepathList.Remove(lp);
                return true;
            }
            return false;
        }
    }
}
