using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBlock : Block
{
    public string Item;

    public override void OnBlockBreak()
    {
        base.OnBlockBreak();
        Debug.Log(Item);
    }
}
