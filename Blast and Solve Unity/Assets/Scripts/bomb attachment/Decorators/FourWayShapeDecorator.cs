using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.bomb_attachment.Decorators
{
    public class FourWayShapeDecorator : BombDecorator
    {
        public FourWayShapeDecorator(IBomb decoratedBomb) : base(decoratedBomb)
        {
        }

        public override string Explode()
        {
            string type = base.Explode();
            return type + " Adding four-way shape decorator.";
        }
    }
}
