using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.BlockCreator
{
    public class NormalBlockBehavior : IBlockBehaviour 
    {
        public string Interact()
        {
            return "This is a normal block";
        }

        public Material Material(MaterialsHolder materials)
        {
            return materials.Empty_Block;
        }
    }
}
