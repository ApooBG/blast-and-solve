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
                ((Bomb)b).block = block;
                listOfBombs.Add(b);
            }
        }

        else if (block.blockType == BlockType.Bomb)
        {
            foreach (IBomb b in listOfBombs)
            {
                Bomb originalBomb = GetOriginalBomb(b);
                if (block == originalBomb.block)
                {
                    Decorator decorator = blockClick.selectedItem;
                    if (!CheckIfTypeAlreadyAttached(b, decorator.type))
                    {
                        BombDecorator test = GetDecorator(b, decorator.image);
                        listOfBombs.Remove(b);
                        listOfBombs.Add(test);
                        Debug.Log(test.Explode());
                        break;
                    }
                }
            }

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

    bool CheckIfTypeAlreadyAttached(IBomb b, DecoratorTypes type) //checks if the bomb has the same type of decorator attached
    {
        List<BombDecorator> listOfBombDecorators = GetListOfDecorations(b);

        if (listOfBombDecorators.Count == 0)
        {
            return false;
        }

        else
        {
            foreach (BombDecorator bombDecorator in listOfBombDecorators)
            {
                if (bombDecorator.type == type)
                {
                    return true;
                }
            }

            return false;
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
                bombDecorator = new LineShapeDecorator(bomb, GetListOfDecorations(bomb), GetOriginalBomb(bomb));
                break;
            case "Three-Corridor":
                bombDecorator = new ThreeCoridorDetector(bomb, GetListOfDecorations(bomb), GetOriginalBomb(bomb));
                break;
            case "Circle":
                bombDecorator = new CircleShapeDeconator(bomb, GetListOfDecorations(bomb), GetOriginalBomb(bomb));
                break;
            case "Star":
                bombDecorator = new StarShapeDecorator(bomb, GetListOfDecorations(bomb), GetOriginalBomb(bomb));
                break;
            case "4-way":
                bombDecorator = new FourWayShapeDecorator(bomb, GetListOfDecorations(bomb), GetOriginalBomb(bomb));
                break;
            case "X-Shape":
                bombDecorator = new XShapeDecorator(bomb, GetListOfDecorations(bomb), GetOriginalBomb(bomb));
                break;
            case "Triangle":
                //bombDecorator = new (bomb);
                break;
            case "Six-corner":
                bombDecorator = new SixCornerDecorator(bomb, GetListOfDecorations(bomb), GetOriginalBomb(bomb));
                break;

            case "fire-explosion":
                bombDecorator = new FireExplosionDecorator(bomb, GetListOfDecorations(bomb), GetOriginalBomb(bomb));
                break;
            case "ice-explosion":
                bombDecorator = new IceExplosionDecorator(bomb, GetListOfDecorations(bomb), GetOriginalBomb(bomb));
                break;
            case "sonic-explosion":
                bombDecorator = new SonicExplosionDecorator(bomb, GetListOfDecorations(bomb), GetOriginalBomb(bomb));
                break;
            case "bouncer-explosion":
                bombDecorator = new BounceExplosionDecorator(bomb, GetListOfDecorations(bomb), GetOriginalBomb(bomb));
                break;
            case "detonator-explosion":
                bombDecorator = new DetonatorExplosionDecorator(bomb, GetListOfDecorations(bomb), GetOriginalBomb(bomb));
                break;
            case "timer-explosion":
                bombDecorator = new TimerExplosionDecorator(bomb, GetListOfDecorations(bomb), GetOriginalBomb(bomb));
                break;

            case "one-explosion-range":
                bombDecorator = new OneExplosionRangeDecorator(bomb, GetListOfDecorations(bomb), GetOriginalBomb(bomb));
                break;
            case "two-explosion-range":
                bombDecorator = new TwoExplosionRangeDecorator(bomb, GetListOfDecorations(bomb), GetOriginalBomb(bomb));
                break;
            case "one-impact-range":
                bombDecorator = new OneImpactRangeDecorator(bomb, GetListOfDecorations(bomb), GetOriginalBomb(bomb));
                break;
            case "two-impact-range":
                bombDecorator = new TwoImpactRangeDecorator(bomb, GetListOfDecorations(bomb), GetOriginalBomb(bomb));
                break;
        }

        return bombDecorator;
    }

    List<BombDecorator> GetListOfDecorations(IBomb b)
    {
        List<BombDecorator> listOfDecorations = new List<BombDecorator>();

        try
        {
            return ((BombDecorator)b).decorators;
            
        }

        catch
        {
            return listOfDecorations;
        }
    }

    Bomb GetOriginalBomb(IBomb b)
    {
        try
        {
            return (Bomb)b;
        }

        catch
        {
            return ((BombDecorator)b).originalBomb;
        }
    }
}
