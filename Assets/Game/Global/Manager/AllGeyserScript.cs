using UnityEngine;
using TMPro;

public class AllGeyserScript : MonoBehaviour
{
    private int geyserNumber = 0;
    private GameObject[] allGeyser;
    private int[] allGeyserState;
    public Sprite spriteClose;
    public Sprite spritePlug;
    private int nbGeysers = 0;
    public int timePeriod = 10;
    public TMP_Text closeGeysersText;
    public TMP_Text openGeysersText;
    public TMP_Text plugGeysersText;
    public GameManager gameManager;
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
        setGeysersText(allGeyser.Length, 0,0);
        for (int increment = 0;increment<geyserNumber; increment++) {
            allGeyserState[increment] = 0;
            allGeyser[increment].GetComponent<SpriteRenderer>().sprite = spriteClose;
        }
    }
    private void setGeysersText(int close, int open, int plug)
    {
        closeGeysersText.text = close.ToString();
        openGeysersText.text = open.ToString();
        plugGeysersText.text = plug.ToString();
    }

    private int getCloseText()
    {
        return System.Int32.Parse(closeGeysersText.text);
    }

    private int getOpenText()
    {
        return System.Int32.Parse(openGeysersText.text);
    }

    private int getPlugText()
    {
        return System.Int32.Parse(plugGeysersText.text);
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
                setGeysersText(getCloseText()-1, getOpenText()+1, getPlugText());
                allGeyserState[indexRandom] = 1;
                setOpenGeysers(getOpenGeysers() + 1);

                allGeyser[indexRandom].transform.GetChild(0).gameObject.SetActive(true);
                return;
            }
        }
    }

    public void CloseGeyser(GameObject child)
    {
        for(int increment = 0; increment<allGeyser.Length;increment++)
        {
            if (child==allGeyser[increment] && allGeyserState[increment]!=2)
            {
                if(allGeyserState[increment] == 1){
                    setGeysersText(getCloseText(), getOpenText() - 1, getPlugText() + 1);
                    setOpenGeysers(getOpenGeysers() - 1);
                }
                else
                {
                    setGeysersText(getCloseText() - 1, getOpenText(), getPlugText() + 1);
                }
                gameManager.AddToScore(ScoreValue.GEYSER_PLUGGED);
                allGeyserState[increment] = 2;
                allGeyser[increment].GetComponent<SpriteRenderer>().sprite = spritePlug;
                allGeyser[increment].transform.GetChild(0).gameObject.GetComponent<ParticleSystem>().Stop();
            }
        }
    }
    public int getOpenGeysers()
    {
        return nbGeysers;
    }
    public void setOpenGeysers(int geysers)
    {
        nbGeysers = geysers;
    }
}
