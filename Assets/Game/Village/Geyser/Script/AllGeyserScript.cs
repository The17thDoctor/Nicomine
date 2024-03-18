using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class AllGeyserScript : MonoBehaviour
{
    private int geyserNumber = 0;
    private GameObject[] allGeyser;
    private int[] allGeyserState;
    public Sprite spriteClose;
    public Sprite spriteOpen;
    public Sprite spritePlug;
    public int timePeriod = 10;
    void Start()
    {
        SpriteRenderer[] allGeyserSprite = this.gameObject.GetComponentsInChildren<SpriteRenderer>();
        allGeyser = new GameObject[allGeyserSprite.Length];
        for (int increment = 0; increment<allGeyserSprite.Length;increment++)
        {
            allGeyser[increment] = allGeyserSprite[increment].gameObject;
        }
        SetGeyserNumber(allGeyser.Length);
        allGeyserState = new int[geyserNumber];
        for (int increment = 0;increment<geyserNumber; increment++) {
            allGeyserState[increment] = 0;
            allGeyser[increment].GetComponent<SpriteRenderer>().sprite = spriteClose;
        }
    }

    private void SetGeyserNumber(int number)
    {
        geyserNumber = number;
    }

    public void ChangeGeyserState(int time)
    {
        if (time%timePeriod==0)
        {
            OpenGeyser();
        }
    }

    public void OpenGeyser()
    {
        bool flag = false;
        foreach (int isGeyserOpen in allGeyserState)
        {
            if (isGeyserOpen==0)
            {
                flag = true;
                break;
            }
        }
        if (!flag)
        {
            return;
        }

        while (true){
            int indexRandom = new System.Random().Next(0, geyserNumber);
            int elementRandom = allGeyserState[indexRandom];
            if (elementRandom==0)
            {
                allGeyserState[indexRandom] = 1;
                allGeyser[indexRandom].GetComponent<SpriteRenderer>().sprite = spriteOpen;
                return;
            }
        }
    }

    public void CloseGeyser(GameObject child)
    {
        for(int increment = 0; increment<allGeyser.Length;increment++)
        {
            if (child==allGeyser[increment])
            {
                allGeyserState[increment] = 2;
                allGeyser[increment].GetComponent<SpriteRenderer>().sprite = spritePlug;
            }
        }
    }
}
