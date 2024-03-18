using UnityEngine;

public class Block : MonoBehaviour
{

    public bool Breakable;

    private bool _hidden = true;
    public bool Hidden { get => _hidden; }

    public int Health = 3;

    public Sprite BlockSprite;
    public Sprite HiddenSprite;

    private void Start()
    {
        GetComponent<SpriteRenderer>().sprite = _hidden ? HiddenSprite : BlockSprite;
    }

    public virtual void OnBlockBreak()
    {
        Debug.Log("KACER LE BLOKKKKKKKKKKKKKKKKK");
    }

    public bool Mine()
    {
        Health -= 1;
        if (Health <= 0)
        {
            OnBlockBreak();
            Destroy(gameObject);
            return true;
        }

        return false;
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
