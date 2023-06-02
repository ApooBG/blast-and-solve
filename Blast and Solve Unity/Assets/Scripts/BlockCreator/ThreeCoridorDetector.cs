using Assets.Scripts.bomb_attachment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.BlockCreator
{
    public class ThreeCoridorDetector : BombDecorator
    {
        public ThreeCoridorDetector(IBomb decoratedBomb) : base(decoratedBomb)
        {
        }

        public override string Explode()
        {
            string type = base.Explode();
            return type + " Adding three-corridor shape explosion range.";
        }
    }
}
