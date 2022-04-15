using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2_C_Sharp_ {
    public struct Task {
        public string name;
        public string start_time;
        public string duration;
    }

    public struct Time {
        public int hours;
        public int minutes;
    }

    public struct Time_Period {
        public Time start;
        public Time end;
    }
}
