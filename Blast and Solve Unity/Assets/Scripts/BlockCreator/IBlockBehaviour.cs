using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public interface IBlockBehaviour
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
