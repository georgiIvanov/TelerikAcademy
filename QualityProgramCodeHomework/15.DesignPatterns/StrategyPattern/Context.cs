using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StrategyPattern
{
    class Context
    {
        private IStrategy strategy;

        public int ExecuteStrategy(int first, int second)
        {
            DetermineAction(first, second);

            return this.strategy.Execute(first, second);
        }

        void DetermineAction(int first, int second)
        {
            if (first > second)
            {
                this.strategy = new Subtract();
            }
            else if (first < second)
            {
                this.strategy = new Add();
            }
            else
            {
                this.strategy = new Multiply();
            }
        }
    }
}
