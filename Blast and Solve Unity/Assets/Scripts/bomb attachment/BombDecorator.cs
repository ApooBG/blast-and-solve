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
        public List<BombDecorator> decorators;
        public Bomb originalBomb;

        public BombDecorator(IBomb decoratedBomb, List<BombDecorator> decorators, Bomb originalBomb)
        {
            this.decoratedBomb = decoratedBomb;
            this.decorators = decorators;
            this.originalBomb = originalBomb;
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
