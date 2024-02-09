using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BlockType
{
    STONE = 0,
    BEDROCK = 1,
    CORK_ORE = 2,
    ANTIDOTE_ORE = 3
}

public class Block : MonoBehaviour
{

    public bool Breakable;

    // Start is called before the first frame update
    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

    }
}
