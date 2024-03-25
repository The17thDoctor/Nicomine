using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SingleGeyserScript : MonoBehaviour
{
    public GameObject player;
    public Button button;
    public Inventory stockage;
    private AllGeyserScript allgeyserscript;
    private bool[] trigger;
    private int identity_child;
    private int number_child;
    private void Start()
    {
        button.onClick.AddListener(OnClickButton);
        allgeyserscript = this.gameObject.GetComponentInParent<AllGeyserScript>();
        SingleGeyserScript[] childs = allgeyserscript.GetComponentsInChildren<SingleGeyserScript>();
        trigger = new bool[childs.Length];
        for (int increment = 0; increment < childs.Length; increment++)
        {
            trigger[increment] = false;
            if (this.gameObject == childs[increment].gameObject)
            {
                identity_child = increment;
            }
        }
        number_child = childs.Length;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject==player)
        {
            trigger[identity_child] = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject==player)
        {
            trigger[identity_child] = true;
        }
    }

    void OnClickButton()
    {
        if (trigger[identity_child] && stockage.Corks!=0)
        {
            allgeyserscript.CloseGeyser(this.gameObject);
        }
    }
}
