using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurningWheelConsole
{
    public class Character
    {
        public string Race { set; get; }
        private List<Lifepath> _LifepathList = new List<Lifepath>();
        public List<Lifepath> LifepathList 
        {
            private set { }
            get { return _LifepathList; } 
        }

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
