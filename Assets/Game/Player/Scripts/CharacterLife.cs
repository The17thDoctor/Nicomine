using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UIElements;

public class CharacterLife : MonoBehaviour
{
    private int lifePoints;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int GetLifePoints()
    {
        return lifePoints;
    }

    public void SetLifePoints(int value)
    {
        lifePoints = Mathf.Max(0, value);

        if(lifePoints == 0)
        {
            // TODO lose screen
        }
    }

    public void RemoveLifePoints(int value)
    {
        if(value > 0)
            SetLifePoints(lifePoints - value);
    }
}
