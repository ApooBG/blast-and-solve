using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public enum DecoratorTypes
    {
        special,
        shape,
        explosion,
        range
    }

    public class Decorator
    {
        public DecoratorTypes type;
        public Image image;
        public Vector3 originalScale;
        public int numberOfItem;

        public Decorator(DecoratorTypes type, Image image, Vector3 originalScale)
        {
            this.type = type;
            this.image = image;
            this.originalScale = originalScale;
            numberOfItem = 0;
        }
    }
}
