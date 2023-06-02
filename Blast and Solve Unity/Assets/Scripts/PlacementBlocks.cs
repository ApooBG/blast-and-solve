using Assets.Scripts;
using Assets.Scripts.bomb_attachment;
using Assets.Scripts.bomb_attachment.Decorators;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlacementBlocks : MonoBehaviour
{
    [SerializeField] GameTest gameTest;
    [SerializeField] OnImageClick blockClick;

    BlockType blockType;
    List<IBomb> listOfBombs;

    // Start is called before the first frame update
    void Start()
    {
        // blockType = BlockType.Rubble;
        listOfBombs = new List<IBomb>();
    }

    public void BlockGridClick(Block block)
    {
        if (block.blockType == BlockType.Normal)
        {
            if (blockClick.selectedItem.image.name == "Bomb")
            {
                block.ChangeBlockType(BlockType.Bomb, gameTest.materialsHolder);
                IBomb b = new Bomb();
                listOfBombs.Add(b);
            }
        }

        if (block.blockType == BlockType.Bomb)
        {
            if (blockClick.selectedItem.type == DecoratorTypes.shape)
            {
               // block.ChangeBlockType(BlockType.Bomb, gameTest.materialsHolder);
                IBomb b = listOfBombs[0];
                if (b is BombDecorator)
                {
                    BombDecorator bomb = (BombDecorator)b;
                    BombDecorator nextDecorator = GetDecorator(bomb, blockClick.selectedItem.image);
                    
                    
                }

                else
                {
                    BombDecorator nextDecorator = GetDecorator(b, blockClick.selectedItem.image);
                }
            }
        }
    }

    /*void AddDecoratorToBomb(IBomb b, BombDecorator decorator, DecoratorTypes decoratorTypes)
    {
        if (b is BombDecorator)
        {
            BombDecorator bomb = (BombDecorator)b;
            if (decoratorTypes == DecoratorTypes.shape)
            {
                if (bomb.shape == null)
                {
                    //bomb = new BombDecorator(b);
                }
            }
            BombDecorator nextDecorator = GetDecorator(bomb, blockClick.selectedItem.image);


        }

        else
        {
            BombDecorator nextDecorator = GetDecorator(b, blockClick.selectedItem.image);
        }

    }*/

    BombDecorator GetDecorator(IBomb bomb, Image image)
    {
        BombDecorator bombDecorator = null;
        switch (image.name)
        {
/*            case "Bomb":
                blockType = BlockType.Bomb;
                break;*/
            case "Firestarter":
                break;
            case "Line":
                bombDecorator = new LineShapeDecorator(bomb);
                break;
            case "Three-Corridor":
                bombDecorator = new ThreeCoridorDetector(bomb);
                break;
            case "Circle":
                bombDecorator = new CircleShapeDeconator(bomb);
                break;
            case "Star":
                bombDecorator = new StarShapeDecorator(bomb);
                break;
            case "4-way":
                bombDecorator = new FourWayShapeDecorator(bomb);
                break;
            case "X-Shape":
                bombDecorator = new XShapeDecorator(bomb);
                break;
            case "Triangle":
                //bombDecorator = new (bomb);
                break;
            case "Six-corner":
                bombDecorator = new SixCornerDecorator(bomb);
                break;

            case "fire-explosion":
                bombDecorator = new FireExplosionDecorator(bomb);
                break;
            case "ice-explosion":
                bombDecorator = new IceExplosionDecorator(bomb);
                break;
            case "sonic-explosion":
                bombDecorator = new SonicExplosionDecorator(bomb);
                break;
            case "bouncer-explosion":
                bombDecorator = new BounceExplosionDecorator(bomb);
                break;
            case "detonator-explosion":
                bombDecorator = new DetonatorExplosionDecorator(bomb);
                break;
            case "timer-explosion":
                bombDecorator = new TimerExplosionDecorator(bomb);
                break;

            case "one-explosion-range":
                bombDecorator = new OneExplosionRangeDecorator(bomb);
                break;
            case "two-explosion-range":
                bombDecorator = new TwoExplosionRangeDecorator(bomb);
                break;
            case "one-impact-range":
                bombDecorator = new OneImpactRangeDecorator(bomb);
                break;
            case "two-impact-range":
                bombDecorator = new TwoImpactRangeDecorator(bomb);
                break;
        }

        return bombDecorator;
    }
}
