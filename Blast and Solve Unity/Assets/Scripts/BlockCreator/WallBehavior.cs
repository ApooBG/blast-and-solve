using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public class WallBehavior : IBlockBehaviour
    {
        public string Interact()
        {
            return "This is a wall block";
        }

        public Material Material(MaterialsHolder materials)
        {
            return materials.Wall_Block;
        }
    }
}
