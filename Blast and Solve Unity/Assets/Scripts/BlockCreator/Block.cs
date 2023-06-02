using Assets.Scripts.BlockCreator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts
{
    public class Block
    {
        public int gridNumber { get; }
        public GameObject block { get; }
        public BlockType blockType { get; private set; }

        IBlockBehaviour behaviour;

        public Block(int gridNumber, GameObject block)
        {
            this.gridNumber = gridNumber;
            this.block = block;
            blockType = BlockType.Normal;
            this.behaviour = new WallBehavior();
        }

        public void ChangeBlockType(BlockType blockType, MaterialsHolder materials)
        {
            IBlockBehaviour behaviour;
            switch (blockType)
            {
                case BlockType.Bomb:
                    behaviour = new BombBlockBehaviour();
                break;

                case BlockType.Rubble:
                    behaviour = new RubbleBlockBehavior();
                break;

                case BlockType.River:
                    behaviour = new RiverBlockBehavior();
                break;

                case BlockType.CrackedWall:
                    behaviour = new CrackedWallBlockBehavior();
                break;

                case BlockType.Death:
                    behaviour = new DeathBlockBehavior();
                break;

                case BlockType.Ice:
                    behaviour = new IceBlockBehavior();
                break;

                case BlockType.Wall:
                    behaviour = new WallBehavior();
                break;

                default:
                    behaviour = new NormalBlockBehavior();
                break;
            }

            this.behaviour = behaviour;
            this.blockType = blockType;
            UpdateMaterial(behaviour, materials);
        }

        public string Interact()
        {
            return behaviour.Interact();
        }

        void UpdateMaterial(IBlockBehaviour behaviour, MaterialsHolder materials)
        {
            Renderer renderer = block.GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.material = behaviour.Material(materials);
            }
        }
    }
}
