using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public class RiverBlockBehavior : IBlockBehaviour
    {
        public string Interact()
        {
            return "This is a river block";
        }

        public Material Material(MaterialsHolder materials)
        {
            return materials.River_Block;
        }
    }
}
