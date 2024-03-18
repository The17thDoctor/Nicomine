using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Items
{
    CORK = 1, ANTIDOTE = 2
}

public class Inventory : MonoBehaviour
{
    private Dictionary<Items, int> inventory = new();
    public int Corks { get => inventory[Items.CORK]; set => SetItem(Items.CORK, value); }
    public int Antidotes { get => inventory[Items.ANTIDOTE]; set => SetItem(Items.ANTIDOTE, value); }

    public void AddItem(Items item, int amount = 1)
    {
        if (amount < 0) throw new ArgumentException("DONNE PLUS QUE 0 PD");
        inventory[item] += amount;
    }

    public void RemoveItem(Items item, int amount = 1)
    {
        inventory[item] = Mathf.Max(0, inventory[item] - amount);
    }

    private void SetItem(Items item, int count)
    {
        inventory[item] = Mathf.Max(0, count);
    }
}
