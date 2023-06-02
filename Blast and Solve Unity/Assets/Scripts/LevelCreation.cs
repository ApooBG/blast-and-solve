using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCreation : MonoBehaviour
{
    [SerializeField] GameObject startBlock;
    [SerializeField] int columnNum;
    [SerializeField] int rowNum;

    List<Block> listOfBlocks;

    // Start is called before the first frame update
    void Start()
    {
        listOfBlocks = new List<Block>();
        BuildGrid();
    }

    void BuildGrid()
    {
        Block block = new Block(1, startBlock);
        listOfBlocks.Add(block);

        int i = 1;
        while (columnNum * rowNum > listOfBlocks.Count)
        {
            GameObject newBlock = Instantiate(startBlock);
            newBlock.transform.parent = startBlock.transform.parent;

            if (listOfBlocks.Count % columnNum == 0)
            {
                GameObject firstBlockInTheRow = listOfBlocks[listOfBlocks.Count - columnNum].block;
                newBlock.transform.position = new Vector3(firstBlockInTheRow.transform.position.x, firstBlockInTheRow.transform.position.y, firstBlockInTheRow.transform.position.z + 1f);
            }

            else
            {
                GameObject lastBlockInTheRow = listOfBlocks[listOfBlocks.Count-1].block;
                newBlock.transform.position = new Vector3(lastBlockInTheRow.transform.position.x - 1f, lastBlockInTheRow.transform.position.y, lastBlockInTheRow.transform.position.z);
            }

            i++;

            Block block2 = new Block(i, newBlock);
            listOfBlocks.Add(block2);
        }
    }

    public List<Block> ListOfBlocks()
    {
        return listOfBlocks;
    }
}
