using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Turnip.Interfaces;

namespace Turnip.Classes
{
    internal class Character : BaseObject, IToCall, IToPull, IToGrab
    {
        public bool canPlanting;
        public BaseObject GrabedCharacter { get; set; }
        public Character(string name) : base(name)
        { }


        public void ToCall(Character character)
        {
            Console.WriteLine("The {0} called the {1} for help.",this.Name, character);
        }

        public string ToGrab(BaseObject character)
        {
            this.GrabedCharacter = character;
            return ToGrab();
        }

        public string ToGrab()
        {
            return this.Name + " for " + this.GrabedCharacter;
        }

        public void ToPull(Plant plant)
        {
            Console.Write("The {0} began to pull the {1} out of the ground: he pulled and pulled,",this.Name, plant);
        }
    }
}
