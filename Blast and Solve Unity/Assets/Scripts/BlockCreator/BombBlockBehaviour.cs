using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.BlockCreator
{
    public class BombBlockBehaviour : IBlockBehaviour
    {
        public string Interact()
        {
            return "This is a bomb block";
        }

        public Material Material(MaterialsHolder materials)
        {
            return materials.Bomb_Special;
        }
    }
}
