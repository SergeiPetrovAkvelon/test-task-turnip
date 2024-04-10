using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Turnip.Interfaces;

namespace Turnip.Classes
{
    internal class Human : Character, IToPlant
    {
        public Human(string name) : base(name)
        {
            canPlanting = true;
        }

        public void ToPlant(Plant plant)
        {
            Console.WriteLine("{0} planted a {1}", Name, plant.ToString());
        }
    }
}
