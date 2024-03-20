using UnityEngine;
using TMPro;
public enum ScoreValue
{
    VILLAGER_HEALED = 500,
    GEYSER_PLUGGED = 1000,
    ANTIDOTE_MINED = 100,
    CORK_MINE = 200
}

public class GameManager : MonoBehaviour
{
    private int _score = 0;
    public TMP_Text healthPeopleText;
    public TMP_Text sickPeopleText;
    public TMP_Text deadPeopleText;
    private int sickPeople = 0;
    private int healthyPeople = 0;
    private int deadPeople = 0;
    public AllGeyserScript geyserScript;
    public int timePeriod = 10;

    void Start()
    {
        setHealthyPeople(80);
        setSickPeople(20);
        setDeadPeople(0);
    }

    public int GetScore()
    {
        return _score;
    }

    public void AddToScore(int value)
    {
        _score += (int)(value / Mathf.Log10(Time.timeSinceLevelLoad + 10));
    }

    public void AddToScore(ScoreValue value)
    {
        _score += (int)value;
    }

    public void SetScore(int score)
    {
        _score = score;
    }

    public void ResetScore()
    {
        _score = 0;
    }

    void setHealthyPeople(int number)
    {
        healthyPeople = number;
        //healthPeopleText.text = healthyPeople.ToString();
    }
    void setSickPeople(int number)
    {
        sickPeople = number;
        //sickPeopleText.text = sickPeople.ToString();
    }
    void setDeadPeople(int number)
    {
        deadPeople = number;
        //deadPeopleText.text = deadPeople.ToString();
    }
    int getHealthyPeople()
    {
        return healthyPeople;
    }
    int getSickPeople()
    {
        return sickPeople;
    }
    int getDeadPeople()
    {
        return deadPeople;
    }

    public void ChangePeopleState(int time)
    {
        if (time % timePeriod == 0)
        {
            ChangeSickPeople(time);
            if (time > 15)
            {
                ChangeDeadPeople(time);
            }
        }
    }
    public void ChangeSickPeople(int time)
    {
        int nbGeysers = geyserScript.getOpenGeysers();
        int nbMalades = getSickPeople()+ getDeadPeople(); ;
        int settingSickPeople = (1 + nbGeysers) * time*10 * (nbMalades + 1) * 100;
        int newSickPeople = 0;
        while (settingSickPeople>=1)
        {
            settingSickPeople = settingSickPeople / 10;
            newSickPeople++;
        }
        if (getHealthyPeople() - newSickPeople < 0){
            setSickPeople(getSickPeople() + getHealthyPeople());
            setHealthyPeople(0);
        }
        else {
            setHealthyPeople(getHealthyPeople() - newSickPeople);
            setSickPeople(getSickPeople() + newSickPeople);
        }
        //Debug.Log(getHealthyPeople());
    }
    void ChangeDeadPeople(int time)
    {
        int nbGeysers = geyserScript.getOpenGeysers();
        int nbDead = getSickPeople();
        int settingDeadPeople = (1 + nbGeysers) * time*10 * (nbDead + 1) * 1000;
        int newDeadPeople = 0;
        while (settingDeadPeople >= 1)
        {
            settingDeadPeople = settingDeadPeople / 10;
            newDeadPeople++;
        }
        if (getSickPeople() - newDeadPeople < 0)
        {
            setDeadPeople(getDeadPeople() + getSickPeople());
            setSickPeople(0);
        }
        else
        {
            setSickPeople(getSickPeople() - newDeadPeople);
            setDeadPeople(getDeadPeople() + newDeadPeople);
        }
        //Debug.Log(getSickPeople());
        //Debug.Log(getDeadPeople());
    }
}
