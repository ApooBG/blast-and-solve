using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.BlockCreator
{
    public class RubbleBlockBehavior : IBlockBehaviour
    {
        public string Interact()
        {
            return "This is a rubble block";
        }

        public Material Material(MaterialsHolder materials)
        {
            return materials.Rubble_Block;
        }
    }
}
