using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerSimulationLB1
{
    public class StaticModel
    {
        public int Number { get; set; }
        public double FactorValue { get; set; }
        public double ResponseValue { get; set;}

        public StaticModel(int number, double factorValue, double responseValue)
        {
            Number = number;
            FactorValue = factorValue;
            ResponseValue = responseValue;
        }
    }
}
