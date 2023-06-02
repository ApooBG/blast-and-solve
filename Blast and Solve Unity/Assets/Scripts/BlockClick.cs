using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockClick : MonoBehaviour
{
    PlacementBlocks placementBlocks;
    LevelCreation levelCreation;

    private void Start()
    {
        placementBlocks = gameObject.transform.parent.GetComponent<PlacementBlocks>();
        levelCreation = gameObject.transform.parent.GetComponent<LevelCreation>();
    }

    void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Block block = levelCreation.ListOfBlocks().Find(x => x.block == gameObject);
            placementBlocks.BlockGridClick(block);
        }
    }
}