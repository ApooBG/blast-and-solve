using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.bomb_attachment
{
    public abstract class BombDecorator : IBomb
    {
        protected IBomb decoratedBomb;
        public DecoratorTypes type;

        public BombDecorator(IBomb decoratedBomb)
        {
            this.decoratedBomb = decoratedBomb;
        }

        public virtual string Explode()
        {
            return decoratedBomb.Explode();
        }

        public IBomb GetPreviousDecorator()
        {
            return decoratedBomb;
        }
    }
}
