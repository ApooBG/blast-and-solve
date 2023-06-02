﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.bomb_attachment.Decorators
{
    public class TwoImpactRangeDecorator : BombDecorator
    {
        public TwoImpactRangeDecorator(IBomb decoratedBomb) : base(decoratedBomb)
        {
            type = DecoratorTypes.range;
        }

        public override string Explode()
        {
            string type = base.Explode();
            return type + " Adding two impact range.";
        }
    }
}