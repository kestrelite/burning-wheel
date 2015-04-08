using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BurningWheelConsole
{
    public enum StatLevels
    {
        Black, Grey, White
    }

    public class StatValue
    {
        public StatLevels level { set; get; }
        public int dice { set; get; }

        public StatValue(StatLevels level, int val)
        {
            this.level = level;
            this.dice = val;
        }
    }

    public class StatRecorder
    {
        private List<KeyValuePair<string, StatValue>> records = new List<KeyValuePair<string, StatValue>>();

        public StatRecorder() { }

        public bool AddValue(RootStat r, StatValue stat)
        {
            return AddValue(r.ToString(), stat);
        }

        public bool AddValue(string id, StatValue stat)
        {
            bool already_exists = DelValue(id);
            records.Add(new KeyValuePair<string, StatValue>(id, stat));
            return already_exists;
        }

        public bool HasValue(RootStat r)
        {
            return HasValue(r.ToString());
        }

        public bool HasValue(string id)
        {
            foreach (KeyValuePair<string, StatValue> record in records)
                if (record.Key.Equals(id)) return true;
            return false;
        }

        public StatValue GetValue(RootStat r)
        {
            return GetValue(r.ToString());
        }

        public StatValue GetValue(string id)
        {
            foreach (KeyValuePair<string, StatValue> record in records)
                if (record.Key.Equals(id)) return record.Value;
            return null;
        }

        public bool DelValue(RootStat r)
        {
            return DelValue(r.ToString());
        }

        public bool DelValue(string id)
        {
            return records.RemoveAll(x => x.Key.Equals(id)) > 0;
        }
    }
}
