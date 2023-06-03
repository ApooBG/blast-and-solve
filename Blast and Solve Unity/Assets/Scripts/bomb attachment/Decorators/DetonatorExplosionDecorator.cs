using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.bomb_attachment.Decorators
{
    public class DetonatorExplosionDecorator : BombDecorator
    {
        public DetonatorExplosionDecorator(IBomb decoratedBomb, List<BombDecorator> listOfDecorators, Bomb b) : base(decoratedBomb, listOfDecorators, b)
        {
            listOfDecorators.Add(this);
            type = DecoratorTypes.explosion;
        }

        public override string Explode()
        {
            string type = base.Explode();
            return type + " Adding detonator explosion effect.";
        }
    }
}
