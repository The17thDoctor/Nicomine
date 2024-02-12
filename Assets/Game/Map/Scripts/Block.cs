using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{

    public bool Breakable;

    private bool _hidden = true;

    [field:SerializeField]
    public bool Hidden
    {
        get => _hidden;
        set
        {
            _hidden = value;
            GetComponent<SpriteRenderer>().sprite = value ? HiddenSprite : BlockSprite;
        }
    }

    public Sprite BlockSprite;
    public Sprite HiddenSprite;

    // Start is called before the first frame update
    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        
    }
}
