using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiRouting
{
    public class ComputeUnit
    {
        public int Value1 { get; set; }
        public int Value2 { get; set; }
        public string Mode { get; set; }
        public int Compute()
        {
            int addedNumbers = -1;
            if (Mode == "addition")
            {
                addedNumbers = Value1 + Value2;
            }
            else if (Mode == "multiplication")
            {
                addedNumbers = Value1 * Value2;
            }

            return addedNumbers;
        }
        public ComputeUnit(int first, int sec)
        {
            Value1 = first;
            Value2 = sec;
        }
    }
}
