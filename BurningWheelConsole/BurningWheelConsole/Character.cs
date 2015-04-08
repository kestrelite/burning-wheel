using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurningWheelConsole
{
    public class Character
    {
        public string Name { set; get; }
        public string Concept { set; get; }
        public string Race { set; get; }
        public int Age { set; get; }

        private List<String> _BeliefsList = new List<String>();
        public List<String> BeliefsList
        {
            private set { }
            get { return _BeliefsList; }
        }

        private List<String> _InstinctsList = new List<String>();
        public List<String> InstinctsList
        {
            private set { }
            get { return _InstinctsList; }
        }

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

        public void AddBelief(string s)
        {
            _BeliefsList.Add(s);
        }

        public void DropBelief(int ind)
        {
            _BeliefsList.RemoveAt(ind);
        }

        public void AddInstinct(string s)
        {
            _InstinctsList.Add(s);
        }

        public void DropInstinct(int ind)
        {
            _InstinctsList.RemoveAt(ind);
        }
    }
}
