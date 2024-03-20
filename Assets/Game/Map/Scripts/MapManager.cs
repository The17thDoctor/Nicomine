using System;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;

public class MapGenerator : MonoBehaviour
{

    public GameObject Container;
    private GameObject background;

    public GameObject Dirt;
    public GameObject Grass;
    public GameObject Stone;
    public GameObject Bedrock;
    public GameObject CorkOre;
    public GameObject AntidoteOre;

    public int MineEntryX = 0;

    public int HorizontalSize = 100;
    public int VerticalSize = 35;

    public int CorkAmount = 20;
    public int AntidoteAmount = 150;

    private GameObject[,] BlockList; 

    private void Start()
    {
        BlockList = new GameObject[HorizontalSize, VerticalSize];
        background = Container.transform.GetChild(0).gameObject;
        background.transform.position = new Vector3(-0.5f, -VerticalSize / 2 + 0.5f, 3);


        GenerateStone();
        GenerateDirt();
        GenerateOres();
        GenerateBedrock();
        BreakMineEntry();
    }

    private void BreakMineEntry()
    {
        Destroy(BlockList[MineEntryX, 0]);
        Destroy(BlockList[MineEntryX + 1, 0]);
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

    private void GenerateDirt()
    {
        for (int x = 0; x < HorizontalSize; x++)
        {
            SetBlock(x, 0, Instantiate(Grass));
            BlockList[x, 0].GetComponent<Block>().Breakable = false;

            SetBlock(x, 1, Instantiate(Dirt));

            if (Random.Range(0, 10) >= 6)
            {
                SetBlock(x, 2, Instantiate(Dirt));
            }
        }
    }

    private void GenerateOres()
    {
        for (int i = 0; i < AntidoteAmount; i++)
        {
            int x = Random.Range(2, HorizontalSize - 3);
            int y = Random.Range(6, VerticalSize - 1);
            SetBlock(x, y, Instantiate(AntidoteOre));
        }

        for (int i = 0; i < CorkAmount; i++)
        {
            int x = Random.Range(2, HorizontalSize - 3);
            int y = Random.Range(10, VerticalSize - 4);
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

        for (int y = 0; y < VerticalSize; y++)
        {
            SetBlock(0, y, Instantiate(Bedrock));
            SetBlock(HorizontalSize - 1, y, Instantiate(Bedrock));

            if (Random.Range(0, 10) >= 5)
            {
                SetBlock(1, y, Instantiate(Bedrock));
            }

            if (Random.Range(0, 10) >= 5)
            {
                SetBlock(HorizontalSize - 2, y, Instantiate(Bedrock));
            }
        }
    }

    public void MineBlock(int x, int y)
    {
        x -= (int)Container.transform.position.x - HorizontalSize / 2;
        y -= (int)Container.transform.position.y;
        y = -y;

        //Debug.Log($"Les coords {x}, {y}");


        if (x <= 0 || y <= 0 || x > HorizontalSize || y > VerticalSize) return;

        GameObject blockObject = BlockList[x, y];
        if (blockObject == null) return;

        Block block = blockObject.GetComponent<Block>();

        Tuple<int, int>[] adjacents = {
            new(1, 0),
            new(-1, 0),
            new(0, 1),
            new(0, -1)
        };
        
        // If block has been mined.
        if (block.Mine())
        {
            foreach (Tuple<int, int> adjacent in adjacents)
            {
                GameObject adjacentObject = BlockList[x + adjacent.Item1, y + adjacent.Item2];
                if (adjacentObject == null) continue;
                adjacentObject.GetComponent<Block>().Reveal();
            }
        }
    }
    public GameObject GetBlock(int x, int y)
    {
        x -= (int)Container.transform.position.x - HorizontalSize / 2;
        y -= (int)Container.transform.position.y;
        y = -y;

        if (x < 0 || y < 0 || x > HorizontalSize || y > VerticalSize) return null;

        return BlockList[x, y];
    }

        private void SetBlock(int x, int y, GameObject block)
    {
        if (BlockList[x, y] != null)
        {
            Destroy(BlockList[x, y]);
        }

        block.name = $"Block[{x},{y}]";

        BlockList[x, y] = block;
        block.transform.SetParent(Container.transform, false);
        block.transform.position = new Vector3((-HorizontalSize / 2) + x, -y, 0);
    }
}
