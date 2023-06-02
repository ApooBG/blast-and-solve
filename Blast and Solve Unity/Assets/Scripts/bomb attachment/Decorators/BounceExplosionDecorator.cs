using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.bomb_attachment.Decorators
{
    public class BounceExplosionDecorator : BombDecorator
    {
        public BounceExplosionDecorator(IBomb decoratedBomb) : base(decoratedBomb)
        {
        }

        public override string Explode()
        {
            string type = base.Explode();
            return type + " Adding bounce explosion effect.";
        }
    }
}
