using System;
using System.Collections.Generic;
using System.Text;

namespace DecisionEngine.DAL.Repository.Rules
{
    public class RuleEventArgs : EventArgs
    {
        public RuleEventArgs(double area)
        {
            NewArea = area;
        }

        public double NewArea { get; }
    }
}
