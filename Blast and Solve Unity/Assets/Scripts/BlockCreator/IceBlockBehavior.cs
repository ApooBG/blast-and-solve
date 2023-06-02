using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.BlockCreator
{
    public class IceBlockBehavior : IBlockBehaviour
    {
        public string Interact()
        {
            return "This is an ice block";
        }

        public Material Material(MaterialsHolder materials)
        {
            return materials.Ice_Block;
        }
    }
}
