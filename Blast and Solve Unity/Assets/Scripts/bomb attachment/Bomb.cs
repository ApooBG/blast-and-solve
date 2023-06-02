using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.bomb_attachment
{
    public class Bomb : IBomb
    {
        public Block block;

        public string Explode() 
        {
            return "Normal Bomb";
        }
    }
}
