using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeyserScript : MonoBehaviour
{
    public int geyserNumber = 0;
    public GameObject[] allGeyser;
    private bool[] allGeyserBool;
    public Sprite spriteOpen;
    public Sprite spriteClose;
    // Start is called before the first frame update
    void Start()
    {
        SetGeyserNumber(4);
        allGeyserBool = new bool[geyserNumber];
        for (int increment = 0;increment<geyserNumber; increment++) {
            allGeyserBool[increment] = false;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void SetGeyserNumber(int number)
    {
        geyserNumber = number;
    }

    public void ChangeGeyserState(int time)
    {
        if (time%60==0)
        {
            OpenGeyser();
        }
    }

    public void OpenGeyser()
    {
        bool flag = false;
        foreach (bool isGeyserOpen in allGeyserBool)
        {
            if (!isGeyserOpen)
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
            int indexRandom = Random.Range(0, geyserNumber);
            bool elementRandom = allGeyserBool[indexRandom];
            if (!elementRandom)
            {
                allGeyserBool[indexRandom] = true;
                SpriteRenderer sprite = allGeyser[indexRandom].GetComponent<SpriteRenderer>();
                sprite.sprite = spriteOpen;
                Debug.Log(allGeyserBool);
                return;
            }
        }
    }
}
