using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turnip.Classes
{
    internal class BaseObject
    {
        public string Name { get; set; }
        public BaseObject(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
