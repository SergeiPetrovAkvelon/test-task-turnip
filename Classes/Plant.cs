using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Turnip.Interfaces;

namespace Turnip.Classes
{
    internal class Plant : BaseObject, IToGrow
    {
        public Plant(string name) : base(name)
        { }

        public void ToGrow()
        {
            Console.WriteLine("The {0} grew big, very big.", this.Name);
        }
    }
}
