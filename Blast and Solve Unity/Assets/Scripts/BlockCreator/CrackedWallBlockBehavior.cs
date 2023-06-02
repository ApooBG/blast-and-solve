using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.BlockCreator
{
    public class CrackedWallBlockBehavior : IBlockBehaviour
    {
        public string Interact()
        {
            return "This is a cracked_wall block";
        }

        public Material Material(MaterialsHolder materials)
        {
            return materials.CrackedWall_Block;
        }
    }
}
