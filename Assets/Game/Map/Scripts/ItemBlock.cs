using UnityEditor.SearchService;
using UnityEngine;

public class ItemBlock : Block
{
    public string Item;
    public int ScoreValue;

    public override void OnBlockBreak()
    {
        base.OnBlockBreak();
        GameObject managerObject = GameObject.FindGameObjectWithTag("GameController");
        GameManager manager = managerObject.GetComponent<GameManager>();
        manager.AddToScore(ScoreValue);
    }
}
