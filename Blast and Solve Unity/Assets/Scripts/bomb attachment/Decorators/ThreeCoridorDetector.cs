using Assets.Scripts.bomb_attachment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.bomb_attachment.Decorators
{
    public class ThreeCoridorDetector : BombDecorator
    {
        public ThreeCoridorDetector(IBomb decoratedBomb, List<BombDecorator> listOfDecorators, Bomb b) : base(decoratedBomb, listOfDecorators, b)
        {
            listOfDecorators.Add(this);
            type = DecoratorTypes.shape;
        }

        public override string Explode()
        {
            string type = base.Explode();
            return type + " Adding three-corridor shape.";
        }
    }
}
