using Assets.Scripts;
using Assets.Scripts.bomb_attachment;
using Assets.Scripts.bomb_attachment.Decorators;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GameTest : MonoBehaviour
{
    public MaterialsHolder materialsHolder;

    [SerializeField] LevelCreation levelCreation;
    Block block;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Check if the ray hits a game object
            if (Physics.Raycast(ray, out hit))
            {
                // Log the name of the clicked game object
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            ChangeTheBlock();
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            //Bomb();
        }

        if (Input.GetKeyDown(KeyCode.F1))
        {

        }
    }

    void ChangeTheBlock()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        // Check if the ray hits a game object
        if (Physics.Raycast(ray, out hit))
        {
            // Log the name of the clicked game object
            Debug.Log("Clicked object: " + hit.collider.gameObject.name);
        }
        block = levelCreation.ListOfBlocks().Find(x => x.block == hit.collider.gameObject);

        block.ChangeBlockType(BlockType.Rubble, materialsHolder);
        Debug.Log(block.Interact());
    }

    void FireBomb()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        // Check if the ray hits a game object
        if (Physics.Raycast(ray, out hit))
        {
            // Log the name of the clicked game object
            Debug.Log("Clicked object: " + hit.collider.gameObject.name);
        }
        block = levelCreation.ListOfBlocks().Find(x => x.block == hit.collider.gameObject);

        if (block.blockType == BlockType.Bomb)
        {

        }

    }


/*    void Bomb()
    {
        IBomb bomb = new Bomb();
        Debug.Log(bomb.Explode());
        ((Bomb)bomb).block

        BombDecorator fireDecorator = new FireExplosionDecorator(bomb);
        
        fireDecorator.block

        Debug.Log(fireDecorator.Explode());

        BombDecorator lineFireDecorator = new LineShapeDecorator(fireDecorator);
        Debug.Log(lineFireDecorator.Explode());
    }*/
}
