using UnityEngine;

public class Block : MonoBehaviour
{

    public bool Breakable;

    private bool _hidden = true;
    public bool Hidden { get => _hidden; }

    public Sprite BlockSprite;
    public Sprite HiddenSprite;

    // Start is called before the first frame update
    private void Start()
    {
        GetComponent<SpriteRenderer>().sprite = _hidden ? HiddenSprite : BlockSprite;
    }

    // Update is called once per frame
    private void Update()
    {
        
    }

    public void Reveal()
    {
        _hidden = false;
        GetComponent<SpriteRenderer>().sprite = BlockSprite;
    }

    public void Hide()
    {
        _hidden = true;
        GetComponent<SpriteRenderer>().sprite = HiddenSprite;
    }
}
