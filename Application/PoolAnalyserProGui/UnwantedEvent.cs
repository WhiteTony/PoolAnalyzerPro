using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoolAnalyserProGui
{
    public class UnwantedEvent
    {
        public string Type { get; set; }
        public string Reason { get; set; }
        public double Value { get; set; }
        public DateTime DateTime { get; set; }
        public UnwantedEvent(string _type, string _reason, double _value, DateTime _dateTime)
        {
            Type = _type;
            Reason = _reason;
            Value = _value;
            DateTime = _dateTime;
        }
    }
}
