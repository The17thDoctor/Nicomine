using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{

    public GameObject Container;

    public GameObject Stone;
    public GameObject Bedrock;
    public GameObject CorkOre;
    public GameObject AntidoteOre;

    public int HorizontalSize = 100;
    public int VerticalSize = 30;

    public int CorkAmount = 20;
    public int AntidoteAmount = 150;

    private GameObject[,] BlockList; 

    // Start is called before the first frame update
    private void Start()
    {
        BlockList = new GameObject[HorizontalSize, VerticalSize];
        GenerateStone();
        GenerateOres();
        GenerateBedrock();
    }

    // Update is called once per frame
    private void Update()
    {
        
    }

    private void GenerateStone()
    {
        for (int x = 0; x < HorizontalSize; x++)
        {
            for (int y = 0; y < VerticalSize; y++)
            {
                SetBlock(x, y, Instantiate(Stone));
            }
        }
    }

    private void GenerateOres()
    {
        for (int i = 0; i < AntidoteAmount; i++)
        {
            int x = Random.Range(0, HorizontalSize - 1);
            int y = Random.Range(3, VerticalSize - 1);
            SetBlock(x, y, Instantiate(AntidoteOre));
        }

        for (int i = 0; i < CorkAmount; i++)
        {
            int x = Random.Range(0, HorizontalSize - 1);
            int y = Random.Range(7, VerticalSize - 4);
            SetBlock(x, y, Instantiate(CorkOre));
        }
    }

    private void GenerateBedrock()
    {
        for (int x = 0; x < HorizontalSize; x++)
        {
            // Bottom layer
            SetBlock(x, VerticalSize - 1, Instantiate(Bedrock));

            float random = Random.Range(0, 10);
            if (random >= 4)
            {
                SetBlock(x, VerticalSize - 2, Instantiate(Bedrock));
                if (random >= 7.5)
                {
                    SetBlock(x, VerticalSize - 3, Instantiate(Bedrock));
                }
            }
        }
    }

    private void SetBlock(int x, int y, GameObject block)
    {
        if (BlockList[x, y] != null)
        {
            Destroy(BlockList[x, y]);
        }

        BlockList[x, y] = block;
        block.transform.SetParent(Container.transform, false);
        block.transform.position = new Vector3((-HorizontalSize / 2) + x, -y, 0);
    }
}
