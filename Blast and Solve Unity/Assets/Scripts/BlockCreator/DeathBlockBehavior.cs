using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.BlockCreator
{
    public class DeathBlockBehavior : IBlockBehaviour
    {
        public string Interact()
        {
            return "This is a Death block";
        }

        public Material Material(MaterialsHolder materials)
        {
            return materials.Death_Block;
        }
    }
}
