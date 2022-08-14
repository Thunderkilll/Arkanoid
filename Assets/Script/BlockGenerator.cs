using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockGenerator : MonoBehaviour
{
    public GameObject[] blockList;
    public GameObject brikPrefab;
    public GameObject brickHolder;
    public int raws = 0;
    public int columns = 0;
    public float spacing;
    public Vector3 offset = new Vector3(0, 0, 0);
    public bool canRandomize = false;

    void Start()
    {
        if (canRandomize)
        {
            CreateRandomBlocks();
        }
        else
        {
             CreateBlocks();
        }
       
        brickHolder.transform.position += offset;
    }

    private void CreateRandomBlocks()
    {
        
        for (int i = 0; i < raws; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                int index = RandomBrickPosition();
                Vector3 spawnPos = brickHolder.transform.position + new Vector3(-i * (blockList[index].transform.localScale.x + spacing), j * (brikPrefab.transform.localScale.y + spacing), 0);
                GameObject brik = Instantiate(blockList[index], spawnPos, Quaternion.identity);
                brik.transform.parent = brickHolder.transform;
            }
        }
    }

    int RandomBrickPosition()
    {
        int random = Random.Range(0, blockList.Length);
        return random;
    }
    public void CreateBlocks()
    {
        //int k = 0;
        for (int i = 0; i < raws; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                Vector3 spawnPos = brickHolder.transform.position + new Vector3(-i * (brikPrefab.transform.localScale.x + spacing),j * (brikPrefab.transform.localScale.y + spacing) , 0);
                GameObject brik = Instantiate(brikPrefab, spawnPos , Quaternion.identity );
                brik.transform.parent = brickHolder.transform;
            }
        }
    }
}
